using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public Vehicle vehicle;  



    // Start is called before the first frame update
    void Start()
    {
        vehicle = GetComponent<Vehicle>();     
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            vehicle.SwitchFollower();
            return;
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            vehicle.SelectPreviousFollower();
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            vehicle.SelectNextFollower();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            vehicle.ActivateFollowerGroundWorking();
            return;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {

            vehicle.DeactivateFollowerGroundWorking();
            return;
        }

    }


}
