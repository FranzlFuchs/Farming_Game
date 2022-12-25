using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class PlayerController
{
    float reverseSpeedModifier = 0.5f;

    IMoveable Movee;
    GameObject MoveeGO;
    Rigidbody MoveeRB;
    public float verticalInput;
    public float horizontalInput;
    public float speed;
    public float rotspeed;
    public Orientation lastPlayerOrientation;
    public Orientation playerOrientation;
    private RotationManager rotationManager = new RotationManager();
    public float rot;

    bool inReverse;
    bool moving;
    bool movingBefore;

    public PlayerController(IMoveable moveable)
    {
        this.Movee = moveable;
        this.MoveeGO = moveable.GetGameObject();
        MoveeRB = MoveeGO.GetComponent<Rigidbody>();
        inReverse = false;
        speed = moveable.GetSpeed();
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
        movingBefore = moving;
        if (verticalInput == 0 && horizontalInput == 0)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }

        if (moving != movingBefore)
        {
            if (movingBefore == false)
            {
                Movee.AnimateGoing();
            }
            else
            {
                Movee.AnimateStanding();
            }
        }

        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (!inReverse)
        {
            playerOrientation = GetOrientation(horizontalInput, verticalInput);
            MoveeRB.velocity = new Vector3(horizontalInput * speed, MoveeRB.velocity.y, verticalInput * speed);
        }

        if (inReverse)
        {
            playerOrientation = GetOrientation(-horizontalInput, -verticalInput);
            MoveeRB.velocity = new Vector3(horizontalInput * speed * reverseSpeedModifier, MoveeRB.velocity.y, verticalInput * speed * reverseSpeedModifier);
        }

        if (playerOrientation != Orientation.I)
        {
            lastPlayerOrientation = playerOrientation;
            rot = rotationManager.GetRotation(playerOrientation);
            Movee.AnimateGoing();
        }

        MoveeGO.transform.eulerAngles = new Vector3(0, rot, 0);

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
