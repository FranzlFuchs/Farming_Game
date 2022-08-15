using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IState
    {
       void Enter();
       void Update();
       void Exit();

       void OnCollisionEnter(Collision coll);
    }
}
