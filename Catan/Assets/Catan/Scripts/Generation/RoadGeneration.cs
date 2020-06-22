using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Generation
{

    public class RoadGeneration : MonoBehaviour
    {
        [SerializeField] GameObject roadBase;
        Vector3[] roadBasePositions = new Vector3[]{
            new Vector3(7.5f,0,0),            // 0
            new Vector3(-7.5f,0,0),       // 1
            new Vector3(0f,0,-5f),        // 2
            new Vector3(0,0,5f),            // 3
            new Vector3(15f,0,-5f),         // 4
            new Vector3(15f,0,5f),        // 5
          //  new Vector3(5f,0,-10f),         // 6
            new Vector3(-15f,0,-5f),       // 7
            new Vector3(-15f,0,5f),      // 8
            new Vector3(7.5f,0,-10f),        // 9
            new Vector3(-7.5f,0,10f),         // 10
            new Vector3(-7.5f,0,-10f),       // 11
            new Vector3(7.5f,0,10f),         // 12
            new Vector3(0,0,-15f),          // 13
            new Vector3(0,0,15f),         // 14
            new Vector3(0,0,-25f),       // 15
            new Vector3(0,0,25f),      // 16
            new Vector3(15f,0,15f),
            new Vector3(15f,0,-15f),
            new Vector3(7.5f,0,20f),
            new Vector3(7.5f,0,-20f),
            new Vector3(-15f,0,15f),
            new Vector3(-15f,0,-15f),
            new Vector3(-7.5f,0,20f),
            new Vector3(-7.5f,0,-20f),
            // rotation 120
            new Vector3(19f,0,-12.5f),        // 17
            new Vector3(19f,0,-2.5f),          // 18
          //  new Vector3(19f,0,25f),        // 19
            new Vector3(19f,0,7.5f),       // 20
            new Vector3(11.5f,0,-17.5f),         // 21
            new Vector3(11.5f,0,-7f),       // 22
            new Vector3(11.5f,0,2.5f),     // 23
            new Vector3(4.5f,0,-22.5f),      // 25
            new Vector3(4.5f,0,-12.5f),          // 26
            new Vector3(4.5f,0,-2.5f),       // 27
            new Vector3(4.5f,0,7.5f),        // 28
            new Vector3(4.5f,0,17.5f),      // 29
            new Vector3(-4.5f,0,22.5f),
            new Vector3(-3.5f,0,-17.5f),        // 30
            new Vector3(-3.5f,0,-7.5f),        // 31
            new Vector3(-3.5f,0,2.5f),      // 32
            new Vector3(-3.5f,0,12.5f),        // 33
            new Vector3(-11f,0,-12.5f),       // 34
            new Vector3(-11f,0,-2.5f),           // 35
            new Vector3(-11f,0,7.5f),        // 36
            new Vector3(-19f,0,-7.5f),         // 37
            new Vector3(-19f,0,2.5f),       // 38
            new Vector3(-19f,0,12.5f),         // 39
            new Vector3(-11f,0,17.5f),
            // rotation -120
            new Vector3(19f,0,12.5f),     // 40
            new Vector3(19f,0,2.5f),       // 41
            new Vector3(19f,0,-7.5f),      // 42
            new Vector3(11f,0,17.5f),          // 43
            new Vector3(11f,0,7.5f),       // 44
            new Vector3(11f,0,-2.5f),        // 45
            new Vector3(11f,0,12.5f),    // *  // 46
            new Vector3(4.5f,0,22.5f),      // 47
            new Vector3(4.5f,0,12.5f),        // 48
            new Vector3(4.5f,0,2.5f),       // 49
            new Vector3(4.5f,0,-7.5f),           // 50
            new Vector3(4.5f,0,-17.5f),        // 51
            new Vector3(-3.5f,0,17.5f),         // 52
            new Vector3(-3.5f,0,7.5f),       // 53
            new Vector3(-3.5f,0,-2.5f),       // 54
            new Vector3(-3.5f,0,-12.5f),           // 55
            new Vector3(-11f,0,12.5f),        // 56
            new Vector3(-11f,0,2.5f),         // 57
            new Vector3(-11f,0,-7.5f),       // 58
            new Vector3(-19f,0,7.5f),        // 59
            new Vector3(-19f,0,-2.5f),         // 60
            new Vector3(-19f,0,-12.5f),
            new Vector3(11.5f,0,-12.5f),        // 61
            new Vector3(-4.5f,0,-22.5f),
            new Vector3(-11f,0,-17.5f)
        };
        public List<GameObject> roads = new List<GameObject>();
        public void Generate()
        {
            GameObject tmpGameObject;
            for (int i = 0; i < roadBasePositions.Length; i++)
            {
                tmpGameObject = GameObject.Instantiate(roadBase, roadBasePositions[i], Quaternion.Euler(90,0,0));
                tmpGameObject.name = "RoadBase_" + i;
                roads.Add(tmpGameObject);
                tmpGameObject.SetActive(false);
            }
        }

    }
}