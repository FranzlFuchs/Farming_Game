using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class WorldSO : ScriptableObject
{
    [SerializeField] public float WorldEdgeYReset; 
    [SerializeField] public float WorldEdgeYMin; 
    [SerializeField] public float WorldEdgeYMax; 
}
