﻿using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Manager;
using Catan.Scripts.Common;
using UnityEditor.VersionControl;
using UniRx.Triggers;
using Catan.Scripts.Card;

namespace Catan.Scripts.Presenter
{
    public class ActionPresenter : MonoBehaviour
    {
        [SerializeField] private Button turnEndButton;
        [SerializeField] private Button rollDiceButton;


        [SerializeField] private Button useCardButton;

        [SerializeField] private Button negotiationButton;
        [SerializeField] Button submmitButton;

        public GameStateManeger gameStateManeger;
        public PlayerTurnManeger playerTurn;
        public DistributeCardManeger distributeCardManeger;
        public UIRestrictionPresenter uIRestrictionPresenter;
        public TradeCardEnumeration tradeCardEnumeration;
        [SerializeField] Button actionButton;
        [SerializeField] Button actionCancelButton;

        public DicePresenter dicePresenter;


        // Start is called before the first frame update
        void Start()
        {

            useCardButton.OnClickAsObservable()  // カードを使う　
            .Subscribe(_ =>
            {
                gameStateManeger._currentGameState
                    .SetValueAndForceNotify(GameState.UseCard);
            });

            negotiationButton.OnClickAsObservable()  // 交渉する
            .Subscribe(_ =>
            {
                gameStateManeger._currentGameState
                    .SetValueAndForceNotify(GameState.Negotiation);
            });

            turnEndButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                Debug.Log("ok");
                playerTurn._currentCursole.Value++;
            });

            rollDiceButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                uIRestrictionPresenter.TurnOffRollDice();
                var d = Dice.RandomRollTwiceDice();
                distributeCardManeger.Distribute(d[0] + d[1]);
                dicePresenter.ShowDiceNum(d[0] + d[1]);
                dicePresenter.ShowDice(d[0], d[1]);
            });

            submmitButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                tradeCardEnumeration.TableTopEnumeration();
            });

            actionButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                actionButton.gameObject.SetActive(false);
                actionCancelButton.gameObject.SetActive(true);
            });

            actionCancelButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                actionCancelButton.gameObject.SetActive(false);
                actionButton.gameObject.SetActive(true);
            });

        }
    }
}