using Catan.Scripts.Manager;
using Catan.Scripts.Player;
using Catan.Scripts.Territory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Generation
{

    public class CityGeneration : MonoBehaviour
    {
        public PlayerTurnManeger playerTurnManeger;
        public ToPleyerObject toPleyerObject;
        public void Generation(int index)
        {
            var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
            var c = p.GetComponent<Belongings>().City;
            c[index].GetComponent<TerritoryEntity>().territoryType = TerritoryType.City;
        }
    }

}