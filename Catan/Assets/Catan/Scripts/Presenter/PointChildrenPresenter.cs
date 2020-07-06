using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Generation;
using Catan.Scripts.Point;
using Catan.Scripts.Player;

namespace Catan.Scripts.Presenter
{

    public class PointChildrenPresenter : MonoBehaviour
    {
        public PointChildrenGeneration pointChildrenGeneration;
        public ToPleyerObject toPleyerObject;
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
            for (int i = 0; i < p.Count; i++)
            {
                if (!p[i].GetComponent<PointChildrenBehavior>().hasTerritory)
                {


                    var t = player.City;
                }
            }
        }
    }

}