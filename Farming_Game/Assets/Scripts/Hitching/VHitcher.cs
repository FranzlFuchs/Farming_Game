using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
public class VHitcher : MonoBehaviour, IVehicleHitcher
{
    private IHitchee _parentVehicle;
    private IFollowerHitcher _fHitcher;
    private float _hitchedWeight;
    private bool _isHitched;

    [SerializeField] VHitcherType _type;

    void Start()
    {
        _parentVehicle = GetComponentInParent<IHitchee>();
    }

    public void Hitch()
    {
        //throw new System.NotImplementedException();
    }

    public void Unhitch()
    {
        //throw new System.NotImplementedException();
    }

    void Update()
    {
        if (_isHitched)
        {

            if (_type == VHitcherType.back)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _fHitcher.Unhitch();
                    //TROUBLES BEI FRONT BACK HITCHING
                    _parentVehicle.UnHitched();
                    _isHitched = false;
                }
            }

            if (_type == VHitcherType.front)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _fHitcher.Unhitch();
                    //TROUBLES BEI FRONT BACK HITCHING
                    _parentVehicle.UnHitched();
                    _isHitched = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (!_isHitched)
        {
            if (coll.gameObject.CompareTag("FHitcher"))
            {
                if (coll.gameObject.TryGetComponent<IFollowerHitcher>(out IFollowerHitcher fHitcher))
                {
                    if (fHitcher.Hitch(this))
                    {
                        _parentVehicle.Hitched(fHitcher);
                        _fHitcher = fHitcher;
                        _isHitched = true;
                    }
                }
            }
        }
    }
}
