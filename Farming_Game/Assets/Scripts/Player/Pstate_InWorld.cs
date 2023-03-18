using UnityEngine;
using Interfaces;
using Enums;
public class Pstate_InWorld : IState
{

    private Player _player;
    private PlayerController _movementController;
    public Pstate_InWorld(Player player)
    {
        this._player = player;
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
