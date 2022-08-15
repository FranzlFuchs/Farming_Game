using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
using Interfaces;

public class Vehicle : MonoBehaviour, IVehicle
{

    [SerializeField] private VehicleSO _vehicleSO;
    private IState _currentState;

    [SerializeField] GameObject _exitPoint;

    [SerializeField] GameObject _saddlePoint;

    //Hitchpoints are Local space



    //private List<GameObject> _hitcherGameObjects;
    //private List<IVehicleHitcher> _hitchers;
    //private List<IFollower> _hitchedFollowers;

    public Vector3 GetExitPointPosition()
    {
        return _exitPoint.transform.position;
    }

    public Vector3 GetSaddlePointPosition()
    {
        return _saddlePoint.transform.position;
    }


    public float GetSpeed()
    {
        return _vehicleSO.speed;
    }

    public Quaternion GetExitPointRotation()
    {

        return this._exitPoint.transform.rotation;

    }


    public VehicleSeat GetSeat()
    {
        return _vehicleSO.seat;
    }

    void Awake()
    {
        //_hitchPoints = new List<GameObject>((int)vehicleSO.numHitchPoints);
        //_hitchers = new List<IVehicleHitcher>((int)vehicleSO.numHitchPoints);
        //_hitchedFollowers = new List<IFollower>();
    }

    void Start()
    {
        _currentState = new Vstate_StandBy(this);
        _currentState.Enter();
    }

    void Update()
    {
        _currentState.Update();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ChangeState(new Vstate_StandBy(this));
        }
    }

    void ChangeState(IState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        newState.Enter();
    }

    void OnCollisionEnter(Collision coll)
    {
        _currentState.OnCollisionEnter(coll);

        if (coll.gameObject.CompareTag("Player"))
        {
            ChangeState(new Vstate_PlayerInside(this));
        }
    }

    /*
    VehicleSO vehicleSO;

    SelectableList followerList = new SelectableList();
    private Vector3 hitchPoint;
    private Follower followerAttached;
    private VehicleController vehicleController;

    public float exitDistanceRight;
    public float speedModifier;
    public float defaultspeedModifier;
    public float speedModifierGroundWorking;
    public float speedModifierFollower;

    bool hasFollower;

    bool hasPlayer;

    int secondFollowerPullUp;



    void Start()
    {
        hitchPoint = new Vector3(0, 0, -20);
        exitDistanceRight = 20;

        vehicleController = GetComponent<VehicleController>();
        defaultspeedModifier = 1.5f;
        speedModifier = defaultspeedModifier;

        speedModifierGroundWorking = 0.5f;
        secondFollowerPullUp = 1;
        hasFollower = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectNextFollower()
    {
        followerList.Previous();
    }
    public void SelectPreviousFollower()
    {
        followerList.Next();
    }
    public void SwitchFollower()
    {

        if (hasFollower == false)
        {
            if (followerList.Count() > 0)
            {
                hasFollower = true;
                followerAttached = (Follower)followerList.GetSelected();
                followerList.Clear();
                followerAttached.Attach(this.gameObject);
                return;
            }
        }

        if (hasFollower == true)
        {
            hasFollower = false;
            followerAttached.Dettach();
            ResetCollider();
            return;
        }
    }

    public void ActivateFollowerGroundWorking()
    {
        if (hasFollower)
        {
            followerAttached.ActivateGroundWorking();
            speedModifier = speedModifierGroundWorking;
        }

    }
    public void DeactivateFollowerGroundWorking()
    {
        if (hasFollower)
        {
            followerAttached.DeactivateGroundWorking(secondFollowerPullUp);
            StartCoroutine(Stay(secondFollowerPullUp));
        }
    }

    public Vector3 GetHitchPoint()
    {
        return hitchPoint;
    }


    public void Enter()
    {
        hasPlayer = true;
        vehicleController.enabled = true;
        ResetCollider();

    }
    public void Exit()
    {
        hasPlayer = false;
        vehicleController.enabled = false;
        followerList.Clear();
    }

    void ResetCollider()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Collider>().enabled = true;
    }

    public Vector3 GetExitPoint()
    {
        Debug.Log(transform.localPosition);
        Debug.Log(transform.position);

        return transform.right * exitDistanceRight;


    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Follower") && hasFollower == false && hasPlayer)
        {
            followerList.SelectableInRange(collider.GetComponent<Follower>());
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Follower") && hasFollower == false && hasPlayer)
        {
            followerList.SelectableOutOfRange(collider.GetComponent<Follower>());
        }
    }

    public IEnumerator Stay(int seconds)
    {
        speedModifier = 0;
        yield return new WaitForSeconds(seconds);
        speedModifier = defaultspeedModifier;
    }

    */
}
