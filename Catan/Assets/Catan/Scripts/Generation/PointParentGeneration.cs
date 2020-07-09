using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Generation
{

    public class PointParentGeneration : MonoBehaviour
    {
        [SerializeField] GameObject parentPoint;
        public List<GameObject> parentPointObjects = new List<GameObject>();
        Vector3[] parentPoints = new Vector3[]{
            new Vector3(0,0,0),                // 0
            new Vector3(0,0,-10f),             // 1
            new Vector3(0,0,-20f),             // 2
            new Vector3(0,0,10f),              // 3
            new Vector3(0,0,20),               // 4
            new Vector3(7.5f,0,5f),            // 5
            new Vector3(7.5f,0,-5f),           // 6
            new Vector3(-7.5f,0,-5f),          // 7
            new Vector3(-7.5f,0,5f),           // 8
            new Vector3(15f,0,0),              // 9
            new Vector3(-15f,0,0),             // 10
            new Vector3(-7.5f,0,-15f),         // 11
            new Vector3(-7.5f,0,15),           // 12
            new Vector3(7.5f,0,-15f),          // 13
            new Vector3(7.5f,0,15f),           // 14
            new Vector3(-15f,0,-10f),          // 15
            new Vector3(-15f,0,10f),           // 16
            new Vector3(15f,0,-10f),           // 17
            new Vector3(15f,0,10f)             // 18
        };

        public void Generate()
        {
            GameObject tmpGameObject;
            for (int i = 0; i < parentPoints.Length; i++)
            {
                tmpGameObject = GameObject.Instantiate(parentPoint, parentPoints[i], Quaternion.Euler(90, 0, 0));
                tmpGameObject.name = "PointParent_" + i;
                parentPointObjects.Add(tmpGameObject);
                tmpGameObject.SetActive(false);


            }
        }
    }

}