using UnityEngine;
using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using Catan.Scripts.Player;
using Catan.Scripts.Presenter;
using System;
using Catan.Scripts.Territory;
using System.Collections.Generic;

namespace Catan.Scripts.Manager
{
    public class PlayerTurnManeger : MonoBehaviour
    {
        public PlayerNotificationPresenter playerNotificationPresenter;
        public ToPleyerObject toPleyerObjects;
        public DicePresenter dicePresenter;
        public NortificationPresenter nortificationPresenter;
        public DistributeCardManeger distributeCardManeger;
        public ProgressStateManeger progressStateManeger;
        // ステート管理するReactiveProperty
        public ReactiveProperty<PlayerId> _currentPlayerId = new ReactiveProperty<PlayerId>();
        public ReactiveProperty<TurnState> _currentTurnState = new ReactiveProperty<TurnState>();
        public OrderDetermining orderDetermining;
        public PlayerId[] playerIds;
        public UIRestrictionPresenter uIRestrictionPresenter;
        public RoadBasePresenter roadBasePresenter;
        public PointChildrenPresenter pointChildrenPresenter;
        public TableTopCardPresenter tableTopCardPresenter;
        public SpecialCardPresenter specialCardPresenter;
        public ReactiveProperty<int> _currentCursole = new ReactiveProperty<int>(0);
        public List<PlayerId> pIds = new List<PlayerId>();
        int cur = 0;
        private int state = 0;
        private bool isOK = false;

        private void Start()
        {
            TurnStateChangedAsync(this.GetCancellationTokenOnDestroy()).Forget();
            uIRestrictionPresenter.TurnOffAll();
            CursoleAsync(this.GetCancellationTokenOnDestroy()).Forget();
            playerIds = new PlayerId[4] { PlayerId.Player1, PlayerId.Player2, PlayerId.Player3, PlayerId.Player4 };
        }

        public void Excute()
        {
            Debug.Log("^_^");
            playerIds = orderDetermining.GetOrder();
            Debug.Log(playerIds);
            _currentTurnState.SetValueAndForceNotify(TurnState.DescendingOrderArragement);
            for (int i = 0; i < 4; i++)
            {
                pIds.Add(playerIds[i]);
            }
            Array.Reverse(playerIds);
            for (int i = 0; i < 4; i++)
            {
                pIds.Add(playerIds[i]);
            }
            Array.Reverse(playerIds);
            _currentPlayerId.SetValueAndForceNotify(pIds[0]);
            isOK = true;
        }

        public void Note()
        {
            roadBasePresenter.EraseAll();
            pointChildrenPresenter.ShowPossiblePoint(_currentPlayerId.Value);
            playerNotificationPresenter.DisplayPlayerName(_currentPlayerId.Value);
        }

        private void Update()
        {
            if (progressStateManeger._currentProgressState.Value == ProgressState.Battle && isOK)
            {
                var t = toPleyerObjects.ToPlayer(_currentPlayerId.Value).GetComponent<Belongings>().City;
                var s = toPleyerObjects.ToPlayer(_currentPlayerId.Value).GetComponent<Belongings>().Road;
                if (t.Count == 1 && _currentTurnState.Value != TurnState.NormalTurn && _currentTurnState.Value != TurnState.AscendingOrderArrangement)
                {
                    roadBasePresenter.ShowAdjacentPoint(t[0].GetComponent<TerritoryEntity>().TerritoryPosition);
                    pointChildrenPresenter.EraseAll();
                }

                if (s.Count == 1 && _currentTurnState.Value != TurnState.NormalTurn && _currentTurnState.Value != TurnState.AscendingOrderArrangement)
                {
                    _currentCursole.Value++;
                    if (_currentCursole.Value == 4)
                    {
                        _currentTurnState.SetValueAndForceNotify(TurnState.AscendingOrderArrangement);
                        Note();
                    }
                }
                if (t.Count == 2 && _currentTurnState.Value != TurnState.NormalTurn && _currentTurnState.Value != TurnState.DescendingOrderArragement)
                {
                    roadBasePresenter.ShowAdjacentPoint(t[1].GetComponent<TerritoryEntity>().TerritoryPosition);
                    pointChildrenPresenter.EraseAll();
                }
                if (s.Count == 2 && _currentTurnState.Value != TurnState.NormalTurn && _currentTurnState.Value != TurnState.DescendingOrderArragement)
                {
                    _currentCursole.Value++;
                    if (_currentCursole.Value == 8)
                    {
                        _currentTurnState.SetValueAndForceNotify(TurnState.NormalTurn);
                    }
                }

            }
        }

        private async UniTaskVoid CursoleAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // ステート遷移を待つ
                var next = await _currentCursole;
                if (_currentTurnState.Value != TurnState.NormalTurn && _currentCursole.Value <= 7)
                {
                    _currentPlayerId.SetValueAndForceNotify(pIds[_currentCursole.Value]);
                }
                else
                {
                    _currentPlayerId.SetValueAndForceNotify(playerIds[_currentCursole.Value % 4]);
                }
            }
        }

        /// <summary>
        /// ステート遷移するたびに処理を走らせる 初期配置で使う
        /// </summary>
        private async UniTaskVoid TurnStateChangedAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // ステート遷移を待つ
                var next = await _currentTurnState;
                // 遷移先に合わせて処理をする
                switch (next)
                {
                    case TurnState.DescendingOrderArragement:
                        playerNotificationPresenter.DisplayNote("Decend");
                        pointChildrenPresenter.ShowAll();
                        uIRestrictionPresenter.TurnOffAll();
                        break;
                    case TurnState.AscendingOrderArrangement:
                        playerNotificationPresenter.DisplayNote("Accend");
                        break;
                    case TurnState.NormalTurn:
                        // カードを配る
                        roadBasePresenter.EraseAll();
                        pointChildrenPresenter.EraseAll();
                        uIRestrictionPresenter.Release();
                        distributeCardManeger.InitDistribute();
                        playerNotificationPresenter.DisplayNote("NormalState");
                        break;
                }
            }
        }
    }
}