using UnityEngine;
using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using Catan.Scripts.Player;

namespace Catan.Scripts.Manager
{
  public class PlayerTurn : MonoBehaviour
  {
    public PlayerId[] playerIds;
    public PlayerMonitoring playerMonitoring;
    // ステート管理するReactiveProperty
    public ReactiveProperty<PlayerId> _currentPlayerId = new ReactiveProperty<PlayerId>();

    public bool isActive = false;

    private void Start()
    {
      StateChangedAsync(this.GetCancellationTokenOnDestroy()).Forget();
    }

    public async UniTask DescendingOrderTurnState() //　初期配置降順
    {
      for (int i = 0; i < 4; i++)
      {
        _currentPlayerId.SetValueAndForceNotify(playerIds[i]);
        await TurnUniTask();
      }
    }
    public async UniTask AscendingOrderTurnState() // 初期配置昇順
    {
      for (int i = 3; i >= 0; i--)
      {
        _currentPlayerId.SetValueAndForceNotify(playerIds[i]);
        await TurnUniTask();
      }
    }

    /// <summary>
    /// ステート遷移するたびに処理を走らせる
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
          case PlayerId.Player1:
            Debug.Log(1);
            playerMonitoring.Monitoring(PlayerId.Player1);
            break;
          case PlayerId.Player2:
            Debug.Log(2);
            playerMonitoring.Monitoring(PlayerId.Player2);
            break;
          case PlayerId.Player3:
            Debug.Log(3);
            playerMonitoring.Monitoring(PlayerId.Player3);
            break;
          case PlayerId.Player4:
            Debug.Log(4);
            playerMonitoring.Monitoring(PlayerId.Player4);
            break;
        }
      }
    }

    async UniTask TurnUniTask() // ここを初期化用として路と陣地がおかれたらに変更する
    {
      await UniTask.WaitUntil(() => this.isActive == true); // playerendボタンが押されるまで待機
      this.isActive = false;
    }


  }
}