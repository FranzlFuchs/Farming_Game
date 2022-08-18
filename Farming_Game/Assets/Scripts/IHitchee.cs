using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitchee 
{

    void Hitched(IFollowerHitcher follower);

    void UnHitched();
    
}
