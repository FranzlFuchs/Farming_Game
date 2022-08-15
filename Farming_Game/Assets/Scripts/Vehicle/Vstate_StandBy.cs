using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
public class Vstate_StandBy : IState
{
    private Vehicle _vehicle;

    public Vstate_StandBy(Vehicle vehicle)
    {
        this._vehicle = vehicle;
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
        return;
    }
}
