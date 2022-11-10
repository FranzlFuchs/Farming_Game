using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plow : MonoBehaviour, IGadget



{
    private bool _activated;
    public void Activate()
    {
        _activated = true;
    }

    public void Deactivate()
    {
        _activated = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _activated = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider coll)
    {
        if (_activated)
        {
            if (coll.CompareTag("Tile"))
            {
                //TILE CHANGE
                coll.gameObject.GetComponent<Tile>().ChangeMaterial();
            }
        }
    }
}
