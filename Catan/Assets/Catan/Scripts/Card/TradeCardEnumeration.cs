using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Card
{
    /// <summary>
    /// tabletopにあるカードを返すクラス
    /// </summary>
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