using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 hitchPoint;

    void Start()
    {
        hitchPoint = new Vector3(0, 0, -20);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 GetHitchPoint()
    {
        return hitchPoint;
    }
}
