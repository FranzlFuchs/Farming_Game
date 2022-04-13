using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable 
{
    // Start is called before the first frame update

 


    void Select();
    void Unselect();
    void GetInRange();
    void GetOutOfRange();
    
}
