using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Catan.Scripts.Manager;
using Catan.Scripts.Player;
using Catan.Scripts.Card;
using UniRx;
using UnityEngine.PlayerLoop;

namespace Catan.Scripts.Presenter
{

    public class BuildUIPresenter : MonoBehaviour
    {

        [SerializeField] Button cityButton;
        [SerializeField] Button settlementButton;
        [SerializeField] Button roadButton;
        [SerializeField] Button drawCardButton;
        [SerializeField] Button actionButton;
        [SerializeField] Button actionCancelButton;
        public PlayerTurnManeger playerTurnManeger;
        public ToPleyerObject toPleyerObject;
        public CardEnumeration cardEnumeration;
        public CardConsumptionManeger cardConsumptionManeger;
        public DrawCard drawCard;
        public RoadBasePresenter roadBasePresenter;
        public PointChildrenPresenter pointChildrenPresenter;
        public UIRestrictionPresenter uIRestrictionPresenter;
        private bool isCheck = false;
        public int r, c;

        private void Start()
        {
            roadButton.interactable = false;
            settlementButton.interactable = false;
            cityButton.interactable = false;
            drawCardButton.interactable = false;

            roadButton.OnClickAsObservable()
        .Subscribe(_ =>
        {
            var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
            cardConsumptionManeger.BuyRoad();
            roadBasePresenter.ShowPossiblePoint(playerTurnManeger._currentPlayerId.Value);
            this.TurnOffAll();
            this.setCount(p);
            isCheck = true;
            uIRestrictionPresenter.TurnOffAll();
            Debug.Log("あ！");
        });
            settlementButton.OnClickAsObservable()
        .Subscribe(_ =>
        {
            var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
            cardConsumptionManeger.BuySettlement();
            pointChildrenPresenter.ShowPossiblePoint(playerTurnManeger._currentPlayerId.Value);
            this.TurnOffAll();
            this.setCount(p);
            isCheck = true;
            uIRestrictionPresenter.TurnOffAll();
            Debug.Log("い！");
        });
            cityButton.OnClickAsObservable()
        .Subscribe(_ =>
        {
            var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
            cardConsumptionManeger.BuyCity();
            pointChildrenPresenter.ShowPossiblePoint(playerTurnManeger._currentPlayerId.Value);
            this.TurnOffAll();
            this.setCount(p);
            isCheck = true;
            uIRestrictionPresenter.TurnOffAll();
            Debug.Log("う！");
        });
            drawCardButton.OnClickAsObservable()
        .Subscribe(_ =>
        {
            drawCard.Draw();
            cardConsumptionManeger.BuyCard();
            this.TurnOffAll();
            Debug.Log("お！");
        });
        }

        public void TurnOffAll()
        {
            drawCardButton.interactable = false;
            cityButton.interactable = false;
            settlementButton.interactable = false;
            roadButton.interactable = false;
            this.Reset();
        }

        public void Reset()
        {
            actionButton.gameObject.SetActive(true);
            actionCancelButton.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (playerTurnManeger._currentTurnState.Value == TurnState.NormalTurn)
            {
                var t = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
                var num = cardEnumeration.Enumeration(playerTurnManeger._currentPlayerId.Value);
                if (num[3] >= 1 && num[0] >= 1)
                {
                    roadButton.interactable = true;
                }
                if (num[3] >= 1 && num[0] >= 1 && num[2] >= 1 && num[4] >= 1)
                {
                    settlementButton.interactable = true;
                }
                if (num[2] >= 2 && num[1] >= 3)
                {
                    cityButton.interactable = true;
                }
                if (num[2] >= 1 && num[4] >= 1 && num[1] >= 1)
                {
                    drawCardButton.interactable = true;
                }
            }
            if (isCheck)
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>();
                var dr = p.Road.Count;
                var dc = p.City.Count;
                if (dr > r)
                {
                    isCheck = false;
                    uIRestrictionPresenter.Release();
                    roadBasePresenter.EraseAll();
                }
                if (dc > c)
                {
                    isCheck = false;
                    uIRestrictionPresenter.Release();
                    pointChildrenPresenter.EraseAll();
                }
            }

        }
        private void setCount(GameObject g)
        {
            r = g.GetComponent<Belongings>().Road.Count;
            c = g.GetComponent<Belongings>().City.Count;
        }

    }

}