﻿using UnityEngine;
using System.Collections.Generic;
using Catan.Scripts.Terrain;

namespace Catan.Scripts.Point
{
    public class PointParentBehavior : MonoBehaviour
    {
        public int tokenNumber;
        GameObject TerrainObject;
        public List<GameObject> childPointObjects = new List<GameObject>(6); 
    /*
        public GameObject childPoint_0;
        public GameObject childPoint_1;
        public GameObject childPoint_2;
        public GameObject childPoint_3;
        public GameObject childPoint_4;
        public GameObject childPoint_5;
     */
        public TerrainType terrainType;

        public bool hasThief;
    }

}
