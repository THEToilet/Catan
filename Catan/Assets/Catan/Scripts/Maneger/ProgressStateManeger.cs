﻿using UniRx;
using UnityEngine;
using System.Threading;
using UniRx.Async;
using UniRx.Async.Triggers;
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
        public PlayerTurnManeger playerTurn;

        // ステート管理するReactiveProperty
        public ReactiveProperty<ProgressState> _currentProgressState
            = new ReactiveProperty<ProgressState>();
        bool isFirst = true;

        void Start()
        {
            StateChangedAsync(this.GetCancellationTokenOnDestroy()).Forget();
            _currentProgressState.SetValueAndForceNotify(ProgressState.Initialization);
        }

        private void Update()
        {
            Debug.Log(_currentProgressState.Value);
            if (_currentProgressState.Value == ProgressState.Battle)
            {
                if (isFirst)
                {
                    playerTurn.Excute();
                    isFirst = false;
                }
            }
        }

        // TODO ここのReactivePropertyのバグ解決
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
                    case ProgressState.Initialization:
                        Debug.Log("ini");
                        initializationManeger.Excute();
                        _currentProgressState.SetValueAndForceNotify(ProgressState.Battle);
                        break;
                    case ProgressState.Battle:
                        Debug.Log("battle");
                        playerTurn.Excute();
                        break;
                }
            }
        }
    }
}