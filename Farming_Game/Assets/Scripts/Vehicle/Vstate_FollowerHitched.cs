using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
public class Vstate_FollowerHitched : IState
{
    private Vehicle _vehicle;
    private IFollower _follower;
    private VehicleController _movementController;


    public Vstate_FollowerHitched(Vehicle vehicle, IFollower follower)
    {
        this._vehicle = vehicle;
        this._follower = follower;
        _movementController = new VehicleController(_vehicle);

        _vehicle.CarriedWeight += follower.GetWeight();
        float speedFactor = follower.GetWeight() / _vehicle.GetMaxWeight();

        _movementController.SetSpeed(_vehicle.GetSpeed() * speedFactor);

        Debug.Log("Follower hitched");

    }
    public void Enter()
    {
        return;
    }

    public void Exit()
    {
        _vehicle.CarriedWeight -= _follower.GetWeight();
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
