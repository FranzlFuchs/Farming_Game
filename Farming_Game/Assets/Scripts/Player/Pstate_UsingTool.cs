using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Pstate_UsingTool : IState
{
    private Player _player;

    private ITool _tool;

    private IHitable _hitedObject;

    public Pstate_UsingTool(Player player, ITool tool)
    {
        this._player = player;
        this._tool = tool;
    }

    public void Enter()
    {
        _player.AnimateHackingOn();
        _player.GetComponent<Rigidbody>().freezeRotation = true;
        _hitedObject = _player.GetToolCollisionHitable();
        if (_hitedObject != null)
        {
            _hitedObject.StartHitting(_tool );
        }
    }

    public void Exit()
    {
        _player.GetComponent<Rigidbody>().freezeRotation = false;
        _player.AnimateHackingOff();
        _player.AnimateStanding();
        if (_hitedObject != null)
        {
            _hitedObject.StopHitting(_tool);
            _hitedObject = null;
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _player.ChangeState(new Pstate_HasTool(_player, _tool));
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
