using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Terrain;
using System;

namespace Catan.Scripts.Card
{
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
