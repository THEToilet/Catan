using Catan.Scripts.Card;
using Catan.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Presenter
{
    public class TableTopCardPresenter : MonoBehaviour
    {
        [SerializeField] GameObject TableTop;
        [SerializeField] GameObject TableTop2;
        [SerializeField] GameObject Hand;
        [SerializeField] GameObject Hand2;
        public ToPleyerObject toPleyerObject;
        public ToCardObject toCardObject;
        public void CreateCard(PlayerId playerId)
        {
            // 生成
            var p = toPleyerObject.ToPlayer(playerId);
            foreach (GameObject g in p.GetComponent<Belongings>().cards)
            {
                GameObject tmpObject = GameObject.Instantiate(g, this.transform.position, Quaternion.identity);
                tmpObject.transform.SetParent(Hand.transform);
            }
        }
        public void CreateCard2(PlayerId playerId)
        {
            // 生成
            var p = toPleyerObject.ToPlayer(playerId);
            foreach (GameObject g in p.GetComponent<Belongings>().cards)
            {
                GameObject tmpObject = GameObject.Instantiate(g, this.transform.position, Quaternion.identity);
                tmpObject.transform.SetParent(Hand2.transform);
            }
        }

        public void DeleateCard()
        {
            // 取得
            foreach (Transform n in TableTop.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
            foreach (Transform n in Hand.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
        }
        public void DeleateCard2()
        {
            // 取得
            foreach (Transform n in TableTop2.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
            foreach (Transform n in Hand2.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
        }

        public CardType[] GetTableTopCard()
        {
            int cardsNumber = 0;
            foreach (Transform n in TableTop.transform)
            {
                cardsNumber++;
            }
            CardType[] cards = new CardType[cardsNumber];
            int i = 0;
            foreach (Transform n in TableTop.transform)
            {
                cards[i] = n.GetComponent<CardEntity>().cardType;
                i++;
            }

            return cards;
        }
        public CardType[] GetTableTopCard2()
        {
            int cardsNumber = 0;
            foreach (Transform n in TableTop2.transform)
            {
                cardsNumber++;
            }
            CardType[] cards = new CardType[cardsNumber];
            int i = 0;
            foreach (Transform n in TableTop2.transform)
            {
                cards[i] = n.GetComponent<CardEntity>().cardType;
                i++;
            }
            return cards;
        }
    }
}