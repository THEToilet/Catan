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
using Catan.Scripts.Card;

namespace Catan.Scripts.Manager
{

    public class SpecialCardManeger : MonoBehaviour
    {

        public TheifManeger theifManeger;
        public RoadBasePresenter roadBasePresenter;
        public ToPleyerObject toPleyerObject;
        public PlayerTurnManeger playerTurnManeger;
        public ResourceCardSelectionPresenter resourceCardSelectionPresenter;
        public ToCardObject toCardObject;
        public ToCardWithCardTypeObject toCardWithCardTypeObject;
        public MonopolizationManeger monopolizationManeger;
        public UIRestrictionPresenter uIRestrictionPresenter;
        public PlayerNotificationPresenter playerNotificationPresenter;

        public void Knight()
        {
            Debug.Log("Knight");
            playerNotificationPresenter.DisplayNote("Knight");
            theifManeger.MoveTheif();
        }

        async public void MainRoad()
        {
            // 路を二つ置く
            Debug.Log("MainRoad");
            playerNotificationPresenter.DisplayNote("MainRoad");
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

        async public void Harvest()
        {
            Debug.Log("Harvest");
            playerNotificationPresenter.DisplayNote("Harvest");
            // HarveestPresenterに関数を作り使うカードを選ばせる
            resourceCardSelectionPresenter.ShowPanel();
            await UniTask.WaitUntil(() => resourceCardSelectionPresenter.isPushed);
            resourceCardSelectionPresenter.ErasePanel();
            CardType r1 = resourceCardSelectionPresenter.GetResourceType();
            resourceCardSelectionPresenter.ShowPanel();
            await UniTask.WaitUntil(() => resourceCardSelectionPresenter.isPushed);
            resourceCardSelectionPresenter.ErasePanel();
            CardType r2 = resourceCardSelectionPresenter.GetResourceType();

            // 資源カードを二枚もらえる
            var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
            var c = gameObject.GetComponent<Belongings>().cards;
            c.Add(toCardWithCardTypeObject.ToCard(r1));
            c.Add(toCardWithCardTypeObject.ToCard(r2));


        }

        async public void Monopolization()
        {
            Debug.Log("Monopolization");
            playerNotificationPresenter.DisplayNote("Monopolization");
            // HarveestPresenterに関数を作り使うカードを選ばせる
            // 指定した資源一種類全部もらえる
            resourceCardSelectionPresenter.ShowPanel();
            await UniTask.WaitUntil(() => resourceCardSelectionPresenter.isPushed);
            resourceCardSelectionPresenter.ErasePanel();
            CardType r = resourceCardSelectionPresenter.GetResourceType();
            monopolizationManeger.monopoly(r);
        }

        async UniTaskVoid CheckLocateRoad(int c, GameObject g)
        {
            await UniTask.WaitUntil(() => g.GetComponent<Belongings>().Road.Count > c);
        }


    }

}