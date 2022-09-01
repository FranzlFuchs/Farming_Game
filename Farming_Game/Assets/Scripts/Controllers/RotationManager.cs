using System.Collections.Generic;
using Enums;
using UnityEngine;

class 
RotationManager
{

    public Dictionary<Orientation, float> rotationToOrientation = new Dictionary<Orientation, float>();
    public RotationManager()
    {        

        /*
        rotationToOrientation.Add(Orientation.N, 0.0f);
        rotationToOrientation.Add(Orientation.NE, 45.0f);
        rotationToOrientation.Add(Orientation.NW, -45.0f);
        rotationToOrientation.Add(Orientation.S, 180.0f);
        rotationToOrientation.Add(Orientation.SE, 135.0f);
        rotationToOrientation.Add(Orientation.SW, -135.0f);
        rotationToOrientation.Add(Orientation.E, 90.0f);
        rotationToOrientation.Add(Orientation.W, -90.0f);
        
        */
        rotationToOrientation.Add(Orientation.N, 0.0f);
        rotationToOrientation.Add(Orientation.NE, 45.0f);
        rotationToOrientation.Add(Orientation.NW, 315.0f);
        rotationToOrientation.Add(Orientation.S, 180.0f);
        rotationToOrientation.Add(Orientation.SE, 135.0f);
        rotationToOrientation.Add(Orientation.SW, 225.0f);
        rotationToOrientation.Add(Orientation.E, 90.0f);
        rotationToOrientation.Add(Orientation.W, 270.0f);

        
    }

    public float GetRotation(Orientation orientation)
    {        
        return rotationToOrientation[orientation];
    }

}