using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class InAnimate : MonoBehaviour, IHitable
{
    [SerializeField]
    private HitAbleSO _HitAbleInfo;

    [SerializeField]
    private float _health;

    private bool _isHit;

    void Start()
    {
        _isHit = false;
        _health = _HitAbleInfo.HitPoints;
    }

    public void StartHitting(ITool tool)
    {
        _isHit = true;
        if (_health > 0)
        {
            GetHit();
            //StartCoroutine(CountDownToHit());
        }
    }

    public void StopHitting(ITool tool)
    {
        _isHit = false;
    }

    void GetHit()
    {
        Debug.Log("HIT  HEALTH: " + _health);
        _health -= tool.GetDamage() * _HitAbleInfo[tool.GetToolType()];

        if (_health <= 0)
        {
            Break();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Break()
    {
        Debug.Log("BREAK");
    }

    void CountDownToHit()
    {
        yield return new WaitForSeconds(1);
        if (isHit)
        {
            GetHit();
            StartCoroutine(CountDownToHit());
        }
    }
}
