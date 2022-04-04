using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVehicleController : MonoBehaviour
{


    SelectableList followerList = new SelectableList();

    private Follower followerAttached;

    bool hasFollower;

    // Start is called before the first frame update
    void Start()
    {
        hasFollower = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && hasFollower == true)
        {
            hasFollower = false;
            followerAttached.Dettach();            
            followerList.SelectableInRange(followerAttached);
            Debug.Log("Detach");

            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && hasFollower == false)
        {

            if (followerList.Count() > 0)
            {
                hasFollower = true;
                followerList.Clear();
                followerAttached = (Follower)followerList.GetSelected();
                followerAttached.Attach(this.gameObject);
                Debug.Log("Attach");
                return;
            }
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            followerList.Previous();
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            followerList.Next();
            return;
        }

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
