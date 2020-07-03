using Catan.Scripts.Manager;
using Catan.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Card
{

    public class DrawCard : MonoBehaviour
    {
        public PlayerTurnManeger playerTurnManeger;
        public ToPleyerObject toPleyerObject;
        public ToSpecialCardObject toSpecialCardObject;
        // Start is called before the first frame update
        public void Draw()
        {
            var r = Random.Range(0, 5);
            var p = playerTurnManeger._currentPlayerId.Value;
            toPleyerObject.ToPlayer(p).GetComponent<Belongings>().scards.Add(toSpecialCardObject.ToCard(r)); 
        }
    }

}