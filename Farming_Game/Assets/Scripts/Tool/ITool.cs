using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public interface ITool
{
   void PlaceInWorld();
   void EquippedPlayer(Player player);
   void PositionInPlayerHand();
   void UnEquippedPlayer(Player player);

   void ChangeState(IState newState);
   bool IsEquipped();
      
}
