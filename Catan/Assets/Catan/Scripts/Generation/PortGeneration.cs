using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Generation
{
    public class PortGeneration : MonoBehaviour
    {
        [SerializeField] GameObject portGameObject;
        public List<GameObject> portObjectCollections = new List<GameObject>();
        // 3:1の点4つ
        // 2:1の点5つ　羊は二つ
        Vector3[] portPoints = new Vector3[]{
            new Vector3(22f,0,-4.5f),                // 0 brick
            new Vector3(14.5f,0,-18.5f),             // 1 wood
            new Vector3(-13.5f,0,-18.5f),             // 2 wool
            new Vector3(-21.5f,0,-4f),              // 3 ironore
            new Vector3(-7.5f,0,23.5f),               // 4 wool
            new Vector3(0,0,-28f),            // 5 3:1
            new Vector3(-21.5f,0,14.5f),           // 6 3:1
            new Vector3(7.5f,0,23.5f),          // 7 3:1
            new Vector3(21.5f,0,14.5f),           // 8 3:1
        };

        int[] rotate = new int[] { 45, 125, -125, -125, 0, -185, -54, 0, 45 };
        public void Generate()
        {
            GameObject tmpGameObject;
            for (int i = 0; i < portPoints.Length; i++)
            {
                tmpGameObject = GameObject.Instantiate(portGameObject, portPoints[i], Quaternion.Euler(90, rotate[i], 0));
                tmpGameObject.name = "PortGameObject_" + i;
                portObjectCollections.Add(tmpGameObject);
            }
        }
    }

}