using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class TState_LayingAround : IState
{
    private ITool _tool;
    public TState_LayingAround(ITool tool)
    {
        _tool = tool;
    }
    public void Enter()
    {
        _tool.PlaceInWorld();
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
        if(coll.gameObject.CompareTag("Player") && !_tool.IsEquipped())
        {           
            _tool.ChangeState(new TState_Equipped(_tool, coll.gameObject.GetComponent<Player>()));
        }
    }
   
    void IState.Update()
    {
        return;
    }
}
