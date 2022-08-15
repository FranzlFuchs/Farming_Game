using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHitcher : MonoBehaviour, IVehicleHitcher
{
    private bool isHitched;

    public void Hitch()
    {
        throw new System.NotImplementedException();
    }

    public void Unhitch()
    {
        throw new System.NotImplementedException();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("FHitcher"))
        {
            isHitched = true;
        }
    }
}
