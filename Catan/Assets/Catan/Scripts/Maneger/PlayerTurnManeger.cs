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
    /// <summary>
    /// Battle時のクラス
    /// </summary>
    public class PlayerTurnManeger : MonoBehaviour
    {
        public PlayerNotificationPresenter playerNotificationPresenter;
        public ToPleyerObject toPleyerObjects;
        public DicePresenter dicePresenter;
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
        public SpecialCardPresenter specialCardPresenter;
        public ReactiveProperty<int> _currentCursole = new ReactiveProperty<int>(0);
        public List<PlayerId> pIds = new List<PlayerId>();
        private bool isSetUpComplete = false;

        private void Start()
        {
            TurnStateChangedAsync(this.GetCancellationTokenOnDestroy()).Forget();
            CursoleAsync(this.GetCancellationTokenOnDestroy()).Forget();
            uIRestrictionPresenter.TurnOffAll();
            playerIds = new PlayerId[4] { PlayerId.Player1, PlayerId.Player2, PlayerId.Player3, PlayerId.Player4 };
        }

        /// <summary>
        /// 初期設定
        /// </summary>
        public void Excute()
        {
            playerIds = orderDetermining.GetOrder();
            _currentTurnState.SetValueAndForceNotify(TurnState.DescendingOrderArragement);
            for (int i = 0; i < playerIds.Length; i++)
            {
                pIds.Add(playerIds[i]);
            }
            Array.Reverse(playerIds);
            for (int i = 0; i < playerIds.Length; i++)
            {
                pIds.Add(playerIds[i]);
            }
            Array.Reverse(playerIds);
            _currentPlayerId.SetValueAndForceNotify(pIds[0]);
            isSetUpComplete = true;
        }

        public void Note()
        {
            roadBasePresenter.EraseAll();
            pointChildrenPresenter.ShowPossiblePoint(_currentPlayerId.Value);
            playerNotificationPresenter.DisplayPlayerName(_currentPlayerId.Value);
        }

        /// <summary>
        /// playerの持っている路と陣地から次のターンに進むか判定
        /// </summary>
        private void Update()
        {
            if (progressStateManeger._currentProgressState.Value == ProgressState.Battle && isSetUpComplete)
            {
                var settlement = toPleyerObjects.ToPlayer(_currentPlayerId.Value).GetComponent<Belongings>().City;
                var road = toPleyerObjects.ToPlayer(_currentPlayerId.Value).GetComponent<Belongings>().Road;
                if (settlement.Count == 1 && _currentTurnState.Value != TurnState.NormalTurn && _currentTurnState.Value != TurnState.AscendingOrderArrangement)
                {
                    roadBasePresenter.ShowAdjacentPoint(settlement[0].GetComponent<TerritoryEntity>().TerritoryPosition);
                    pointChildrenPresenter.EraseAll();
                }

                if (road.Count == 1 && _currentTurnState.Value != TurnState.NormalTurn && _currentTurnState.Value != TurnState.AscendingOrderArrangement)
                {
                    _currentCursole.Value++;
                    if (_currentCursole.Value == 4)
                    {
                        _currentTurnState.SetValueAndForceNotify(TurnState.AscendingOrderArrangement);
                        Note();
                    }
                }
                if (settlement.Count == 2 && _currentTurnState.Value != TurnState.NormalTurn && _currentTurnState.Value != TurnState.DescendingOrderArragement)
                {
                    roadBasePresenter.ShowAdjacentPoint(settlement[1].GetComponent<TerritoryEntity>().TerritoryPosition);
                    pointChildrenPresenter.EraseAll();
                }
                if (road.Count == 2 && _currentTurnState.Value != TurnState.NormalTurn && _currentTurnState.Value != TurnState.DescendingOrderArragement)
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
                        pointChildrenPresenter.ShowAll();
                        break;
                    case TurnState.AscendingOrderArrangement:
                        break;
                    case TurnState.NormalTurn:
                        // カードを配る
                        roadBasePresenter.EraseAll();
                        pointChildrenPresenter.EraseAll();
                        uIRestrictionPresenter.LetRollDice();
                        distributeCardManeger.InitDistribute();
                        break;
                }
            }
        }
    }
}