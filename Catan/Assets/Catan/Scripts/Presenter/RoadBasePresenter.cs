using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Generation;
using Catan.Scripts.Terrain;

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
    }

}