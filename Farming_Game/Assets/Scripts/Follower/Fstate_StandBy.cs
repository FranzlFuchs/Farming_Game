using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
public class Fstate_StandBy : IState
{
    private Follower _follower;

    public Fstate_StandBy(Follower follower)
    {
        this._follower = follower;
    }
    public void Enter()
    {
        return;
    }

    public void Exit()
    {
        return;
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
        return;
    }
}
