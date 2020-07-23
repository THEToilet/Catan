using UnityEngine;
using System.Collections.Generic;
using Catan.Scripts.Terrain;

namespace Catan.Scripts.Point
{
    public class PointParentBehavior : MonoBehaviour
    {
        public int tokenNumber;
        GameObject TerrainObject;
        public List<GameObject> childPointObjects = new List<GameObject>(6);
        public TerrainType terrainType;
        public bool hasThief;
    }
}
