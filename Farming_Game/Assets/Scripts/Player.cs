using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class Player : MonoBehaviour
{
    public float verticalInput;
    public float horizontalInput;
    public float speed;
    public float rot;
    public bool[] orientation;

    bool inVehicle;

    public Orientation playerOrientation;
    private RotationManager rotationManager = new RotationManager();

    private Vehicle enteredVehicle;


    void Start()
    {
        speed = 50.0f;
        inVehicle = false;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        playerOrientation = GetOrientation(horizontalInput, verticalInput);

        if (Input.GetKeyDown(KeyCode.LeftShift) && inVehicle)
        {
            ExitVehicle();
        }


        if (playerOrientation != Orientation.I)
        {
            rot = rotationManager.GetRotation(playerOrientation);
        }

        transform.eulerAngles = new Vector3(0, rot, 0);

        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime), Space.World);
    }


    void EnterVehicle(Vehicle vehicle)
    {
        enteredVehicle = vehicle;
        vehicle.gameObject.transform.SetParent(transform);
        vehicle.Enter();
        inVehicle = true;
    }

    void ExitVehicle()
    {
        enteredVehicle.gameObject.transform.SetParent(null);
        enteredVehicle.Exit();
        inVehicle = false;



        transform.position = enteredVehicle.transform.position + enteredVehicle.GetExitPoint();

        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<CapsuleCollider>().enabled = true;
    }

    private Orientation GetOrientation(float horAxis, float vertAxis)
    {

        //N
        if (vertAxis > 0 && horAxis == 0)
        {
            return Orientation.N;
        }
        //NE
        else if (vertAxis > 0 && horAxis > 0)
        {
            return Orientation.NE;

        }
        //NW
        else if (vertAxis > 0 && horAxis < 0)
        {
            return Orientation.NW;

        }
        //E
        else if (vertAxis == 0 && horAxis > 0)
        {
            return Orientation.E;
        }
        //W
        else if (vertAxis == 0 && horAxis < 0)
        {
            return Orientation.W;

        }
        //S
        if (vertAxis < 0 && horAxis == 0)
        {
            return Orientation.S;

        }
        //SE
        else if (vertAxis < 0 && horAxis > 0)
        {
            return Orientation.SE;

        }
        //SW
        else if (vertAxis < 0 && horAxis < 0)
        {
            return Orientation.SW;

        }


        return Orientation.I;


    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Vehicle") && !inVehicle)
        {

            EnterVehicle(collider.gameObject.GetComponent<Vehicle>());
            collider.gameObject.transform.rotation = transform.rotation;
            transform.position = collider.gameObject.transform.position;
            collider.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
