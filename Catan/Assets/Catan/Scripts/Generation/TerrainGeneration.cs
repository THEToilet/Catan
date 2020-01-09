using UnityEngine;
using System.Collections.Generic;
using Catan.Scripts.Point;
using Catan.Scripts.Terrain;

namespace Catan.Scripts.Generation
{
    public class TerrainGeneration : MonoBehaviour
    {
        private Vector3 tmpTerrainPosition;
        [SerializeField] private GameObject Forest;
        [SerializeField] private GameObject Hill;
        [SerializeField] private GameObject Mine;
        [SerializeField] private GameObject Pasture;
        [SerializeField] private GameObject Field;
        [SerializeField] private GameObject Desert;
        private GameObject tmpGameObject;
        public PointParentGeneration pointParentGeneration;

        public List<GameObject> teritorryObjectCollections = new List<GameObject>();

        // Desert : 1 = 0, Mine : 3 = 1, Hill : 3 = 2, Pasture : 4 = 3, Field : 4 = 4, Forest : 4 = 5    --- Total 19
        public void Create(int[] terrainPointValue)
        {
            for (int i = 0; i < 19; i++)
            {
                GameObject point = pointParentGeneration.parentPointObjects[i];
                tmpTerrainPosition = point.transform.position;
                switch (terrainPointValue[i])
                {
                    case 0:
                        tmpGameObject = GameObject.Instantiate(Desert, tmpTerrainPosition, Quaternion.Euler(0, 30, 0));
                        tmpGameObject.name = "Desert_" + i;
                        point.GetComponent<PointParentBehavior>().terrainType = TerrainType.Desert;
                        break;
                    case 1:
                        tmpGameObject = GameObject.Instantiate(Mine, tmpTerrainPosition, Quaternion.Euler(0, 30, 0));
                        tmpGameObject.name = "Mine_" + i;
                        point.GetComponent<PointParentBehavior>().terrainType = TerrainType.Mine;
                        break;
                    case 2:
                        tmpGameObject = GameObject.Instantiate(Hill, tmpTerrainPosition, Quaternion.Euler(0, 30, 0));
                        tmpGameObject.name = "Hill_" + i;
                        point.GetComponent<PointParentBehavior>().terrainType = TerrainType.Hill;
                        break;
                    case 3:
                        tmpGameObject = GameObject.Instantiate(Pasture, tmpTerrainPosition, Quaternion.Euler(0, 30, 0));
                        tmpGameObject.name = "Pasture_" + i;
                        point.GetComponent<PointParentBehavior>().terrainType = TerrainType.Pasture;
                        break;
                    case 4:
                        tmpGameObject = GameObject.Instantiate(Field, tmpTerrainPosition, Quaternion.Euler(0, 30, 0));
                        tmpGameObject.name = "Field_" + i;
                        point.GetComponent<PointParentBehavior>().terrainType = TerrainType.Field;
                        break;
                    case 5:
                        tmpGameObject = GameObject.Instantiate(Forest, tmpTerrainPosition, Quaternion.Euler(0, 30, 0));
                        tmpGameObject.name = "Forest_" + i;
                        point.GetComponent<PointParentBehavior>().terrainType = TerrainType.Forest;
                        break;
                }
                teritorryObjectCollections.Add(tmpGameObject);
            }
        }
    }
}