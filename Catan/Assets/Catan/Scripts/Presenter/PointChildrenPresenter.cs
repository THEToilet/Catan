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
                }
            }
            var list = FindDuplication(showPoint);
            for(int i = 0; i < list.Count; i++)
            {
                list[i].SetActive(true);
            }

        }

        /// <summary>
        /// 引数のリスト（何らかの名称のリスト）から、重複する要素を抽出する。
        /// </summary>
        /// <param name="list">何らかの名称のリスト。</param>
        /// <returns>重複している要素のリスト。</returns>
        public static List<GameObject> FindDuplication(List<GameObject> list)
        {
            // 要素名でGroupByした後、グループ内の件数が2以上（※重複あり）に絞り込み、
            // 最後にIGrouping.Keyからグループ化に使ったキーを抽出している。
            var duplicates = list.GroupBy(name => name).Where(name => name.Count() > 1)
                .Select(group => group.Key).ToList();

            return duplicates;
        }


        // 表示できる点があるか調査する
    }

}