using System.Collections;
using System.Collections.Generic;
using Enums;
using Interfaces;
using UnityEngine;

public interface ITool
{
    void PlaceInWorld();

    float GetDamage();

    ToolType GetToolType();

    void EquippedPlayer(Player player);

    void PositionInPlayerHand();

    void UnEquippedPlayer(Player player);

    void ChangeState(IState newState);

    //void Use(GameObject otherObject);
    bool IsEquipped();
}
