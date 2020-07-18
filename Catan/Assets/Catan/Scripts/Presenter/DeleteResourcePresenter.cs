using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Player;
using Catan.Scripts.Manager;
using Catan.Scripts.Card;

namespace Catan.Scripts.Presenter
{

    /// <summary>
    /// カードの使用する種類を指定するclass
    /// </summary>
    public class DeleteResourcePresenter : MonoBehaviour
    {
        [SerializeField] Button woodButton;
        [SerializeField] Button woolButton;
        [SerializeField] Button wheatButton;
        [SerializeField] Button ironOreButton;
        [SerializeField] Button brickButton;
        [SerializeField] GameObject deleteResourcePanel;
        public ToPleyerObject toPleyerObject;
        public CardConsumptionManeger cardConsumptionManeger;
        public PlayerTurnManeger playerTurnManeger;
        public ToCardWithCardTypeObject toCardWithCardTypeObject;
        public CardEnumeration cardEnumeration;
        public int numberOfCards; // 消すカードの枚数
        void Start()
        {
            woodButton.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
                cardConsumptionManeger.DeleteElement(p, GenerateCards(numberOfCards, CardType.Wood));
                deleteResourcePanel.SetActive(false);
            });
            woolButton.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
                cardConsumptionManeger.DeleteElement(p, GenerateCards(numberOfCards, CardType.Wool));
                deleteResourcePanel.SetActive(false);
            });
            wheatButton.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
                cardConsumptionManeger.DeleteElement(p, GenerateCards(numberOfCards, CardType.Wheat));
                deleteResourcePanel.SetActive(false);
            });
            ironOreButton.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
                cardConsumptionManeger.DeleteElement(p, GenerateCards(numberOfCards, CardType.IronOre));
                deleteResourcePanel.SetActive(false);
            });
            brickButton.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
                cardConsumptionManeger.DeleteElement(p, GenerateCards(numberOfCards, CardType.Brick));
                deleteResourcePanel.SetActive(false);
            });
        }

        CardType[] GenerateCards(int number, CardType card)
        {
            CardType[] cards = new CardType[number];
            for (int i = 0; i < number; i++)
            {
                cards[i] = card;
            }
            return cards;
        }

        private void Update()
        {
            if (playerTurnManeger._currentTurnState.Value == TurnState.NormalTurn)
            {
                var t = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
                var num = cardEnumeration.Enumeration(playerTurnManeger._currentPlayerId.Value);
                var c = t.GetComponent<Belongings>().City;
                if (num[0] >= numberOfCards)
                {
                    brickButton.interactable = true;
                }
                else
                {
                    brickButton.interactable = false;
                }
                if (num[1] >= numberOfCards)
                {
                    ironOreButton.interactable = true;
                }
                else
                {
                    ironOreButton.interactable = false;
                }
                if (num[2] >= numberOfCards)
                {
                    wheatButton.interactable = true;
                }
                else
                {
                    wheatButton.interactable = false;
                }
                if (num[3] >= numberOfCards)
                {
                    woodButton.interactable = true;
                }
                else
                {
                    woodButton.interactable = false;
                }
                if (num[4] >= numberOfCards)
                {
                    woolButton.interactable = true;
                }
                else
                {
                    woolButton.interactable = false;
                }
            }

        }
    }
}
