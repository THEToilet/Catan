using Catan.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
            
            /*
            for(int i = 0; i < p.City.Count; i++)
            {
                switch(p.City[i].)
            }

*/
            return num;


        }

    }


}