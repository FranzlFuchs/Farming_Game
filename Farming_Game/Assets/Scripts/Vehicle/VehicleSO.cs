using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu]
public class VehicleSO : ScriptableObject
{
    public float speed;
    public float rotationSpeed;
    public float maxWeight;
    //public HitchPoints numHitchPoints;
    public VehicleSeat seat;   

}
