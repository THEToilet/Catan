using UnityEngine;
using Catan.Scripts.Terrain;

namespace Catan.Scripts.Point
{
   // [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    [System.Serializable]
    public class PointParentBehavior : MonoBehaviour
    {
        public int pointNumber;
        GameObject poimtObject;
        GameObject childPoint_0;
        GameObject childPoint_1;
        GameObject childPoint_2;
        GameObject childPoint_3;
        GameObject childPoint_4;
        GameObject childPoint_5;
        public TerrainType terrainType;
    }

}
