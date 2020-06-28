using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Catan.Scripts.Card
{

    public class TradeCardEnumeration : MonoBehaviour
    {

        [SerializeField] GameObject tableTop;
        public List<GameObject> cards; 
        public void TableTopEnumeration()
        {
            cards = new List<GameObject>();
            foreach (Transform child in tableTop.transform)
            {
                cards.Add(child.gameObject);
            }
        }
    }

}