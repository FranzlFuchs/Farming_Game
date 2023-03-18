using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Pstate_HasTool : IState
{
      private Player _player;
      private ITool _tool;
    private PlayerController _movementController;
    public Pstate_HasTool(Player player, ITool tool)
    {
        this._player = player;
        this._tool = tool;
        _movementController = new PlayerController(_player, _player.orientation);
        _movementController.SetSpeed(_player.GetSpeed());
    }

    public void Enter()
    {
        return;
    }

    public void Exit()
    {
        return;
    }

    public void Update()
    {
        _movementController.MovementUpdate();
        _player.orientation = _movementController.playerOrientation;

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            _player.ChangeState(new Pstate_UsingTool(_player, _tool));
        }
    }

    public void OnCollisionEnter(Collision coll)
    {
        return;
    }

    public void FixedUpdate()
    {
        return;
    }
}
