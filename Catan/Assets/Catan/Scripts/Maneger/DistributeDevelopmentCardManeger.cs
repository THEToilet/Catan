using Catan.Scripts.Player;
using Catan.Scripts.Card;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Manager
{

    public class DistributeDevelopmentCardManeger : MonoBehaviour
    {
        public ToSpecialCardObject toSpecialCardObject;
        public ToPleyerObject toPleyerObject;
        private int start = 0;
        private int end = 6;
        public void DrawCard(PlayerId playerId)
        {
            var tmp = toPleyerObject.ToPlayer(playerId).GetComponent<Belongings>().scards;
            // ここでコスト計算　if()
            tmp.Add(toSpecialCardObject.ToCard(Random.Range(start, end)));
        }
    }

}