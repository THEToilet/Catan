using Catan.Scripts.Point;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Terrain;
using Catan.Scripts.Theif;
using Catan.Scripts.Manager;

namespace Catan.Scripts.Generation
{

    public class TheifGeneration : MonoBehaviour
    {
        [SerializeField] GameObject theifObject;
        public PointParentGeneration pointParentGeneration;
        private GameObject theifLocatePoint;
        private GameObject theifInstitareObj;
        public TheifManeger theifManeger;
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
            theifInstitareObj = GameObject.Instantiate(theifObject, new Vector3(desertPosition.transform.position.x, desertPosition.transform.position.y, desertPosition.transform.position.z), Quaternion.Euler(0, 0, 0));
            desertPosition.SetActive(true);
            theifObject.GetComponent<ThiefCore>().theifPosition = desertPosition;
            theifLocatePoint = desertPosition;
        }

        public void Move(GameObject g)
        {
            theifLocatePoint.GetComponent<PointParentBehavior>().hasThief = false;
            GameObject.Destroy(theifInstitareObj);
            theifInstitareObj = GameObject.Instantiate(theifObject, g.transform.position, Quaternion.Euler(0, 0, 0));
            g.GetComponent<PointParentBehavior>().hasThief = true;
            theifLocatePoint = g;
            theifManeger.isPlace = true;
        }
    }

}