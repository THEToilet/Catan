using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Catan.Scripts.Manager;
using Catan.Scripts.Player;
using Catan.Scripts.Card;

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

        private void Start()
        {
            roadButton.interactable = false;
            settlementButton.interactable = false;
            cityButton.interactable = false;
            drawCardButton.interactable = false;

            submmitButton.OnClickAsObservable()
        .Subscribe(_ =>
        {
            tradeCardEnumeration.TableTopEnumeration();
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