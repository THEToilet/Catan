using Catan.Scripts.Player;
using Catan.Scripts.Territory;
using UnityEngine;

namespace Catan.Scripts.Terrain
{
    public class CityKindsEnumeration : MonoBehaviour
    {
        public ToPleyerObject toPleyerObject;
        public int[] Enmeration(PlayerId playerId)
        {
            var p = toPleyerObject.ToPlayer(playerId);
            var c = p.GetComponent<Belongings>().City;
            int[] value = new int[] { 0, 0 };
            for (int i = 0; i < c.Count; i++)
            {
                if (c[i].GetComponent<TerritoryEntity>().territoryType == TerritoryType.City)
                {
                    value[1]++;
                }
                else
                {
                    value[0]++;
                }
            }
            return value;
        }
    }
}