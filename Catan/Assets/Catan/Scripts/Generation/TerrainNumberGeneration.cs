using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Terrain;
using Catan.Scripts.Common;

namespace Catan.Scripts.Generation
{
    public class TerrainNumberGeneration : MonoBehaviour
    {
        public TerrainGeneration terrainGeneration;
        private int[] NumberToken;
        public void Distribution()
        {
            NumberToken = Dice.NumberToken();
            for (int i = 0; i < NumberToken.Length; i++)
            {
                Debug.Log(NumberToken[i]);
                terrainGeneration.terrainObjectCollections[i].GetComponent<TerrainBehavior>().tokenNumber = NumberToken[i];  // TerrainGameObjectのBehaviorに数字トークンを代入する
            }
        }
    }

}