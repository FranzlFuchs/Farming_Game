using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class VehicleController
{

    float reverseSpeedModifier = 0.5f;

    IMoveable Movee;
    GameObject MoveeGO;
    Rigidbody MoveeRB;
    public float verticalInput;
    public float horizontalInput;
    public float speed;
    public float rotspeed;
    //public Orientation lastPlayerOrientation;
    public Orientation playerOrientation;
    private RotationManager rotationManager = new RotationManager();
    private Quaternion quat = new Quaternion();
    public float rot;
    private bool _moving;

    bool inReverse;

    public VehicleController(IMoveable moveable)
    {
        this.Movee = moveable;
        this.MoveeGO = moveable.GetGameObject();
        MoveeRB = MoveeGO.GetComponent<Rigidbody>();
        inReverse = false;
        speed = moveable.GetSpeed();
        rotspeed = moveable.GetRotationSpeed();
        _moving = false;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void MovementUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            inReverse = !inReverse;

            if (inReverse)
            {

            }

            if (!inReverse)
            {

            }
        }

        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if(verticalInput != 0 || horizontalInput != 0 && !_moving)
        {
            _moving = true;
            Movee.AnimateGoing();
        }

        if(verticalInput == 0 && horizontalInput == 0 && _moving)
        {
            _moving = false;
            Movee.AnimateStanding();
        }

        MoveeGO.transform.rotation = Quaternion.RotateTowards(MoveeGO.transform.rotation, quat, rotspeed);

        if (!inReverse)
        {
            //MoveeGO.transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime), Space.World);
            //MoveeRB.AddForce(new Vector3(horizontalInput * speed, 0, verticalInput * speed));
            // MoveeRB.AddForce(new Vector3(horizontalInput * speed, 0, verticalInput * speed), ForceMode.Impulse);
            playerOrientation = GetOrientation(horizontalInput, verticalInput);

            if (playerOrientation != Orientation.I)
            {
                //lastPlayerOrientation = playerOrientation;
                rot = rotationManager.GetRotation(playerOrientation);
                quat = Quaternion.AngleAxis(rot, Vector3.up);

            }

            if (quat == MoveeGO.transform.rotation)
            {

                MoveeRB.velocity = new Vector3(horizontalInput * speed, 0, verticalInput * speed);
            }
            else
            {

                //MoveeRB.AddForce(MoveeGO.transform.forward, ForceMode.VelocityChange);
                MoveeRB.velocity = MoveeGO.transform.forward * speed;
            }
        }

        if (inReverse)
        {
            //MoveeGO.transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime * reverseSpeedModifier, 0, verticalInput * speed * Time.deltaTime * reverseSpeedModifier), Space.World);
            //MoveeRB.AddForce(new Vector3(horizontalInput * speed * reverseSpeedModifier, 0, verticalInput * speed * reverseSpeedModifier));
            //MoveeRB.AddForce(MoveeGO.transform.forward * horizontalInput * speed * reverseSpeedModifier);
            playerOrientation = GetOrientation(-horizontalInput, -verticalInput);

            if (playerOrientation != Orientation.I)
            {
                //lastPlayerOrientation = playerOrientation;
                rot = rotationManager.GetRotation(playerOrientation);
                quat = Quaternion.AngleAxis(rot, Vector3.up);

            }

            if (quat == MoveeGO.transform.rotation)
            {
                MoveeRB.velocity = new Vector3(horizontalInput * speed * reverseSpeedModifier, MoveeRB.velocity.y, verticalInput * speed * reverseSpeedModifier);
            }
            else
            {
                //MoveeRB.AddForce(MoveeGO.transform.forward * 1200, ForceMode.Force);
                MoveeRB.velocity = MoveeGO.transform.forward * speed * reverseSpeedModifier;
            }
        }

        if (playerOrientation != Orientation.I)
        {
            //lastPlayerOrientation = playerOrientation;
            rot = rotationManager.GetRotation(playerOrientation);
            quat = Quaternion.AngleAxis(rot, Vector3.up);

        }

        //MoveeGO.transform.eulerAngles = new Vector3(0, rot, 0);

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
