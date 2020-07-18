using UnityEngine;
using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using Catan.Scripts.Player;
using Catan.Scripts.Manager;
using Catan.Scripts.Presenter;

namespace Catan.Scripts.Presenter
{

    public class GameProcessingPresenter : MonoBehaviour
    {
        public PointChildrenPresenter pointChildrenPresenter;
        public PlayerTurnManeger playerTurnManeger;
        public UIRestrictionPresenter uIRestrictionPresenter;
        public TableTopCardPresenter tableTopCardPresenter;
        public SpecialCardPresenter specialCardPresenter;
        public RoadBasePresenter roadBasePresenter;
        public PlayerNotificationPresenter playerNotificationPresenter;
        void Start()
        {
            PlayerIdChangedAsync(this.GetCancellationTokenOnDestroy()).Forget();
        }

        /// <summary>
        /// ステート遷移するたびに処理を走らせる 初期配置で使う
        /// </summary>
        private async UniTaskVoid PlayerIdChangedAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // ステート遷移を待つ
                var next = await playerTurnManeger._currentPlayerId;
                // 遷移先に合わせて処理をする
                if (playerTurnManeger._currentTurnState.Value == TurnState.NormalTurn)
                {
                    uIRestrictionPresenter.LetRollDice();
                    tableTopCardPresenter.DeleateCard();
                    tableTopCardPresenter.CreateCard(playerTurnManeger._currentPlayerId.Value);
                    specialCardPresenter.DeleateCard(playerTurnManeger._currentPlayerId.Value);
                    specialCardPresenter.CreateCard(playerTurnManeger._currentPlayerId.Value);
                    roadBasePresenter.EraseAll();
                    pointChildrenPresenter.EraseAll();
                }
                else
                {
                    roadBasePresenter.EraseAll();
                    pointChildrenPresenter.ShowPossiblePoint(playerTurnManeger._currentPlayerId.Value);
                }
                switch (next)
                {
                    case PlayerId.Player1:
                        playerNotificationPresenter.DisplayPlayerName(PlayerId.Player1); // playerにターン開始を通知
                        break;
                    case PlayerId.Player2:
                        playerNotificationPresenter.DisplayPlayerName(PlayerId.Player2);
                        break;
                    case PlayerId.Player3:
                        playerNotificationPresenter.DisplayPlayerName(PlayerId.Player3);
                        break;
                    case PlayerId.Player4:
                        playerNotificationPresenter.DisplayPlayerName(PlayerId.Player4);
                        break;
                }
            }
        }
    }

}