using Catan.Scripts.Player;
using Catan.Scripts.Card;
using UnityEngine;

namespace Catan.Scripts.Manager
{
    /// <summary>
    /// 発展カードを手に入れるクラス
    /// </summary>

    public class DistributeDevelopmentCardManeger : MonoBehaviour
    {
        public ToSpecialCardObject toSpecialCardObject;
        public ToPleyerObject toPleyerObject;
        private int start = 0;
        private int end = 6;
        public void DrawCard(PlayerId playerId)
        {
            var tmp = toPleyerObject.ToPlayer(playerId).GetComponent<Belongings>().scards;
            var card = toSpecialCardObject.ToCard(Random.Range(start, end));
            tmp.Add(card);
        }
    }

}