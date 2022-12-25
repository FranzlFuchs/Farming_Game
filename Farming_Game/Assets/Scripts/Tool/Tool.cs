using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Tool : MonoBehaviour, ITool
{
    public ToolSO ToolSO;

    private bool _isEquipped;

    private IState _currentState;

    private float _activationCooldown;


    public void ChangeState(IState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        newState.Enter();
    }

    public void Start()
    {
        _activationCooldown = 1.0f;
        _currentState = new TState_LayingAround(this);
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState.Update();
    }

    public void PlaceInWorld()
    {
        //gameObject.transform.eulerAngles.Set(0, 0, 90);

    }

    public void EquippedPlayer(Player player)
    {
        if (!_isEquipped)
        {
            _isEquipped = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Collider>().enabled = false;
            player.EquipTool(this.gameObject);
        }
    }

    public void UnEquippedPlayer(Player player)
    {
        StartCoroutine(ActivateCollider());
        player.UnEquipTool(this.gameObject);
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Collider>().enabled = true;
        //gameObject.GetComponent<Rigidbody>().AddForce(this.transform.up * 160, ForceMode.Impulse);
    }

    public void OnCollisionEnter(Collision coll)
    {
        _currentState.OnCollisionEnter(coll);
    }

    public void PositionInPlayerHand()
    {
        this.gameObject.transform.localPosition = ToolSO.PositionInHand;
        this.gameObject.transform.localEulerAngles = ToolSO.EulerAnglesInHand;
    }

    IEnumerator ActivateCollider()
    {
        yield return new WaitForSeconds(_activationCooldown);
        _isEquipped = false;

    }

    public bool IsEquipped()
    {
        return _isEquipped;
    }
}
