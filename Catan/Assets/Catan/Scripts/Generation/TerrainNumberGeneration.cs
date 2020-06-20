using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Terrain;
using Catan.Scripts.Common;
using Catan.Scripts.Point;
using ModestTree;

namespace Catan.Scripts.Generation
{
    public class TerrainNumberGeneration : MonoBehaviour
    {
        public PointParentGeneration pointParentGeneration;
        [SerializeField] GameObject numberToken;
        private int[] NumberToken;
        public void Distribution()
        {
            NumberToken = Dice.NumberToken();
            GameObject tmp;
            for (int i = 0; i < NumberToken.Length; i++)
            {
                var p = pointParentGeneration.parentPointObjects[i];
                Debug.Log(NumberToken[i]);
                p.GetComponent<PointParentBehavior>().tokenNumber = NumberToken[i];  // TerrainGameObjectのBehaviorに数字トークンを代入する
                tmp = GameObject.Instantiate(numberToken, new Vector3(p.transform.position.x, p.transform.position.y + 5f, p.transform.position.z), Quaternion.Euler(90, -90, 0)) ;
                tmp.GetComponent<TextMesh>().text = NumberToken[i].ToString();
            }
        }
    }

}