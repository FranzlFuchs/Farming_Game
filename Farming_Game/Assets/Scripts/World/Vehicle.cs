using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    // Start is called before the first frame update

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
        Debug.Log("Stay");
        yield return new WaitForSeconds(seconds);
        speedModifier = defaultspeedModifier;
       

    }
}
