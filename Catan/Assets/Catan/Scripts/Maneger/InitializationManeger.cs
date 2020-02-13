using Catan.Scripts.Generation;
using UnityEngine;
using Catan.Scripts.Player;
using Catan.Scripts.Point;

namespace Catan.Scripts.Manager
{
    public class InitializationManeger : MonoBehaviour
    {
        public TerrainGeneration terrainGeneration;
        public RandomNoGeneration randomNoGeneration;
        public PlayerGeneration playerGeneration;
        public OrderDetermining orderDetermining;
        public ProgressStateManeger progressStateManeger;
        public PointChildrenGeneration pointChildrenGeneration;
        public PointParentGeneration pointParentGeneration;
        public RoadGeneration roadGeneration;
        public PlayerTurn playerTurn;
        public PointChildrenRelevanceSetting pointChildrenRelevanceSetting;
        public PointParentRelevanceSetting pointParentRelevanceSetting;
        public TerrainNumberGeneration terrainNumberGeneration;

        public async void Excute()
        {
            pointChildrenGeneration.Generate();  // 子の点生成
            pointParentGeneration.Generate();  // 親の点生成
            pointChildrenRelevanceSetting.Allocation(); // この点同士の連結設定
            pointParentRelevanceSetting.Allocation(); // 親がもつ子の点の設定
            roadGeneration.Generate();  // RoadBase生成
            terrainGeneration.Create(randomNoGeneration.Generate()); // 地形生成
            terrainNumberGeneration.Distribution(); // 数字トークン生成
            playerGeneration.Generate(); // プレイヤー生成
            orderDetermining.OrderDecide(); // 順番決定
            playerTurn.playerIds = orderDetermining.GetOrder(); // プレイヤーの順番取得
            await playerTurn.DescendingOrderTurnState(); //　初期配置降順
            await playerTurn.AscendingOrderTurnState(); // 初期配置昇順
            progressStateManeger._currentProgressState.
                SetValueAndForceNotify(ProgressState.Battle); // ゲームシーンをバトルへ
        }
    }

}