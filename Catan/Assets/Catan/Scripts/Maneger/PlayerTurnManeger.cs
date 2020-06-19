using UnityEngine;
using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using Catan.Scripts.Player;
using Catan.Scripts.Presenter;

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
        public OrderDetermining orderDetermining;
        public PlayerId[] playerIds;
        private int cur = 0;
        private int state = 0;

        private void Start()
        {
            StateChangedAsync(this.GetCancellationTokenOnDestroy()).Forget();
            playerIds = new PlayerId[4] { PlayerId.Player1, PlayerId.Player2, PlayerId.Player3, PlayerId.Player4 };
            _currentPlayerId.SetValueAndForceNotify(playerIds[0]);
        }

        /// <summary>
        /// ステート遷移するたびに処理を走らせる 初期配置で使う
        /// </summary>
        private async UniTaskVoid StateChangedAsync(CancellationToken cancellationToken)
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

            if (state == 0 && cur <= 3)
            {
                cur++;
                if (cur == 3) state++;
            }
            else if (state == 1)
            {
                playerIds = orderDetermining.GetOrder();
                cur--;
                if (cur == 0) state++;
            }
            else if (state == 2)
            {
                Debug.Log("うんこ");
            }
            _currentPlayerId.SetValueAndForceNotify(playerIds[cur]);
        }


    }
}