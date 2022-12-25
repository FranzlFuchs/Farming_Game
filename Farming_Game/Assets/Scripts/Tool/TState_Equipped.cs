using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class TState_Equipped : IState
{
    private ITool _tool;
    private Player _player;
    public TState_Equipped(ITool tool, Player player)
    {
        _tool = tool;
        _player = player;
    }
    public void Enter()
    {
        _tool.EquippedPlayer(_player);
        _tool.PositionInPlayerHand();       
    }

    public void Exit()
    {
        _tool.UnEquippedPlayer(_player);
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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _tool.ChangeState(new TState_LayingAround(_tool));
        }
    }
}
