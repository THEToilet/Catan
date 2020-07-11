using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Player;
using UniRx;
using Catan.Scripts.Presenter;
using System.Linq;

namespace Catan.Scripts.Manager
{
    public struct playerI
    {
        public int point;
        public PlayerId p;
    }

    public class DeterminingTheWinnerManeger : MonoBehaviour
    {
        public PlayerTurnManeger playerTurnManeger;
        public ProgressStateManeger progressStateManeger;
        public ToPleyerObject toPleyerObject;
        public GameObject winner;
        public GameResultPresenter gameResultPresenter;

        private PlayerId[] playerIds = { PlayerId.Player1, PlayerId.Player2, PlayerId.Player3, PlayerId.Player4 };

        List<playerI> pI = new List<playerI>();

        public void Start()
        {
            // TODO このクラスでやりたかったことをRxでやる
            /*  winnerScore.ObserveEveryValueChanged(_ => _.Value)
                    .Where(x => x >= 10)
                    .Subscribe(_ =>
                        gameResultPresenter.Show())
                    );*/
        }

        private void Update()  // 優勝者がいるまでまわす
        {
            if (playerTurnManeger._currentTurnState.Value == TurnState.NormalTurn)
            {

                for (int i = 0; i < playerIds.Length; i++)
                {
                    var p = toPleyerObject.ToPlayer(playerIds[i]);
                    // ここでplayerTurnをそれぞれのプレイヤーのスコアが10以上になるまで回す
                    if (p.GetComponent<PlayerCore>().playerScore >= 10)
                    {
                        winner = p;
                        for (int j = 0; j < playerIds.Length; j++)
                        {
                            playerI s = new playerI() { point = p.GetComponent<PlayerCore>().playerScore, p = playerIds[j] };
                            pI.Add(s);
                        }
                        IOrderedEnumerable<playerI> player = pI.OrderByDescending(rec => rec.point);
                        gameResultPresenter.ShowGameResult(player);
                    }
                }
            }
        }
    }

}