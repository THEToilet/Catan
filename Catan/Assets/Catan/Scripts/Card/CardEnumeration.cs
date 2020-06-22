using Catan.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Card
{

    public class CardEnumeration : MonoBehaviour
    {
        public ToPleyerObject toPleyerObject;
        public  void Enumeration(PlayerId playerId)
        {
            var p = toPleyerObject.ToPlayer(playerId);
                        

        }
        
    }

}