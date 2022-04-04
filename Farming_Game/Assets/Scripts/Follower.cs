using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour, ISelectable
{
    public Material defaultMat;
    public Material selectedMat;
    public Material inRangeMat;

    bool attached;
    GameObject vehicle;

    // Start is called before the first frame update

    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attached)
        {
            transform.position = vehicle.transform.position ;
            transform.rotation = vehicle.transform.rotation;
        }

    }

    public void Attach(GameObject vehicle)
    {        
        this.vehicle = vehicle;
        attached = true;
    }
    public void Dettach()
    {
        attached = false;
        vehicle = null;
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
}
