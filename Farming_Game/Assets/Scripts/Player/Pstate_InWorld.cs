using UnityEngine;
using Interfaces;
using Enums;
public class Pstate_InWorld : IState
{

    private Player _player;
    private MovementController _movementController;
    public Pstate_InWorld(Player player)
    {
        this._player = player;
        _movementController = new MovementController(_player);
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

    }

    public void OnCollisionEnter(Collision coll)
    {
        return;
    }
}
