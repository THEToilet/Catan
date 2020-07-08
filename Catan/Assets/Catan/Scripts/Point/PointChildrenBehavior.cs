using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Point
{
    public class PointChildrenBehavior : MonoBehaviour
    {
        [SerializeField] public int pointNumber;
        public GameObject AdjacentPoint_0;
        public GameObject AdjacentPoint_1;
        public GameObject AdjacentPoint_2;
        public List<GameObject> adjacentPoint = new List<GameObject>();
        public List<GameObject> adjacentRoadBase = new List<GameObject>(3);
        GameObject parent;
        GameObject terriory;
        public bool hasTerritory = false;

    }

}
