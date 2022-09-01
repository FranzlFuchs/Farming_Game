using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour, IFollower
{
   FollowerSO _followerSO;
    public float GetFollowerWeight()
    {
        //return _followerSO.weight;
        return 0;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }
    /*
public Material defaultMat;
public Material selectedMat;
public Material inRangeMat;
public GroundDetection groundDetector;
public float distanceDown;
GameObject vehicle;

bool rambling;
private MeshRenderer meshRenderer;

void Start()
{
   meshRenderer = GetComponent<MeshRenderer>();
   groundDetector = GetComponentInChildren<GroundDetection>();
   distanceDown = 2.5f;
   rambling = false;

}

// Update is called once per frame
void Update()
{
   if (rambling)
   {
       transform.Rotate(new Vector3(1, 0, 0));
   }


}

public void Attach(GameObject vehicle)
{
   this.vehicle = vehicle;
   transform.SetParent(vehicle.transform);
   transform.localPosition = vehicle.GetComponent<Vehicle>().GetHitchPoint();
   transform.rotation = vehicle.transform.rotation;
   GetComponent<Rigidbody>().isKinematic = true;
}
public void Dettach()
{
   groundDetector.Deactivate();
   transform.parent = null;
   vehicle = null;
   GetComponent<Rigidbody>().isKinematic = false;
}

public void Select()
{
   GetComponent<Renderer>().material.shader = Shader.Find("Outlined/Uniform");
}

public void Unselect()
{
   GetComponent<Renderer>().material.shader = Shader.Find("Standard");

}

public void GetInRange()
{
   meshRenderer.material = inRangeMat;
}

public void GetOutOfRange()
{
   meshRenderer.material = defaultMat;
}

public void DeactivateGroundWorking(int secondsPullup)
{


   groundDetector.Deactivate();
   StartCoroutine(Ramble(secondsPullup));

   transform.position = new Vector3(transform.position.x, transform.position.y + distanceDown, transform.position.z);

}
public void ActivateGroundWorking()
{
   groundDetector.Activate();
   transform.position = new Vector3(transform.position.x, transform.position.y - distanceDown, transform.position.z);

}

public void WorkTile(Tile tile)
{
   tile.ChangeMaterial();
}

private IEnumerator Ramble(int seconds)
{
   rambling = true;
   yield return new WaitForSeconds(seconds);
   rambling = false;
   transform.rotation = vehicle.transform.rotation;
}

*/

}
