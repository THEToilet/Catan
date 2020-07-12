using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Generation;
using Catan.Scripts.Point;
using Catan.Scripts.Player;
using Catan.Scripts.Terrain;
using System.Linq;
using Catan.Scripts.Territory;

namespace Catan.Scripts.Presenter
{

    public class PointChildrenPresenter : MonoBehaviour
    {
        public PointChildrenGeneration pointChildrenGeneration;
        public ToPleyerObject toPleyerObject;
        public RoadGeneration roadGeneration;
        public void ShowAll()
        {
            var p = pointChildrenGeneration.childrenPointGameObjects;
            for (int i = 0; i < p.Count; i++)
            {
                if (!p[i].GetComponent<PointChildrenBehavior>().hasTerritory)
                {
                    p[i].SetActive(true);
                }
            }
        }

        public void EraseAll()
        {
            var p = pointChildrenGeneration.childrenPointGameObjects;
            for (int i = 0; i < p.Count; i++)
            {
                p[i].SetActive(false);
            }
        }

        // Settlement作成できる点表示

        public void ShowPossiblePoint(PlayerId playerId)
        {
            var player = toPleyerObject.ToPlayer(playerId).GetComponent<Belongings>();
            var p = pointChildrenGeneration.childrenPointGameObjects;
            List<GameObject> showPoint = new List<GameObject>();
            for (int i = 0; i < p.Count; i++)
            {
                var a = p[i].GetComponent<PointChildrenBehavior>().adjacentPoint;
                int count = 0;
                for (int j = 0; j < a.Count; j++)
                {
                    if (!a[j].GetComponent<PointChildrenBehavior>().hasTerritory)
                    {
                        count++;
                    }
                }
                if (count == a.Count)
                {
                    showPoint.Add(p[i]);
                }
            }
            for (int i = 0; i < showPoint.Count; i++)
            {
                showPoint[i].SetActive(true);
            }

        }
        public void ShowPossiblePlayerPoint(PlayerId playerId)
        {
            var player = toPleyerObject.ToPlayer(playerId).GetComponent<Belongings>();
            var p = pointChildrenGeneration.childrenPointGameObjects;
            List<GameObject> hasPoint = new List<GameObject>();
            for (int i = 0; i < player.Road.Count; i++)
            {
                var c = player.Road[i].GetComponent<TerritoryEntity>().TerritoryPosition.GetComponent<RoadBaseBehavior>().adjacentPointChildren;
                if (IsIndependence(c))
                {
                    hasPoint.Add(c[0]);
                    hasPoint.Add(c[1]);
                }
            }
            // Debug.Log("DEEEEEEEEEEEEEEEEEE" + hasPoint.Count);
            for (int i = 0; i < hasPoint.Count; i++)
            {
                var a = hasPoint[i].GetComponent<PointChildrenBehavior>().adjacentPoint;
                int count = 0;
                for (int j = 0; j < a.Count; j++)
                {
                    if (!a[j].GetComponent<PointChildrenBehavior>().hasTerritory)
                    {
                        count++;
                    }
                }
                if (count != a.Count)
                {
                    hasPoint.RemoveAt(i);
                    i = 0;
                }
            }
            for (int i = 0; i < hasPoint.Count; i++)
            {
                hasPoint[i].SetActive(true);
            }
        }

        bool IsIndependence(List<GameObject> c)
        {
            for (int j = 0; j < c.Count; j++)
            {
                if (c[j].GetComponent<PointChildrenBehavior>().hasTerritory)
                {
                    return false;
                }
            }
            return true;
        }

        public int GetShowPossiblePlayerPointNum(PlayerId playerId)
        {
            var player = toPleyerObject.ToPlayer(playerId).GetComponent<Belongings>();
            var p = pointChildrenGeneration.childrenPointGameObjects;
            List<GameObject> hasPoint = new List<GameObject>();
            for (int i = 0; i < player.Road.Count; i++)
            {
                var c = player.Road[i].GetComponent<TerritoryEntity>().TerritoryPosition.GetComponent<RoadBaseBehavior>().adjacentPointChildren;
                if (IsIndependence(c))
                {
                    hasPoint.Add(c[0]);
                    hasPoint.Add(c[1]);
                }
            }
            // Debug.Log("DEEEEEEEEEEEEEEEEEE" + hasPoint.Count);
            for (int i = 0; i < hasPoint.Count; i++)
            {
                var a = hasPoint[i].GetComponent<PointChildrenBehavior>().adjacentPoint;
                int count = 0;
                for (int j = 0; j < a.Count; j++)
                {
                    if (!a[j].GetComponent<PointChildrenBehavior>().hasTerritory)
                    {
                        count++;
                    }
                }
                if (count != a.Count)
                {
                    hasPoint.RemoveAt(i);
                    i = 0;
                }
            }
            return hasPoint.Count;
        }


    }

}