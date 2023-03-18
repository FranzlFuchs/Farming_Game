using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

[CreateAssetMenu]
public class ToolSO : ScriptableObject
{
      public float damage;
      public Vector3 PositionInHand;
      public Vector3 EulerAnglesInHand;
      public ToolType toolType;
}
