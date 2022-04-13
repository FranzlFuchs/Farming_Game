using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    float sand;
    float nutrients;

    float water;

    public Material workedMaterial;
    private MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeMaterial()
    {
        meshRenderer.material = workedMaterial;
    }
}
