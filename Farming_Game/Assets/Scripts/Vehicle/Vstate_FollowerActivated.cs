using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
public class Vstate_FollowerActivated : IState
{
    private Vehicle _vehicle;
    private IFollower _follower;
    private VehicleController _movementController;


    public Vstate_FollowerActivated(Vehicle vehicle, IFollower follower)
    {
        this._vehicle = vehicle;
        this._follower = follower;
        _movementController = new VehicleController(_vehicle);       

        _movementController.SetSpeed(_vehicle.GetSpeed() * 0.7f);      

    }
    public void Enter()
    {
        return;
    }

    public void Exit()
    {
       
    }

    public void FixedUpdate()
    {
        return;
    }

    public void OnCollisionEnter(Collision coll)
    {
        return;
    }

    public void Update()
    {
        _movementController.MovementUpdate();
    }
}
