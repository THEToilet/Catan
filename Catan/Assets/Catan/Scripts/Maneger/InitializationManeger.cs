using System.Collections;
using System.Collections.Generic;
using Catan.Scripts.Generation;
using UnityEngine;
using UniRx.Async;
using UniRx.Async.Triggers;
using UniRx;
using Catan.Scripts.Player;

namespace Catan.Scripts.Manager
{

    public class InitializationManeger : MonoBehaviour
    {
        public TerrainGeneration terrainGeneration;
        public RandomNoGeneration randomNoGeneration;
        public PlayerGeneration playerGeneration;
        public OrderDetermining orderDetermining;
        public ProgressStateManeger progressStateManeger;
        public PlayerTurn playerTurn;

        public async void Excute()
        {
            terrainGeneration.Create(randomNoGeneration.Generate()); // 地形生成
            playerGeneration.Generate(); // プレイヤー生成
            orderDetermining.OrderDecide(); // 順番決定
            playerTurn.playerIds = orderDetermining.GetOrder(); // 順番取得
            await playerTurn.DescendingOrderTurnState(); //　初期配置降順
            await playerTurn.AscendingOrderTurnState(); // 初期配置昇順
            progressStateManeger._currentProgressState.SetValueAndForceNotify(ProgressState.Battle); // ゲームシーンをバトルへ
        }
    }

}