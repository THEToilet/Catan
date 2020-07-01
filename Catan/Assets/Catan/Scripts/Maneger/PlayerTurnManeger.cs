using UnityEngine;
using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using Catan.Scripts.Player;
using Catan.Scripts.Presenter;
using System;
using Catan.Scripts.Territory;
using Zenject;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Catan.Scripts.Manager
{
    public class PlayerTurnManeger : MonoBehaviour
    {
        public PlayerNotificationPresenter playerNotificationPresenter;
        public ToPleyerObject toPleyerObjects;
        public DicePresenter dicePresenter;
        public NortificationPresenter nortificationPresenter;
        public DistributeCardManeger distributeCardManeger;
        public PlayerMonitoring playerMonitoring;
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
        public ReactiveProperty<int> _currentCursole = new ReactiveProperty<int>(0);
        public List<PlayerId> pIds = new List<PlayerId>();
        int cur = 0;
        private int state = 0;
        private bool isOK = false;

        private void Start()
        {
            PlayerIdChangedAsync(this.GetCancellationTokenOnDestroy()).Forget();
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
            pointChildrenPresenter.ShowAll();
            Debug.Log(";;");
            playerNotificationPresenter.DisplayPlayerName(_currentPlayerId.Value);
        }
        /// <summary>
        /// ステート遷移するたびに処理を走らせる 初期配置で使う
        /// </summary>
        private async UniTaskVoid PlayerIdChangedAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // ステート遷移を待つ
                var next = await _currentPlayerId;
                // 遷移先に合わせて処理をする
                if (_currentTurnState.Value == TurnState.NormalTurn)
                {
                    uIRestrictionPresenter.ReleaseExpectAction();
                    tableTopCardPresenter.DeleateCard(_currentPlayerId.Value);
                    tableTopCardPresenter.CreateCard(_currentPlayerId.Value);
                    roadBasePresenter.EraseAll();
                    pointChildrenPresenter.EraseAll();
                }
                else
                {
                    roadBasePresenter.EraseAll();
                    pointChildrenPresenter.ShowAll();
                }
                switch (next)
                {
                    // TODO: 通知する＞開拓地と路を一つずつ置く＞次の人＞反対からもう一回
                    case PlayerId.Player1:
                        Debug.Log(1);
                        playerNotificationPresenter.DisplayPlayerName(PlayerId.Player1); // playerにターン開始を通知
                        break;
                    case PlayerId.Player2:
                        Debug.Log(2);
                        playerNotificationPresenter.DisplayPlayerName(PlayerId.Player2);
                        break;
                    case PlayerId.Player3:
                        Debug.Log(3);
                        playerNotificationPresenter.DisplayPlayerName(PlayerId.Player3);
                        break;
                    case PlayerId.Player4:
                        Debug.Log(4);
                        playerNotificationPresenter.DisplayPlayerName(PlayerId.Player4);
                        break;
                }
            }
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
                        //Note();
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
                // 遷移先に合わせて処理をする
                if (_currentTurnState.Value != TurnState.NormalTurn && _currentCursole.Value <= 7)
                {
                    Debug.Log("Common");
                    _currentPlayerId.SetValueAndForceNotify(pIds[_currentCursole.Value]);
                }
                else
                {
                    Debug.Log("紙");
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
                        Debug.Log("Decend");
                        break;
                    case TurnState.AscendingOrderArrangement:
                        playerNotificationPresenter.DisplayNote("Accend");
                        Debug.Log("Accend");
                        break;
                    case TurnState.NormalTurn:
                        // カードを配る
                        roadBasePresenter.EraseAll();
                        pointChildrenPresenter.EraseAll();
                        uIRestrictionPresenter.Release();
                        playerNotificationPresenter.DisplayNote("NormalState");
                        Debug.Log("NormalState");
                        distributeCardManeger.InitDistribute();
                        break;
                }
            }
        }


    }
}