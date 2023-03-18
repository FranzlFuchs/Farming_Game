using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu]
public class HitAbleSO : ScriptableObject
{
   public float HitPoints;
   public Dictionary<ToolType, float> HitTable = new Dictionary<ToolType, float>();
}
