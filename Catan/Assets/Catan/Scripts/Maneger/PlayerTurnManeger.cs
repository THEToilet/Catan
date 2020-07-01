using UnityEngine;
using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using Catan.Scripts.Player;
using Catan.Scripts.Presenter;
using System;
using Catan.Scripts.Territory;

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
        int cur = 0;
        private int state = 0;

        private void Start()
        {
            PlayerIdChangedAsync(this.GetCancellationTokenOnDestroy()).Forget();
            TurnStateChangedAsync(this.GetCancellationTokenOnDestroy()).Forget();
            CursoleAsync(this.GetCancellationTokenOnDestroy()).Forget();
            playerIds = new PlayerId[4] { PlayerId.Player1, PlayerId.Player2, PlayerId.Player3, PlayerId.Player4 };
            _currentPlayerId.SetValueAndForceNotify(playerIds[0]);
            _currentTurnState.SetValueAndForceNotify(TurnState.DescendingOrderArragement);
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
                uIRestrictionPresenter.ReleaseExpectAction();
                tableTopCardPresenter.DeleateCard(_currentPlayerId.Value);
                tableTopCardPresenter.CreateCard(_currentPlayerId.Value);
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
            var t = toPleyerObjects.ToPlayer(_currentPlayerId.Value).GetComponent<Belongings>().City;
            if (t.Count == 1)
            {
                roadBasePresenter.ShowAdjacentPoint(t[0].GetComponent<TerritoryEntity>().TerritoryPosition);
                pointChildrenPresenter.EraseAll();
            }


        }

        private async UniTaskVoid CursoleAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // ステート遷移を待つ
                var next = await _currentCursole;
                // 遷移先に合わせて処理をする
                if (_currentCursole.Value <= 4)
                {
                    if (toPleyerObjects.ToPlayer(_currentPlayerId.Value).GetComponent<Belongings>().City.Count >= 1 &&
                        toPleyerObjects.ToPlayer(_currentPlayerId.Value).GetComponent<Belongings>().Road.Count >= 1)
                    {
                    }
                    if (cur == 4) _currentTurnState.SetValueAndForceNotify(TurnState.AscendingOrderArrangement);
                }
                else if (cur <= 8)
                {
                    if (toPleyerObjects.ToPlayer(_currentPlayerId.Value).GetComponent<Belongings>().City.Count >= 2 &&
                        toPleyerObjects.ToPlayer(_currentPlayerId.Value).GetComponent<Belongings>().Road.Count >= 2)
                    {
                    }
                    if (cur == 8) _currentTurnState.SetValueAndForceNotify(TurnState.NormalTurn);
                }
                else
                {
                }
                _currentPlayerId.SetValueAndForceNotify(playerIds[_currentCursole.Value % 4]);

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
                        playerIds = orderDetermining.GetOrder();
                        playerNotificationPresenter.DisplayNote("Decend");
                        pointChildrenPresenter.ShowAll();
                        Debug.Log("Decend");
                        break;
                    case TurnState.AscendingOrderArrangement:
                        Array.Reverse(playerIds);
                        playerNotificationPresenter.DisplayNote("Accend");
                        uIRestrictionPresenter.Release();
                        Debug.Log("Accend");
                        break;
                    case TurnState.NormalTurn:
                        Array.Reverse(playerIds);
                        // カードを配る
                        playerNotificationPresenter.DisplayNote("NormalState");
                        Debug.Log("NormalState");
                        distributeCardManeger.InitDistribute();
                        break;
                }
            }
        }


    }
}