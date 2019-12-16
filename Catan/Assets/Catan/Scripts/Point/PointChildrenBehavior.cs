using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Point
{
   // [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    [System.Serializable]
    public class PointChildrenBehavior : MonoBehaviour
    {
        [SerializeField] public int pointNumber;
        [SerializeField] GameObject poimtObject;
        [SerializeField] GameObject AdjacentPoint_0;
        [SerializeField] GameObject AdjacentPoint_1;
        [SerializeField] GameObject AdjacentPoint_2;

    }

}
