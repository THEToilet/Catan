using UnityEngine;
using Catan.Scripts.Generation;
using Catan.Scripts.Terrain;
using Catan.Scripts.Point;
using Catan.Scripts.Player;
using Catan.Scripts.Territory;

namespace Catan.Scripts.Presenter
{

    public class RoadBasePresenter : MonoBehaviour
    {
        public RoadGeneration roadGeneration;
        public ToPleyerObject toPleyerObject;
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
            for (int i = 0; i < r.Count; i++)
            {
                r[i].SetActive(false);
            }
        }

        public void ShowAdjacentPoint(GameObject g)
        {
            var a = g.GetComponent<PointChildrenBehavior>();
            for (int i = 0; i < a.adjacentRoadBase.Count; i++)
            {
                GameObject s = a.adjacentRoadBase[i];
                if (!s.GetComponent<RoadBaseBehavior>().hasTerritory)
                {
                    s.SetActive(true);
                }
            }
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
        public void ShowPossiblePoint(PlayerId playerId)
        {
            // 路の接点も表示する
            var p = toPleyerObject.ToPlayer(playerId).GetComponent<Belongings>();
            for (int i = 0; i < p.City.Count; i++)
            {
                var t = p.City[i].GetComponent<TerritoryEntity>().TerritoryPosition.GetComponent<PointChildrenBehavior>().adjacentRoadBase;
                for (int j = 0; j < t.Count; j++)
                {
                    if (!t[j].GetComponent<RoadBaseBehavior>().hasTerritory)
                    {
                        t[j].SetActive(true);
                    }
                }
            }
            for (int i = 0; i < p.Road.Count; i++)
            {
                var ad = p.Road[i].GetComponent<TerritoryEntity>().TerritoryPosition.GetComponent<RoadBaseBehavior>().adjacentRoadBase;
                for (int j = 0; j < ad.Count; j++)
                {
                    if (!ad[j].GetComponent<RoadBaseBehavior>().hasTerritory)
                    {
                        ad[j].SetActive(true);
                    }
                }
            }
        }
    }
}