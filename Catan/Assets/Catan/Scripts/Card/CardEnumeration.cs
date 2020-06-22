using Catan.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Card
{

    public class CardEnumeration : MonoBehaviour
    {
        public ToPleyerObject toPleyerObject;
        public int[] Enumeration(PlayerId playerId)
        {
            var p = toPleyerObject.ToPlayer(playerId).GetComponent<Belongings>();
            int[] num = new int[] { 0, 0, 0, 0, 0 };
            for(int i = 0; i < p.cards.Count; i++)
            {
                switch (p.cards[i].GetComponent<CardEntity>().cardType)
                {
                    case (CardType.Brick):
                        num[0]++;
                        break;
                    case (CardType.IronOre):
                        num[1]++;
                        break;
                    case (CardType.Wheat):
                        num[2]++;
                        break;
                    case (CardType.Wood):
                        num[3]++;
                        break;
                    case (CardType.Wool):
                        num[4]++;
                        break;
                    default:
                        break;
                }
            }
            return num;
                        

        }
        
    }

}