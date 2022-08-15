using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class MovementController
{

    float reverseSpeedModifier = 0.5f;

    IMoveable Movee;
    GameObject MoveeGO;
    public float verticalInput;
    public float horizontalInput;
    public float speed;
    public Orientation lastPlayerOrientation;
    public Orientation playerOrientation;
    private RotationManager rotationManager = new RotationManager();
    public float rot;

    bool inReverse;

    public MovementController(IMoveable moveable)
    {
        this.Movee = moveable;
        this.MoveeGO = moveable.GetGameObject();
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

        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (!inReverse)
        {
            playerOrientation = GetOrientation(horizontalInput, verticalInput);

            MoveeGO.transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime), Space.World);
        }

        if (inReverse)
        {
            playerOrientation = GetOrientation(-horizontalInput, -verticalInput);

            MoveeGO.transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime * reverseSpeedModifier, 0, verticalInput * speed * Time.deltaTime * reverseSpeedModifier), Space.World);
        }

        if (playerOrientation != Orientation.I)
        {
            lastPlayerOrientation = playerOrientation;
            rot = rotationManager.GetRotation(playerOrientation);
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
