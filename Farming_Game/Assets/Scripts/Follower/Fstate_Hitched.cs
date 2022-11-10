using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
public class Fstate_Hitched : IState
{
    private Follower _follower;

    public Fstate_Hitched(Follower follower)
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
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _follower.Activate();
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _follower.Deactivate();
        }
    }
}
