using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Generation;
using Catan.Scripts.Point;
using Catan.Scripts.Player;
using Catan.Scripts.Terrain;
using System.Linq;

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

        public void ShowPossiblePoint(PlayerId playerId)
        {
            var player = toPleyerObject.ToPlayer(playerId).GetComponent<Belongings>();
            var p = pointChildrenGeneration.childrenPointGameObjects;
            var b = roadGeneration.roads;
            List<GameObject> showPoint = new List<GameObject>();
            List<GameObject> hasPoint = new List<GameObject>();
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
                if (count == 3)
                {
                    showPoint.Add(p[i]);
                }
            }
            for (int i = 0; i < b.Count; i++)
            {
                var c = b[i].GetComponent<RoadBaseBehavior>().adjacentPointChildren;
                for (int j = 0; j < c.Count; j++)
                {
                    showPoint.Add(c[j]);
                    if (!CheckDuplication(showPoint))
                    {
                    }
                    else
                    {
                        hasPoint.Add(c[j]);
                    }
                }
            }
            for (int i = 0; i < hasPoint.Count; i++)
            {
                hasPoint[i].SetActive(true);
            }

        }

        bool CheckDuplication(List<GameObject> showPoint)
        {
            HashSet<string> hashSet = new HashSet<string>();

            foreach (var item in showPoint)
            {
                hashSet.Add(item.name);
            }

            //重複がある場合は要素数が減る
            if (showPoint.Count > hashSet.Count)
            {
                return false;
            }
            return true;
        }
    }

}