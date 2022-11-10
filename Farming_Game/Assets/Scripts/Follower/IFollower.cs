using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public interface IFollower
{
    float GetWeight();
    
    public void Hitch();
    
    public void Unhitch();
    
    public void Activate();
    
    public void Deactivate();   

}
