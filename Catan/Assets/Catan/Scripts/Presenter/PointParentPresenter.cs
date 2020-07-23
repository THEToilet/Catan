using Catan.Scripts.Generation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Presenter
{
    public class PointParentPresenter : MonoBehaviour
    {
        public PointParentGeneration pointParentGeneration;

        public void ShowAll()
        {
            var p = pointParentGeneration.parentPointObjects;
            for (int i = 0; i < p.Count; i++)
            {
                p[i].SetActive(true);
            }
        }
        public void EraseAll()
        {
            var p = pointParentGeneration.parentPointObjects;
            for (int i = 0; i < p.Count; i++)
            {
                p[i].SetActive(false);
            }
        }
    }
}