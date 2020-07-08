using Catan.Scripts.Presenter;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

namespace Catan.Scripts.Manager
{

    public class TheifManeger : MonoBehaviour
    {
        public UIRestrictionPresenter uIRestrictionPresenter;
        void ReduceCard()
        {
            // プレイヤーのカードが8枚以上だったら半分にする

        }
        
        public void MoveTheif()
        {
            uIRestrictionPresenter.TurnOffAll();
            // ここで処理
            uIRestrictionPresenter.Release();
        }


    }


}