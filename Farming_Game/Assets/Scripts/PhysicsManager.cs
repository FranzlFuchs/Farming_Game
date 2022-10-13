using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{

    public float Gravity;
   
    void Start()
    {
        Physics.gravity = Vector3.down * Gravity;
    }

}
