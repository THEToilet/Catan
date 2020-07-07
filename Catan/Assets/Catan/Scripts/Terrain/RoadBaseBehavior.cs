using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Terrain
{
    public class RoadBaseBehavior : MonoBehaviour
    {
        public bool hasTerritory = false;
        public int angle;
        public List<GameObject> adjacentRoadBase = new List<GameObject>();
        public List<GameObject> adjacentPointChildren = new List<GameObject>();
    }

}