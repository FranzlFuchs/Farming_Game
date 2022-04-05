using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    // Start is called before the first frame update
    SphereCollider workGroundRange;

    bool active;
    float radius = 0.5f;
    void Start()
    {
        workGroundRange = GetComponent<SphereCollider>();
        workGroundRange.radius = radius;
        active = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        active = true;
    }
    public void Deactivate()
    {
        active = false;
    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.CompareTag("Tile") && active)
        {
           gameObject.GetComponentInParent<Follower>().WorkTile(coll.gameObject.GetComponent<Tile>());
        }
    }
}
