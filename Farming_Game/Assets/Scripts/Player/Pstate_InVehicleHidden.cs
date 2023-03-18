using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class Pstate_InVehicleHidden : IState
{
    private Player _player;

    private Vehicle _vehicle;



    public Pstate_InVehicleHidden(Player player, Vehicle vehicle)
    {
        this._player = player;
        this._vehicle = vehicle;
    }
    public void Enter()
    {

        _player.transform.position = new Vector3(9999, 9999, 9999);
        return;
    }

    public void Exit()
    {
        //_player.gameObject.GetComponent<MeshRenderer>().enabled = true;
        _player.transform.position = _vehicle.GetExitPointPosition();
        _player.transform.rotation = _vehicle.GetExitPointRotation();

        return;
    }

    public void FixedUpdate()
    {
        return;
    }

    public void OnCollisionEnter(Collision coll)
    {
        /*
        if (coll.gameObject.CompareTag("Vehicle"))
        {
            _player.transform.position = coll.transform.position;
            _vehicle = coll.gameObject;
        }
        */
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _player.ChangeState(new Pstate_InWorld(_player));
        }
        return;
    }
}
