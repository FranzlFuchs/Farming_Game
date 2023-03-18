using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolDetector : MonoBehaviour
{
    private IHitable _hitable;
    private Collider _Collider;

    void Start()
    {
        _hitable = null;
    }

    private void OnTriggerEnter(Collider coll)
    {
        IHitable hitable = coll.gameObject.GetComponent<IHitable>();

        if (hitable != null)
        {
            _Collider = coll;
            _hitable = hitable;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll == _Collider)
        {
            _hitable = null;
        }
    }

    public IHitable GetCollidedHitableObject()
    {
        return _hitable;
    }
}
