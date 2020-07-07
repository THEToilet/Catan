﻿using Catan.Scripts.Generation;
using UnityEngine;
using Catan.Scripts.Player;
using Catan.Scripts.Point;
using Catan.Scripts.Terrain;
using Catan.Scripts.Theif;

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
        public PointChildrenRelevanceSetting pointChildrenRelevanceSetting;
        public PointParentRelevanceSetting pointParentRelevanceSetting;
        public TerrainNumberGeneration terrainNumberGeneration;
        public RoadBaseRelevanceSetting roadBaseRelevanceSetting;
        public TheifGeneration theifGeneration;
        public RoadToChildrenRelevanceSetting roadToChildrenRelevanceSetting;
        public RoadBaseRoadRelevanceSetting roadBaseRoadRelevanceSetting;

        public void Excute()
        {
            pointChildrenGeneration.Generate();  // 子の点生成
            pointParentGeneration.Generate();  // 親の点生成
            pointChildrenRelevanceSetting.Allocation(); // この点同士の連結設定
            pointParentRelevanceSetting.Allocation(); // 親がもつ子の点の設定
            roadGeneration.Generate();  // RoadBase生成
            roadBaseRelevanceSetting.Allocation();  // 子と路の関連づけ
            terrainGeneration.Create(randomNoGeneration.Generate()); // 地形生成
            playerGeneration.Generate(); // プレイヤー生成
            orderDetermining.OrderDecide();　// 順番生成
            terrainNumberGeneration.Distribution(); // 数字トークン生成
            theifGeneration.Generate(); // 盗賊生成
            roadToChildrenRelevanceSetting.Allocation();
            roadBaseRoadRelevanceSetting.Allocation();
            Debug.Log("hello");
        }
    }

}