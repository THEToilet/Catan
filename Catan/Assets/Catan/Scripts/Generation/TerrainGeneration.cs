using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Catan.Scripts.Point;
using Catan.Scripts.Terrain;

namespace Catan.Scripts.Generation
{

    public class TerrainGeneration : MonoBehaviour
    {
        private static int terrainNumber = 19;

        Vector3 terrainPosition;
        [SerializeField] GameObject Forest;
        [SerializeField] GameObject Hill;
        [SerializeField] GameObject Mine;
        [SerializeField] GameObject Pasture;
        [SerializeField] GameObject Field;
        [SerializeField] GameObject Desert;

        Vector3[] TerrainPoint = new Vector3[]{
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

        GameObject tmpGameObject;

        // Desert : 1 = 0, Mine : 3 = 1, Hill : 3 = 2, Pasture : 4 = 3, Field : 4 = 4, Forest : 4 = 5    --- Total 19
        public void Create(int[] terrainPointValue)
        {
            for (int i = 0; i < terrainNumber; i++)
            {
                terrainPosition = TerrainPoint[i];
                switch (terrainPointValue[i])
                {
                    case 0:
                        tmpGameObject = GameObject.Instantiate(Desert, terrainPosition, Quaternion.Euler(0, 30, 0));
                      //  tmpGameObject.GetComponent<PointParentBehavior>().terrainType = TerrainType.Desert;
                        break;
                    case 1:
                        tmpGameObject = GameObject.Instantiate(Mine, terrainPosition, Quaternion.Euler(0, 30, 0));
                      //  tmpGameObject.GetComponent<PointParentBehavior>().terrainType = TerrainType.Mine;
                        break;
                    case 2:
                        tmpGameObject = GameObject.Instantiate(Hill, terrainPosition, Quaternion.Euler(0, 30, 0));
                      //  tmpGameObject.GetComponent<PointParentBehavior>().terrainType = TerrainType.Hill;
                        break;
                    case 3:
                        tmpGameObject = GameObject.Instantiate(Pasture, terrainPosition, Quaternion.Euler(0, 30, 0));
                      //  tmpGameObject.GetComponent<PointParentBehavior>().terrainType = TerrainType.Pasture;
                        break;
                    case 4:
                        tmpGameObject = GameObject.Instantiate(Field, terrainPosition, Quaternion.Euler(0, 30, 0));
                      //  tmpGameObject.GetComponent<PointParentBehavior>().terrainType = TerrainType.Field;
                        break;
                    case 5:
                        tmpGameObject = GameObject.Instantiate(Forest, terrainPosition, Quaternion.Euler(0, 30, 0));
                       // tmpGameObject.GetComponent<PointParentBehavior>().terrainType = TerrainType.Forest;
                        break;
                }
            }
        }

    }
}