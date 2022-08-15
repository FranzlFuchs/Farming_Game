using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable 
{
    float GetSpeed();

    GameObject GetGameObject();

    void SetReverse();
    void UnSetReverse();
    
}
