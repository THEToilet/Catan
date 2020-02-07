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

    public ReactiveProperty<bool> winnerExist = new ReactiveProperty<bool>(false);

    public ReactiveProperty<int> winnerScore = new ReactiveProperty<int>(0);

    private PlayerId[] playerIds = { PlayerId.Player1, PlayerId.Player2, PlayerId.Player3, PlayerId.Player4 };
    public void Start()
    {
      // TODO このクラスでやりたかったことをRxでやる
      winnerScore.ObserveEveryValueChanged(_ => _.Value)
            .Where(x => x >= 10)
            .Subscribe(_ =>
                progressStateManeger._currentProgressState.SetValueAndForceNotify(ProgressState.Finished)
            );
    }

    public void Update()
    {
      VictoryPersonExists(); // playerに10点以上とった人がいるか判定
    }
    public async void Excute()
    {
      await playerTurn.DescendingOrderTurnState(); // ターン進行
      this.Excute();  // 繰り返し
    }
    private void VictoryPersonExists()  // 優勝者がいるまでまわす
    {
      for (int i = 0; i < 4; i++)
      {
        GameObject tmpGameObject = toPleyerObject.ToPlayer(playerIds[i]);
        // ここでplayerTurnをそれぞれのプレイヤーのスコアが10以上になるまで回す
        winnerScore = tmpGameObject.GetComponent<PlayerCore>().playerScore;
      }
    }
  }
}
