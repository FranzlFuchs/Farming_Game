

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;



public class PlayerController : MonoBehaviour
{


    public float verticalInput;
    public float horizontalInput;
    public float speed;
    public float gravity;
    public float rot;

    public Orientation playerOrientation;
    private RotationManager rotationManager = new RotationManager();


    public bool[] orientation;

    // Start is called before the first frame update
    void Start()
    {
        speed = 50.0f;

    }

    // Update is called once per frame
    void Update()
    {
        
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        playerOrientation = GetOrientation(horizontalInput, verticalInput);
        if (playerOrientation != Orientation.I)
        {
            rot = rotationManager.GetRotation(playerOrientation);
        }

        transform.eulerAngles = new Vector3(0, rot,0);

        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime), Space.World);
        


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
}
