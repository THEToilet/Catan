using Catan.Scripts.Point;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Terrain;
using Catan.Scripts.Theif;

namespace Catan.Scripts.Generation
{

    public class TheifGeneration : MonoBehaviour
    {
        [SerializeField] GameObject theifObject;
        public PointParentGeneration pointParentGeneration;
        public void Generate()
        {
            var p = pointParentGeneration.parentPointObjects;
            GameObject desertPosition = p[0];
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].GetComponent<PointParentBehavior>().terrainType == TerrainType.Desert)
                {
                    desertPosition = p[i];
                    break;
                }
            }
            GameObject.Instantiate(theifObject, new Vector3(desertPosition.transform.position.x, desertPosition.transform.position.y, desertPosition.transform.position.z), Quaternion.Euler(0, 0, 0));
            desertPosition.SetActive(true);
            theifObject.GetComponent<ThiefCore>().theifPosition = desertPosition;
        }
    }

}