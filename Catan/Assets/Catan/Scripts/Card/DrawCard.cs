using Catan.Scripts.Manager;
using Catan.Scripts.Player;
using UnityEngine;

namespace Catan.Scripts.Card
{
    /// <summary>
    /// ランダムに資源カードを返してくれるクラス
    /// </summary>
    public class DrawCard : MonoBehaviour
    {
        public PlayerTurnManeger playerTurnManeger;
        public ToPleyerObject toPleyerObject;
        public ToSpecialCardObject toSpecialCardObject;
        public void Draw()
        {
            var r = Random.Range(0, 5);
            var p = playerTurnManeger._currentPlayerId.Value;
            toPleyerObject.ToPlayer(p).GetComponent<Belongings>().scards.Add(toSpecialCardObject.ToCard(r));
        }
    }
}