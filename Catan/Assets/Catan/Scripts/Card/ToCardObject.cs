using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Terrain;
using System;

namespace Catan.Scripts.Card
{
    public class ToCardObject: MonoBehaviour
    {
        [SerializeField] GameObject BrickCard;
        [SerializeField] GameObject IronOreCard;
        [SerializeField] GameObject WheatCard;
        [SerializeField] GameObject WoodCard;
        [SerializeField] GameObject WoolCard;
        public GameObject ToCard(TerrainType tt)
        {
            switch (tt)
            {
                case TerrainType.Desert:
                    return BrickCard;
                case TerrainType.Mine:
                    return IronOreCard;
                case TerrainType.Hill:
                    return WheatCard;
                case TerrainType.Forest:
                    return WoodCard;
                case TerrainType.Pasture:
                    return WoolCard;
                default:
                    throw new ArgumentOutOfRangeException("tt", tt, null);
            }


        }

    }
}
