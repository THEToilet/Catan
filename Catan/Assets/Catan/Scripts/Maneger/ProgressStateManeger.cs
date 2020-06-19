using System;
using UniRx;
using UnityEngine;
using UniRx.Async;
using UniRx.Async.Triggers;
using System.Threading;
using Catan.Scripts.Player;

/// <summary>
/// 全体の進行の管理
/// </summary>

namespace Catan.Scripts.Manager
{
    public class ProgressStateManeger : MonoBehaviour
    {
        public InitializationManeger initializationManeger;
        public OrderDetermining orderDetermining;
        public BattleManeger battleManeger;
        public PlayerTurn playerTurn;
        public PlayerId[] playerIds;

        // ステート管理するReactiveProperty
        public ReactiveProperty<ProgressState> _currentProgressState
            = new ReactiveProperty<ProgressState>(ProgressState.Title);

        void Start()
        {
            StateChangedAsync(this.GetCancellationTokenOnDestroy()).Forget();
            _currentProgressState.SetValueAndForceNotify(ProgressState.Initialization);
        }

        /// <summary>
        /// ステート遷移するたびに処理を走らせる
        /// </summary>
        private async UniTaskVoid StateChangedAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // ステート遷移を待つ
                var next = await _currentProgressState;

                // 遷移先に合わせて処理をする
                switch (next)
                {
                    case ProgressState.Maching:
                        break;
                    case ProgressState.Initialization:
                        Debug.Log("ini");
                        initializationManeger.Excute();
                        playerIds = orderDetermining.GetOrder(); // プレイヤーの順番取得
                       // await playerTurn.DescendingOrderTurnState(playerIds); //　サイコロ振る
                       //  await playerTurn.DescendingOrderTurnState(playerIds); //　初期配置降順
                      //  await playerTurn.AscendingOrderTurnState(playerIds); // 初期配置昇順
                      //  this._currentProgressState.SetValueAndForceNotify(ProgressState.Battle); // ゲームシーンをバトルへ
                        break;
                    case ProgressState.Battle:
                        Debug.Log("battle");
                     //   playerTurn.AscendingOrderTurnState(playerIds); // バトル開始
                        battleManeger.Excute();
                        break;
                    case ProgressState.Finished:
                        Debug.Log("Finished");
                        break;
                    case ProgressState.Result:
                        Debug.Log("Result");
                        break;
                }
            }

        }
    }
}