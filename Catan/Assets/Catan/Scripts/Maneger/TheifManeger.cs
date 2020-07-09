using Catan.Scripts.Generation;
using Catan.Scripts.Presenter;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.Experimental.XR.Interaction;

namespace Catan.Scripts.Manager
{

    public class TheifManeger : MonoBehaviour
    {
        public UIRestrictionPresenter uIRestrictionPresenter;
        public PointParentPresenter pointParentPresenter;
        public bool isPlace = false;
        void ReduceCard()
        {
            // プレイヤーのカードが8枚以上だったら半分にする

        }
        
        public void MoveTheif()
        {
            uIRestrictionPresenter.TurnOffAll();
            pointParentPresenter.ShowAll();
        }
        private void Update()
        {
            if (isPlace)
            {
                pointParentPresenter.EraseAll();
                uIRestrictionPresenter.Release();
                isPlace = false;
            }
            
        }
    }


}