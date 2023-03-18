using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitable
{
   public void StartHitting(ITool tool);
   public void StopHitting(ITool tool);
}
