using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu]
public class HitAbleSO : ScriptableDictionary<ToolType, float>
{
   public float HitPoints;
   //public Dictionary<ToolType, float> HitTable = new Dictionary<ToolType, float>();
}
