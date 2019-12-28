using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Generation
{

    public class PointChildrenGeneration : MonoBehaviour
    {
        [SerializeField] GameObject childPoint;
        Vector3[] childPoints = new Vector3[]{
            new Vector3(-5,0,0),            // 0
            new Vector3(-2.5f,0,-5f),       // 1
            new Vector3(2.5f,0,-5f),        // 2
            new Vector3(5f,0,0),            // 3
            new Vector3(2.5f,0,5f),         // 4
            new Vector3(-2.5f,0,5f),        // 5
            new Vector3(5f,0,-10f),         // 6
            new Vector3(2.5f,0,-15f),       // 7
            new Vector3(-2.5f,0,-15f),      // 8
            new Vector3(-5f,0,-10f),        // 9
            new Vector3(-5f,0,10f),         // 10
            new Vector3(-2.5f,0,15f),       // 11
            new Vector3(2.5f,0,15),         // 12
            new Vector3(5f,0,10f),          // 13
            new Vector3(5f,0,-20f),         // 14
            new Vector3(2.5f,0,-25f),       // 15
            new Vector3(-2.5f,0,-25f),      // 16
            new Vector3(-5f,0,-20f),        // 17
            new Vector3(5f,0,-20f),         // 18
            new Vector3(2.5f,0,25f),        // 19
            new Vector3(-2.5f,0,25f),       // 20
            new Vector3(-5f,0,20f),         // 21
            new Vector3(-10f,0,-20f),       // 22
            new Vector3(-12.5f,0,-15f),     // 23
            new Vector3(-10f,0,-10f),       // 24
            new Vector3(-12.5f,0,-5f),      // 25
            new Vector3(-10f,0,0),          // 26
            new Vector3(-12.5f,0,5f),       // 27
            new Vector3(-10f,0,10f),        // 28
            new Vector3(-12.5f,0,15f),      // 29
            new Vector3(-10f,0,20f),        // 30
            new Vector3(10f,0,-20f),        // 31
            new Vector3(12.5f,0,-15f),      // 32
            new Vector3(10f,0,-10f),        // 33
            new Vector3(12.5f,0,-5f),       // 34
            new Vector3(10f,0,0),           // 35
            new Vector3(12.5f,0,5f),        // 36
            new Vector3(10f,0,10f),         // 37
            new Vector3(12.5f,0,15f),       // 38
            new Vector3(10f,0,20f),         // 39
            new Vector3(-17.5f,0,-15f),     // 40
            new Vector3(-20f,0,-10f),       // 41
            new Vector3(-17.5f,0,-5f),      // 42
            new Vector3(-20f,0,0),          // 43
            new Vector3(-17.5f,0,5f),        // 44
            new Vector3(-20f,0,10f),        // 45
            new Vector3(-17.5f,15f),        // 46
            new Vector3(17.5f,0,-15f),      // 47
            new Vector3(20f,0,-10f),        // 48
            new Vector3(17.5f,0,-5f),       // 49
            new Vector3(20f,0,0),           // 50
            new Vector3(17.5f,0,5f),        // 51
            new Vector3(20f,0,10f),         // 52
            new Vector3(17.5f,0,15f),       // 53
        };

        public void Generate()
        {
            GameObject tmpGameObject;
            for (int i = 0; i < childPoints.Length; i++)
            {
                tmpGameObject = GameObject.Instantiate(childPoint, childPoints[i], Quaternion.identity);
                tmpGameObject.name = "PointChild" + i;
            }
        }
    }

}