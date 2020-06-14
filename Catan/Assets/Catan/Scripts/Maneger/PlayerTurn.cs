using UnityEngine;
using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using Catan.Scripts.Player;
using Catan.Scripts.Presenter;

namespace Catan.Scripts.Manager
{
  public class PlayerTurn : MonoBehaviour
  {
    public PlayerTurnUI playerTurnUI;
    public DicePresenter dicePresenter;
    public NortificationPresenter nortificationPresenter;
    public DistributeCardManeger distributeCardManeger;
    public PlayerMonitoring playerMonitoring;
    // ステート管理するReactiveProperty
    public ReactiveProperty<PlayerId> _currentPlayerId = new ReactiveProperty<PlayerId>();

    public ReactiveProperty<PlayerId> _normalCurrentPlayerId = new ReactiveProperty<PlayerId>();

    public bool isActive = false;

    private void Start()
    {
      StateChangedAsync(this.GetCancellationTokenOnDestroy()).Forget();
    }

    public async UniTask DescendingOrderTurnState(PlayerId[] playerIds) //　初期配置降順
    {
      for (int i = 0; i < 4; i++)
      {
        _currentPlayerId.SetValueAndForceNotify(playerIds[i]);
        await TurnUniTask(); // 陣地と路が置かれるるまで待つ
      }
    }
    public async UniTask AscendingOrderTurnState(PlayerId[] playerIds) // 初期配置昇順
    {
      for (int i = 3; i >= 0; i--)
      {
        _currentPlayerId.SetValueAndForceNotify(playerIds[i]);
        await TurnUniTask(); // 陣地と路が置かれるるまで待つ
        // distributeCardManager.Distribute2(point);
      }
    }

    public async UniTask NormalDescendingOrderTurnState() //　初期配置降順
    {
      for (int i = 0; i < 4; i++)
      {
       // _currentPlayerId.SetValueAndForceNotify(playerIds[i]);
        await TurnUniTask(); // サイコロが押されるまで待つ
        distributeCardManeger.Distribute(1);
      }
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

    /// <summary>
    /// ステート遷移するたびに処理を走らせる 通常ターンで使う
    async UniTask TurnUniTask() // TODO : ここを初期化用として路と陣地がおかれたらに変更する(別メソッドを作る)
    {
      await UniTask.WaitUntil(() => this.isActive == true); // playerendボタンが押されるまで待機
      this.isActive = false;
    }



  }
}