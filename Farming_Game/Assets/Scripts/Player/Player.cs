using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
using Interfaces;
public class Player : MonoBehaviour, IMoveable
{

    [SerializeField] private PlayerSO _playerConfig;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private GameObject _hand;
    [SerializeField] private GameObject _toolRange;
    private ToolDetector _toolDetector;

    public Orientation orientation;


    private IState _currentState;
    public void ChangeState(IState newState)
    {
        _currentState.Exit();
        newState.Enter();
        _currentState = newState;
    }

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _currentState = new Pstate_InWorld(this);
        _currentState.Enter();
        _toolDetector = _toolRange.GetComponent<ToolDetector>();
    }

    void Update()
    {
        _currentState.Update();
    }

    public float GetSpeed()
    {
        return _playerConfig.speed;
    }
    public float GetRotationSpeed()
    {
        return 0;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Vehicle"))
        {
            Vehicle collVehicle = coll.gameObject.GetComponent<Vehicle>();

            if (collVehicle.GetSeat() == VehicleSeat.rideable)
            {
                ChangeState(new Pstate_InVehicleRiding(this, collVehicle));
            }

            if (collVehicle.GetSeat() == VehicleSeat.hidden)
            {
                ChangeState(new Pstate_InVehicleHidden(this, collVehicle));
            }
        }

        _currentState.OnCollisionEnter(coll);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void SetRigidBodyVelocity(Vector3 inputVector)
    {
        GetComponent<Rigidbody>().velocity = inputVector;
    }


    public void SetReverse()
    {
        return;
    }

    public void UnSetReverse()
    {
        return;
    }

    public void AnimateHackingOn()
    {
        if (_playerAnimator != null)
        {
            _playerAnimator.SetBool("Hacking", true);
        }
    }

    public void AnimateHackingOff()
    {
        if (_playerAnimator != null)
        {
            _playerAnimator.SetBool("Hacking", false);
        }
    }

    public void AnimateStanding()
    {
        if (_playerAnimator != null)
        {
            _playerAnimator.SetBool("Running", false);
        }
    }
    public void AnimateGoing()
    {
        if (_playerAnimator != null)
        {
            _playerAnimator.SetBool("Running", true);
        }
    }

    public void EquipTool(GameObject tool)
    {
        tool.gameObject.transform.SetParent(_hand.transform);
        ChangeState(new Pstate_HasTool(this, tool.GetComponent<ITool>()));
    }

    public void UnEquipTool(GameObject tool)
    {
        tool.gameObject.transform.SetParent(null, true);
        ChangeState(new Pstate_InWorld(this));
    }


    public IHitable GetToolCollisionHitable()
    {
        return _toolDetector.GetCollidedHitableObject();
    }

 
}
