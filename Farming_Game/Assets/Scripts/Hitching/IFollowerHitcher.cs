using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFollowerHitcher
{
    bool Hitch(VHitcher vhitcher);
    bool Unhitch();

    //float GetFollowerWeight();
}