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
        public void DeleteElement(GameObject p, CardType[] cost)
        {
            var c = p.GetComponent<Belongings>().cards;
            for (int i = 0; i < cost.Length; i++)
            {
                for (int j = 0; j < c.Count; j++)
                {
                    if (c[j].GetComponent<CardEntity>().cardType == cost[i])
                    {
                        c.RemoveAt(j);
                        break;
                    }
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

        public void DeleteCard(CardType[] cost)
        {
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