using Catan.Scripts.Player;
using UnityEngine;

namespace Catan.Scripts.Territory
{

    public class TerritoryEnumeration : MonoBehaviour
    {
        public ToPleyerObject toPleyerObject;

        public int[] Enmeration(PlayerId playerId)
        {
            int[] num = new int[] { 0, 0, 0 };
            var p = toPleyerObject.ToPlayer(playerId).GetComponent<Belongings>();

            for (int i = 0; i < p.City.Count; i++)
            {
                switch (p.City[i].GetComponent<TerritoryEntity>().territoryType)
                {
                    case (TerritoryType.City):
                        num[0]++;
                        break;
                    case (TerritoryType.Road):
                        num[1]++;
                        break;
                    case (TerritoryType.Settlement):
                        num[2]++;
                        break;
                    default:
                        break;
                }
            }
            return num;
        }
    }
}