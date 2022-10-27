using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FHitcher : MonoBehaviour, IFollowerHitcher
{

    private IFollower _follower;
    private bool _hitched = false;
    private bool _reHitchable = true;
    private VHitcher _vhitcher;
    private Rigidbody _rb;

    float _rehitchCooldown = 2.0f;
    void Start()
    {
        _follower = GetComponentInParent<IFollower>();
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (_hitched)
        {
            _rb.MovePosition(_vhitcher.transform.position);
            _rb.MovePosition(new Vector3(_vhitcher.transform.position.x, gameObject.transform.position.y, _vhitcher.transform.position.z));
            _rb.MoveRotation(_vhitcher.transform.rotation);
            //this.gameObject.transform.position = _vhitcher.transform.position;
            //this.gameObject.transform.eulerAngles = _vhitcher.transform.eulerAngles;
        }
    }
    public bool Hitch(VHitcher vhitcher)
    {
        if (!_hitched && _reHitchable)
        {
            _reHitchable = false;

            //Parenting umkehr damit Follower Hitcher folgt
            //this.gameObject.transform.parent = null;
            // _follower.GetGameObject().transform.parent = this.gameObject.transform;

            this._vhitcher = vhitcher;
            _hitched = true;
            // GetComponent<FixedJoint>().connectedBody = _vhitcher.GetComponent<Rigidbody>();


            return true;
        }

        return false;
    }

    public bool Unhitch()
    {

        //Parenting umkehr damit Hitcher Follower folgt
        //_follower.GetGameObject().transform.parent = null;
        //this.gameObject.transform.parent = _follower.GetGameObject().transform;
        this._vhitcher = null;
        _hitched = false;


        //COOLDOWN damit nicht instant wieder angehängt
        StartCoroutine(HitchCooldown());
        return true;



        //_follower.GetGameObject().GetComponent<Rigidbody>().AddForce( - _follower.GetGameObject().transform.forward * 2000, ForceMode.Impulse);

    }

    IEnumerator HitchCooldown()
    {
        yield return new WaitForSeconds(_rehitchCooldown);
        _reHitchable = true;
    }
}
