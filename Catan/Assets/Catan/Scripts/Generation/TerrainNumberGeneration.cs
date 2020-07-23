using UnityEngine;
using Catan.Scripts.Terrain;
using Catan.Scripts.Common;
using Catan.Scripts.Point;

namespace Catan.Scripts.Generation
{
    /// <summary>
    /// ナンバートークン生成クラス
    /// </summary>
    public class TerrainNumberGeneration : MonoBehaviour
    {
        public PointParentGeneration pointParentGeneration;
        [SerializeField] GameObject numberTokenObject;
        private int[] NumberToken;
        public void Distribution()
        {
            NumberToken = Dice.NumberToken();
            GameObject tmp;
            var p = pointParentGeneration.parentPointObjects;
            int cur = 0;
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].GetComponent<PointParentBehavior>().terrainType == TerrainType.Desert)
                {
                    p[i].GetComponent<PointParentBehavior>().tokenNumber = 7;
                    tmp = GameObject.Instantiate(numberTokenObject, new Vector3(p[i].transform.position.x + 2f, p[i].transform.position.y + 5f, p[i].transform.position.z - 1f), Quaternion.Euler(90, -90, 0));
                    tmp.GetComponent<TextMesh>().text = " 7";
                }
                else
                {
                    p[i].GetComponent<PointParentBehavior>().tokenNumber = NumberToken[cur];  // TerrainGameObjectのBehaviorに数字トークンを代入する
                    tmp = GameObject.Instantiate(numberTokenObject, new Vector3(p[i].transform.position.x + 2f, p[i].transform.position.y + 5f, p[i].transform.position.z - 1f), Quaternion.Euler(90, -90, 0));
                    tmp.GetComponent<TextMesh>().text = NumberToken[cur].ToString();
                    cur++;
                }
            }
        }
    }
}