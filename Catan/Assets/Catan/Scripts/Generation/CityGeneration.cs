using Catan.Scripts.Manager;
using Catan.Scripts.Player;
using Catan.Scripts.Territory;
using UnityEngine;

namespace Catan.Scripts.Generation
{
    /// <summary>
    /// 都市生成クラス
    /// </summary>
    public class CityGeneration : MonoBehaviour
    {
        public PlayerTurnManeger playerTurnManeger;
        public ToPleyerObject toPleyerObject;
        public Mesh City;
        public void Generation(int index)
        {
            var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
            var c = p.GetComponent<Belongings>().City;
            c[index].GetComponent<TerritoryEntity>().territoryType = TerritoryType.City;
            c[index].GetComponent<MeshFilter>().mesh = City; // settlementのメッシュをcityメッシュに変更
        }
    }
}