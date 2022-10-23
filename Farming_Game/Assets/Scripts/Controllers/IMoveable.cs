using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable 
{
    float GetSpeed();
    float GetRotationSpeed();

    GameObject GetGameObject();
    void SetRigidBodyVelocity(Vector3 inputVector);

    void SetReverse();
    void UnSetReverse();

     public void AnimateStanding();
    public void AnimateGoing();

    
}
