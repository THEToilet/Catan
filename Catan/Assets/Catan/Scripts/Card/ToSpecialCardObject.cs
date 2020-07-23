using UnityEngine;
using System;

namespace Catan.Scripts.Card
{
    /// <summary>
    /// 発展カードを返すクラス
    /// </summary>
    public class ToSpecialCardObject : MonoBehaviour
    {
        [SerializeField] GameObject KnightCard;
        [SerializeField] GameObject WiningCard;
        [SerializeField] GameObject RoadCard;
        [SerializeField] GameObject HarvestCard;
        [SerializeField] GameObject MonopolizationCard;
        public GameObject ToCard(int num)
        {
            switch (num)
            {
                case 0:
                    return KnightCard;
                case 1:
                    return WiningCard;
                case 2:
                    return RoadCard;
                case 3:
                    return HarvestCard;
                case 4:
                    return MonopolizationCard;
                default:
                    throw new ArgumentOutOfRangeException("num", num, null);
            }
        }
    }
}
