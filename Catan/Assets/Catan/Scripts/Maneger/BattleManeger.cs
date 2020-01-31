using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using Catan.Scripts.Player;

namespace Catan.Scripts.Manager
{
  public class BattleManeger : MonoBehaviour
  {
    public PlayerTurn playerTurn;
    public ProgressStateManeger progressStateManeger;
    public ToPleyerObject toPleyerObject;
    public GameObject winner;

    private PlayerId[] playerIds = { PlayerId.Player1, PlayerId.Player2, PlayerId.Player3, PlayerId.Player4 };

    private Boolean isWinnerPresent = false;

    public void Start()
    {
      // TODO このクラスでやりたかったことをRxでやる
    }
    public async void Excute()
    {
      VictoryPersonExists(); // playerに10点以上とった人がいるか判定
      await playerTurn.DescendingOrderTurnState(); // ターン進行


    }
    private void VictoryPersonExists()  // 優勝者がいるまでまわす
    {
      for (int i = 0; i < 4; i++)
      {
        GameObject tmpGameObject = toPleyerObject.ToPlayer(playerIds[i]);
        // ここでplayerTurnをそれぞれのプレイヤーのスコアが10以上になるまで回す
        if (tmpGameObject.GetComponent<PlayerCore>().playerScore >= 10)
        {
          isWinnerPresent = true;
          winner = tmpGameObject;
          progressStateManeger._currentProgressState.SetValueAndForceNotify(ProgressState.Finished);
        }
      }
    }
  }

}