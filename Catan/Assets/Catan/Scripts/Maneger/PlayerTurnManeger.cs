using UnityEngine;
using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using Catan.Scripts.Player;
using Catan.Scripts.Presenter;
using JetBrains.Annotations;
using System;

namespace Catan.Scripts.Manager
{
    public class PlayerTurnManeger : MonoBehaviour
    {
        public PlayerTurnUI playerTurnUI;
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
        private int cur = 0;
        private int state = 0;

        private void Start()
        {
            PlayerIdChangedAsync(this.GetCancellationTokenOnDestroy()).Forget();
            TurnStateChangedAsync(this.GetCancellationTokenOnDestroy()).Forget();
            playerIds = new PlayerId[4] { PlayerId.Player1, PlayerId.Player2, PlayerId.Player3, PlayerId.Player4 };
            _currentPlayerId.SetValueAndForceNotify(playerIds[0]);
            _currentTurnState.SetValueAndForceNotify(TurnState.RollDice);
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
                switch (next)
                {
                    // TODO: 通知する＞開拓地と路を一つずつ置く＞次の人＞反対からもう一回
                    case PlayerId.Player1:
                        Debug.Log(1);
                        playerTurnUI.DisplayPlayerName(PlayerId.Player1); // playerにターン開始を通知
                        break;
                    case PlayerId.Player2:
                        Debug.Log(2);
                        playerTurnUI.DisplayPlayerName(PlayerId.Player2);
                        break;
                    case PlayerId.Player3:
                        Debug.Log(3);
                        playerTurnUI.DisplayPlayerName(PlayerId.Player3);
                        break;
                    case PlayerId.Player4:
                        Debug.Log(4);
                        playerTurnUI.DisplayPlayerName(PlayerId.Player4);
                        break;
                }
            }
        }

        public void Next()
        {
            // Nextの処理
            if (cur <= 3)
            {
                cur++;
                if (cur == 3) _currentTurnState.SetValueAndForceNotify(TurnState.DescendingOrderArragement);
            }
            else if (cur <= 7)
            {
                cur++;
                if (cur == 7) _currentTurnState.SetValueAndForceNotify(TurnState.AscendingOrderArrangement);
            }
            else if (cur <= 11)
            {
                cur++;
                if (cur == 11) _currentTurnState.SetValueAndForceNotify(TurnState.RollDice);
                Debug.Log("うんこ");
            }
            else
            {
                cur++;
            }
            _currentPlayerId.SetValueAndForceNotify(playerIds[cur % 4]);
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
                    // TODO: 通知する＞開拓地と路を一つずつ置く＞次の人＞反対からもう一回
                    case TurnState.RollDice:
                        Debug.Log("RollDice");
                        break;
                    case TurnState.DescendingOrderArragement:
                        playerIds = orderDetermining.GetOrder();
                        Debug.Log("Decend");
                        break;
                    case TurnState.AscendingOrderArrangement:
                        Array.Reverse(playerIds);
                        Debug.Log("Accend");
                        break;
                    case TurnState.NormalTurn:
                        Array.Reverse(playerIds);
                        Debug.Log("NormalState");
                        break;
                }
            }
        }


    }
}