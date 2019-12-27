using System.Collections;
using System.Collections.Generic;
using Catan.Scripts.Generation;
using UnityEngine;


namespace Catan.Scripts.Manager
{

    public class InitializationManeger : MonoBehaviour
    {
        public TerrainGeneration terrainGeneration;
        public RandomNoGeneration randomNoGeneration;
        public PlayerGeneration playerGeneration;

        public void Excute()
        {
            terrainGeneration.Create(randomNoGeneration.Generate()); // 地形生成
            playerGeneration.Generate(); // プレイヤー生成
        }
    }

}