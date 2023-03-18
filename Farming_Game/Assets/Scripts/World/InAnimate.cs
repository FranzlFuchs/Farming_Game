using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class InAnimate : MonoBehaviour, IHitable
{
    [SerializeField]
    private HitAbleSO _HitAbleInfo;

    private float _health;

    void Start()
    {
        _health = _HitAbleInfo.HitPoints;
    }

    public void StartHitting(ITool tool)
    {
        _health -= tool.GetDamage() * _HitAbleInfo.HitTable[tool.GetToolType()];
    }

    public void StopHitting(ITool tool)
    {
    }


    // Update is called once per frame
    void Update()
    {
    }

    public void OnDeath()
    {
    }
}
