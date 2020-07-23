using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Catan.Scripts.Common;

namespace Catan.Scripts.Player
{
    /// <summary>
    /// 順番生成クラス
    /// </summary>
    public class OrderDetermining : MonoBehaviour
    {
        public int[] orderNum = new int[4];

        private PlayerId[] playerNames = new PlayerId[] { PlayerId.Player1, PlayerId.Player2, PlayerId.Player3, PlayerId.Player4 };

        private PlayerId[] playerIds = new PlayerId[4];

        Dictionary<PlayerId, int> dic = new Dictionary<PlayerId, int>();

        // 取得した値をソート
        public void OrderDecide()
        {
            orderNum = Dice.RollTwiceDice();
            for (int i = 0; i < 4; i++)
            {
                dic.Add(playerNames[i], orderNum[i]);
            }

            // ソート済み
            var sortOrder = dic.OrderBy((x) => x.Value);
            int j = 0;
            foreach (var v in sortOrder)
            {
                playerIds[j] = v.Key;
                j++;
            }
        }

        public PlayerId[] GetOrder()
        {
            return playerIds;
        }
    }
}