using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, ITile
{
    float sand;
    float nutrients;

    float water;

    public Material workedMaterial;
    private Renderer meshRenderer;
    private MaterialPropertyBlock mBlock;
    void Start()
    {
        meshRenderer = GetComponent<Renderer>();
        mBlock = new MaterialPropertyBlock();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Plow()
    {
        meshRenderer.GetPropertyBlock(mBlock);
        mBlock.SetFloat("Plow_grade", 1.0f);
        meshRenderer.SetPropertyBlock(mBlock);        
    }

    public void Plow(int degree)
    {
        meshRenderer.GetPropertyBlock(mBlock);
        mBlock.SetFloat("Plow_grade", 1.0f);
        mBlock.SetFloat("Plow_rotation", degree);
        meshRenderer.SetPropertyBlock(mBlock);        
    }
}
