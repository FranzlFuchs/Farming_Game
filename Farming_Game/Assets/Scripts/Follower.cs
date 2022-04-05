using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour, ISelectable
{
    public Material defaultMat;
    public Material selectedMat;
    public Material inRangeMat;
    public GroundDetection groundDetector;

    float distanceDown;


    bool attached;
    GameObject vehicle;

    // Start is called before the first frame update

    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        groundDetector = GetComponentInChildren<GroundDetection>();
        distanceDown = 2.5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (attached)
        {
            //transform.position = vehicle.transform.position;            
            //transform.rotation = vehicle.transform.rotation;
        }

    }

    public void Attach(GameObject vehicle)
    {
        this.vehicle = vehicle;
        transform.SetParent(vehicle.transform);
        transform.localPosition = vehicle.GetComponent<Vehicle>().GetHitchPoint();
        transform.rotation = vehicle.transform.rotation;
        GetComponent<Rigidbody>().isKinematic = true;
        attached = true;
    }
    public void Dettach()
    {
        groundDetector.Deactivate();
        //transform.position = new Vector3(transform.position.x, transform.position.y + distanceDown, transform.position.z);

        transform.parent = null;
        attached = false;
        vehicle = null;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public void Select()
    {
        meshRenderer.material = selectedMat;
    }

    public void Unselect()
    {
        meshRenderer.material = inRangeMat;
    }

    public void GetInRange()
    {
        meshRenderer.material = inRangeMat;
    }

    public void GetOutOfRange()
    {
        meshRenderer.material = defaultMat;
    }

    public void DeactivateGroundWorking()
    {
        groundDetector.Deactivate();
        transform.position = new Vector3(transform.position.x, transform.position.y + distanceDown, transform.position.z);

    }
    public void ActivateGroundWorking()
    {
        groundDetector.Activate();
        transform.position = new Vector3(transform.position.x, transform.position.y - distanceDown, transform.position.z);

    }

    public void WorkTile(Tile tile){
        tile.ChangeMaterial();
    }
}
