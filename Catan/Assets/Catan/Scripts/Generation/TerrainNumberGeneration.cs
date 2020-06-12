using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Terrain;
using Catan.Scripts.Common;
using Catan.Scripts.Point;

namespace Catan.Scripts.Generation
{
    public class TerrainNumberGeneration : MonoBehaviour
    {
        public PointParentGeneration pointParentGeneration;
        private int[] NumberToken;
        public void Distribution()
        {
            NumberToken = Dice.NumberToken();
            for (int i = 0; i < NumberToken.Length; i++)
{
                Debug.Log(NumberToken[i]);
         //   Debug.Log( pointParentGeneration.parentPointObjects[i].GetComponent<PointParentBehavior>().tokenNumber);
               pointParentGeneration.parentPointObjects[i].GetComponent<PointParentBehavior>().tokenNumber = NumberToken[i];  // TerrainGameObjectのBehaviorに数字トークンを代入する
            }
        }
    }

}