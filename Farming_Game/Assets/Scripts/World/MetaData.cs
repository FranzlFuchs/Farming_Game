using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metadata : MonoBehaviour
{
    [SerializeField]
    private PlayerSO _playerInfo;

    public PlayerSO GetPlayerInfo()
    {
        return _playerInfo;
    }
}
