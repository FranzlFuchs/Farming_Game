using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
using Interfaces;
public class Player : MonoBehaviour, IMoveable
{

    [SerializeField] private PlayerSO _playerConfig;

    [SerializeField] private Animator _playerAnimator;


    private IState _currentState;
    public void ChangeState(IState newState)
    {
        _currentState.Exit();
        newState.Enter();
        _currentState = newState;
    }

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _currentState = new Pstate_InWorld(this);
        _currentState.Enter();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ChangeState(new Pstate_InWorld(this));
        }
        _currentState.Update();
    }

    public float GetSpeed()
    {
        return _playerConfig.speed;
    }
    public float GetRotationSpeed()
    {
        return 0;
    }

    void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.CompareTag("Vehicle"))
        {
            Vehicle collVehicle = coll.gameObject.GetComponent<Vehicle>();

            if (collVehicle.GetSeat() == VehicleSeat.rideable)
            {
                ChangeState(new Pstate_InVehicleRiding(this, collVehicle));
            }

            if (collVehicle.GetSeat() == VehicleSeat.hidden)
            {
                ChangeState(new Pstate_InVehicleHidden(this, collVehicle));
            }
        }

        _currentState.OnCollisionEnter(coll);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void SetRigidBodyVelocity(Vector3 inputVector)
    {
        GetComponent<Rigidbody>().velocity = inputVector;
    }


    public void SetReverse()
    {
        return;
    }

    public void UnSetReverse()
    {
        return;
    }

    public void AnimateStanding()
    {
        if (_playerAnimator != null)
        {
            _playerAnimator.SetBool("Running", false);
        }
    }
    public void AnimateGoing()
    {
        if (_playerAnimator != null)
        {
            _playerAnimator.SetBool("Running", true);
        }
    }

    /*
    public float verticalInput;
    public float horizontalInput;
    public float speed;
    public float forwardSpeed;
    public float reverseSpeed;
    public float rot;
    public bool[] orientation;

    private bool inReverse;

    bool inVehicle;

    public Orientation playerOrientation;
    public Orientation lastPlayerOrientation;
    private RotationManager rotationManager = new RotationManager();

    private Vehicle enteredVehicle;


    void Start()
    {
        forwardSpeed = 50.0f;
        reverseSpeed = 15.0f;
        speed = forwardSpeed;
        inVehicle = false;
        inReverse = false;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (inReverse)
        {
            playerOrientation = GetReverseOrientation(horizontalInput, verticalInput);
        }
        else
        {
            playerOrientation = GetOrientation(horizontalInput, verticalInput);
        }

        if (playerOrientation != Orientation.I)
        {
            lastPlayerOrientation = playerOrientation;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && inVehicle)
        {
            ExitVehicle();
        }



        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            if (inReverse == false)
            {
                inReverse = true;
                speed = reverseSpeed;

            }
            else
            {
                inReverse = false;
                speed = forwardSpeed;

            }
            //playerOrientation = GetOppositeOrientation(lastPlayerOrientation);
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && inVehicle)
        {
            ExitVehicle();
        }


        if (playerOrientation != Orientation.I)
        {
            rot = rotationManager.GetRotation(playerOrientation);
        }

        transform.eulerAngles = new Vector3(0, rot, 0);

        if (inVehicle)
        {
            transform.Translate(new Vector3(horizontalInput * speed * enteredVehicle.speedModifier * Time.deltaTime, 0, verticalInput * speed * enteredVehicle.speedModifier * Time.deltaTime), Space.World);
        }
        else
        {
            transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime), Space.World);
        }




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


    private Orientation GetReverseOrientation(float horAxis, float vertAxis)
    {

        //N
        if (vertAxis > 0 && horAxis == 0)
        {
            return Orientation.S;
        }
        //NE
        else if (vertAxis > 0 && horAxis > 0)
        {
            return Orientation.SW;
        }
        //NW
        else if (vertAxis > 0 && horAxis < 0)
        {
            return Orientation.SE;
        }
        //E
        else if (vertAxis == 0 && horAxis > 0)
        {
            return Orientation.W;
        }
        //W
        else if (vertAxis == 0 && horAxis < 0)
        {
            return Orientation.E;
        }
        //S
        if (vertAxis < 0 && horAxis == 0)
        {
            return Orientation.N;
        }
        //SE
        else if (vertAxis < 0 && horAxis > 0)
        {
            return Orientation.NW;
        }
        //SW
        else if (vertAxis < 0 && horAxis < 0)
        {
            return Orientation.NE;
        }

        return Orientation.I;

    }




    private Orientation GetOppositeOrientation(Orientation orientation)
    {

        //N
        if (orientation == Orientation.N)
        {
            return Orientation.S;
        }
        //NE
        if (orientation == Orientation.NE)
        {
            return Orientation.SW;
        }
        //NW
        if (orientation == Orientation.NW)
        {
            return Orientation.SE;
        }
        //E
        if (orientation == Orientation.E)
        {
            return Orientation.W;
        }
        //W
        if (orientation == Orientation.W)
        {
            return Orientation.E;
        }
        //S
        if (orientation == Orientation.S)
        {
            return Orientation.N;
        }
        //SE
        if (orientation == Orientation.SE)
        {
            return Orientation.NW;
        }
        //SW
        if (orientation == Orientation.SW)
        {
            return Orientation.NE;
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

    */
}
