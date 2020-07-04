using Catan.Scripts.Card;
using Catan.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Manager
{

    public class CardConsumptionManeger : MonoBehaviour
    {
        public PlayerTurnManeger playerTurnManeger;
        public ToPleyerObject toPleyerObject;
        private void DeleteElement(GameObject p, CardType[] cost)
        {
            var c = p.GetComponent<Belongings>().cards;
            int check = 0;
            Debug.Log("DOODODO");
            for (int i = 0; i < c.Count; i++)
            {
                if (c[i].GetComponent<CardEntity>().cardType == cost[check])
                {
                    check++;
                    c.RemoveAt(i);
                    i = 0;
                    if (check == cost.Length)
                    {
                        break;
                    }
                    continue;
                }
            }
        }

        public void BuyRoad()
        {
            CardType[] cost = new CardType[] { CardType.Brick, CardType.Wood };
            var p = this.ToPlayer();
            DeleteElement(p, cost);

        }

        public void BuySettlement()
        {
            CardType[] cost = new CardType[] { CardType.Brick, CardType.Wood, CardType.Wheat, CardType.Wool };
            var p = this.ToPlayer();
            DeleteElement(p, cost);
        }

        public void BuyCity()
        {
            CardType[] cost = new CardType[] { CardType.Wheat, CardType.Wheat, CardType.IronOre, CardType.IronOre, CardType.IronOre };
            var p = this.ToPlayer();
            DeleteElement(p, cost);

        }

        public void BuyCard()
        {
            CardType[] cost = new CardType[] { CardType.IronOre, CardType.Wheat, CardType.Wool };
            var p = this.ToPlayer();
            DeleteElement(p, cost);

        }

        public GameObject ToPlayer()
        {
            var p = playerTurnManeger._currentPlayerId.Value;
            var t = toPleyerObject.ToPlayer(p);
            return t;
        }


    }


}