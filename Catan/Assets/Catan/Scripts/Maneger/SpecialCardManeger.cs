using Catan.Scripts.Generation;
using Catan.Scripts.Presenter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using Catan.Scripts.Player;

namespace Catan.Scripts.Manager
{

    public class SpecialCardManeger : MonoBehaviour
    {

        public TheifManeger theifManeger;
        public RoadBasePresenter roadBasePresenter;
        public ToPleyerObject toPleyerObject;
        public PlayerTurnManeger playerTurnManeger;

        public void Knight()
        {
            Debug.Log("Knight");
            theifManeger.MoveTheif();
        }

        async public void MainRoad()
        {
            // 路を二つ置く
            Debug.Log("MainRoad");
            roadBasePresenter.ShowAll();
            var g = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
            int c = g.GetComponent<Belongings>().Road.Count;
            await CheckLocateRoad(c, g);
            roadBasePresenter.EraseAll();
            roadBasePresenter.ShowAll();
            await CheckLocateRoad(c, g);
            roadBasePresenter.EraseAll();

            CheckLocateRoad(0, g).Forget();
        }

        public void Harvest()
        {
            Debug.Log("Harvest");
            // HarveestPresenterに関数を作り使うカードを選ばせる
            // 資源カードを二枚もらえる
        }

        public void Monopolization()
        {
            Debug.Log("Monopolization");
            // HarveestPresenterに関数を作り使うカードを選ばせる
            // 指定した資源一種類全部もらえる
        }

        async UniTaskVoid CheckLocateRoad(int c, GameObject g)
        {
            await UniTask.WaitUntil(() => g.GetComponent<Belongings>().Road.Count > c);
        }


    }

}