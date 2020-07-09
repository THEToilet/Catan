using Boo.Lang.Environments;
using Catan.Scripts.Card;
using Catan.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Catan.Scripts.Manager
{

    public class MonopolizationManeger : MonoBehaviour
    {
        public PlayerTurnManeger playerTurnManeger;
        public CardEnumeration cardEnumeration;
        public CardConsumptionManeger cardConsumptionManeger;
        PlayerId[] playerIds = new PlayerId[] { PlayerId.Player1, PlayerId.Player2, PlayerId.Player3, PlayerId.Player4 };
        public ToCardWithCardTypeObject toCardWithCardTypeObject;
        public ToPleyerObject toPleyerObject;
        public void monopoly(CardType card)
        {
            int index = 0;
            switch (card)
            {
                case (CardType.Brick):
                    index = 0;
                    break;
                case (CardType.IronOre):
                    index = 1;
                    break;
                case (CardType.Wheat):
                    index = 2;
                    break;
                case (CardType.Wood):
                    index = 3;
                    break;
                case (CardType.Wool):
                    index = 4;
                    break;
                default:
                    break;
            }
            GetCard(CalcSumCard(index), card);
            DeleteUserCard(card, index);

        }


        // カードを指定枚数消してくれるメソッド


        public int CalcSumCard(int index)
        {
            int sum = 0;
            for (int i = 0; i < playerIds.Length; i++)
            {
                if (playerTurnManeger._currentPlayerId.Value != playerIds[i])
                {
                    var s = cardEnumeration.Enumeration(playerIds[i]);
                    sum += s[index];
                }
            }
            return sum;
        }


        public void GetCard(int sum, CardType card)
        {
            var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
            for (int i = 0; i < sum; i++)
            {
                p.GetComponent<Belongings>().cards.Add(toCardWithCardTypeObject.ToCard(card));
            }
        }

        public void DeleteUserCard(CardType card, int index)
        {
            for (int i = 0; i < playerIds.Length; i++)
            {
                if (playerTurnManeger._currentPlayerId.Value != playerIds[i])
                {
                    var p = toPleyerObject.ToPlayer(playerIds[i]);
                    var c = p.GetComponent<Belongings>().cards;
                    var playerHasCard = cardEnumeration.Enumeration(playerIds[i]);
                    while (playerHasCard[index] > 0)
                    {
                        for (int j = 0; j < c.Count; j++)
                        {
                            if (c[i].GetComponent<CardEntity>().cardType == card)
                            {
                                c.RemoveAt(i);
                            }
                        }

                    }
                }
            }

        }
    }

}