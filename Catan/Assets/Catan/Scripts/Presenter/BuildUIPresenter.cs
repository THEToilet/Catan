﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Catan.Scripts.Manager;
using Catan.Scripts.Player;
using Catan.Scripts.Card;
using UniRx;

namespace Catan.Scripts.Presenter
{

    public class BuildUIPresenter : MonoBehaviour
    {

        [SerializeField] Button cityButton;
        [SerializeField] Button settlementButton;
        [SerializeField] Button roadButton;
        [SerializeField] Button drawCardButton;
        public PlayerTurnManeger playerTurnManeger;
        public ToPleyerObject toPleyerObject;
        public CardEnumeration cardEnumeration;
        public CardConsumptionManeger cardConsumptionManeger;
        public DrawCard drawCard;
        public RoadBasePresenter roadBasePresenter;

        private void Start()
        {
            roadButton.interactable = false;
            settlementButton.interactable = false;
            cityButton.interactable = false;
            drawCardButton.interactable = false;

            roadButton.OnClickAsObservable()
        .Subscribe(_ =>
        {
            cardConsumptionManeger.BuyRoad();
            roadBasePresenter.ShowPossiblePoint(playerTurnManeger._currentPlayerId.Value);
            Debug.Log("あ！");
        });
            settlementButton.OnClickAsObservable()
        .Subscribe(_ =>
        {
            cardConsumptionManeger.BuySettlement();
            Debug.Log("い！");
        });
            cityButton.OnClickAsObservable()
        .Subscribe(_ =>
        {
            cardConsumptionManeger.BuyCity();
            Debug.Log("う！");
        });
            drawCardButton.OnClickAsObservable()
        .Subscribe(_ =>
        {
            drawCard.Draw();
            cardConsumptionManeger.BuyCard();
            Debug.Log("お！");
        });
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
                if (num[3] >= 1 && num[0] >= 1 && num[2] >= 1 && num[4] >= 4)
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
        }

    }

}