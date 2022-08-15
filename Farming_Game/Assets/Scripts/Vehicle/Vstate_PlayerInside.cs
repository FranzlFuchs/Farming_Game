using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
using Interfaces;
public class Vstate_PlayerInside : IState
{
    private Vehicle _vehicle;
    private MovementController _movementController;

    public Vstate_PlayerInside(Vehicle vehicle)
    {
        this._vehicle = vehicle;
        _movementController = new MovementController(_vehicle.gameObject);
        _movementController.SetSpeed(_vehicle.GetSpeed());

    }
    
    public void Enter()
    {        
        return;
    }

    public void Exit()
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
