using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 hitchPoint;

    SelectableList followerList = new SelectableList();




    private Follower followerAttached;

    bool hasFollower;

    void Start()
    {
        hitchPoint = new Vector3(0, 0, -20);
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
            followerList.SelectableInRange(followerAttached);
            return;
        }
    }

    public void ActivateFollowerGroundWorking()
    {
        if (hasFollower)
        {
            followerAttached.ActivateGroundWorking();
        }

    }
    public void DeactivateFollowerGroundWorking()
    {
        if (hasFollower)
        {
            followerAttached.DeactivateGroundWorking();
        }

    }

    public Vector3 GetHitchPoint()
    {
        return hitchPoint;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Follower") && hasFollower == false)
        {
            followerList.SelectableInRange(collider.GetComponent<Follower>());
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Follower") && hasFollower == false)
        {
            followerList.SelectableOutOfRange(collider.GetComponent<Follower>());
        }
    }
}
