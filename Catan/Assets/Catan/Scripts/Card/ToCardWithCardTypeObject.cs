using UnityEngine;
using System;

namespace Catan.Scripts.Card
{
    /// <summary>
    /// カードの種類からカードを返すクラス
    /// </summary>
    public class ToCardWithCardTypeObject : MonoBehaviour
    {
        [SerializeField] GameObject BrickCard;
        [SerializeField] GameObject IronOreCard;
        [SerializeField] GameObject WheatCard;
        [SerializeField] GameObject WoodCard;
        [SerializeField] GameObject WoolCard;
        public GameObject ToCard(CardType ct)
        {
            switch (ct)
            {
                case CardType.Brick:
                    return BrickCard;
                case CardType.IronOre:
                    return IronOreCard;
                case CardType.Wheat:
                    return WheatCard;
                case CardType.Wood:
                    return WoodCard;
                case CardType.Wool:
                    return WoolCard;
                default:
                    throw new ArgumentOutOfRangeException("tt", ct, null);
            }
        }
    }
}
