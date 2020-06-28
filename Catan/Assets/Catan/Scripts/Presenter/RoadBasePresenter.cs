using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Generation;
using Catan.Scripts.Terrain;
using Catan.Scripts.Point;

namespace Catan.Scripts.Presenter
{

    public class RoadBasePresenter : MonoBehaviour
    {
        public RoadGeneration roadGeneration; 
        public void ShowAll()
        {
            var r = roadGeneration.roads;
            for (int i = 0; i < r.Count; i++)
            {
                if (!r[i].GetComponent<RoadBaseBehavior>().hasTerritory)
                {
                    r[i].SetActive(true);
                }
            }

        }

        public void EraseAll()
        {
            var r = roadGeneration.roads;
            for(int i = 0; i < r.Count; i++)
            {
                r[i].SetActive(false);
            }

        }

        public void ShowAdjacentPoint(GameObject g)
        {
            var a1 = g.GetComponent<PointChildrenBehavior>().AdjacentPoint_0;
            var a2 = g.GetComponent<PointChildrenBehavior>().AdjacentPoint_1;
            var a3 = g.GetComponent<PointChildrenBehavior>().AdjacentPoint_2;

            a1.SetActive(true);
            a2.SetActive(true);
            a3.SetActive(true);

        }
        public void EraseAdjacentPoint(GameObject g)
        {
            var a1 = g.GetComponent<PointChildrenBehavior>().AdjacentPoint_0;
            var a2 = g.GetComponent<PointChildrenBehavior>().AdjacentPoint_1;
            var a3 = g.GetComponent<PointChildrenBehavior>().AdjacentPoint_2;

            a1.SetActive(false);
            a2.SetActive(false);
            a3.SetActive(false);

        }
    }

}