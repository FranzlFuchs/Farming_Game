using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class Pstate_InVehicleRiding : IState
{
    private Player _player;

    private Vehicle _vehicle;

    public Pstate_InVehicleRiding(Player player, Vehicle vehicle)
    {
        this._player = player;
        this._vehicle = vehicle;
    }
    public void Enter()
    {
        _player.GetComponent<Collider>().enabled = false;
        //SITTING
        _player.AnimateStanding();
        return;
    }

    public void Exit()
    {
        _player.transform.position = _vehicle.GetExitPointPosition();
        _player.transform.rotation = _vehicle.GetExitPointRotation();

        _player.GetComponent<Collider>().enabled = true;

        return;
    }

    public void OnCollisionEnter(Collision coll)
    {
        return;
    }

    public void Update()
    {
        // GRINDIG
        _player.transform.position = _vehicle.GetSaddlePointPosition();
        _player.transform.rotation = _vehicle.GetSaddlePointRotation();

        return;
    }

    public void FixedUpdate()
    {
        return;
    }
}
