using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Player;
using Catan.Scripts.Card;
using Catan.Scripts.Manager;

namespace Catan.Scripts.Presenter
{

    public class NegotiationPresenter : MonoBehaviour
    {
        [SerializeField] Button submmitButton;
        [SerializeField] Button negotiationButton;
        [SerializeField] GameObject negotiationPanel;
        [SerializeField] GameObject playerSelectionPanel;
        [SerializeField] GameObject negotiationPanel2;
        [SerializeField] Button submmitButton2;
        [SerializeField] Button player1SelectButton;
        [SerializeField] Button player2SelectButton;
        [SerializeField] Button player3SelectButton;
        [SerializeField] Button player4SelectButton;
        [SerializeField] Button negotiationCancelButton;
        [SerializeField] GameObject playerOKSelectionPanel;
        [SerializeField] Button playerOKButton;
        [SerializeField] Button playerCancelButton;
        public TableTopCardPresenter tableTopCardPresenter;
        CardType[] beforeCards;
        CardType[] afterCards;
        public PlayerTurnManeger playerTurnManeger;
        public CardConsumptionManeger cardConsumptionManeger;
        public ToPleyerObject toPleyerObject;
        public ToCardWithCardTypeObject toCardWithCardTypeObject;
        PlayerId target = PlayerId.Player1;
        [SerializeField] Text playerText;

        private void Start()
        {
            negotiationButton.OnClickAsObservable().Subscribe(_ =>
            {
                negotiationPanel.SetActive(true);
            });

            // =>
            negotiationCancelButton.OnClickAsObservable().Subscribe(_ =>
            {
                negotiationPanel.SetActive(false);
            });
            submmitButton.OnClickAsObservable().Subscribe(_ =>
            {
                negotiationPanel.SetActive(false);
                playerSelectionPanel.SetActive(true);
                beforeCards = tableTopCardPresenter.GetTableTopCard2();
            });


            // =>
            player1SelectButton.OnClickAsObservable().Subscribe(_ =>
            {
                playerSelectionPanel.SetActive(false);
                negotiationPanel2.SetActive(true);
                tableTopCardPresenter.CreateCard2(PlayerId.Player1);
                target = PlayerId.Player1;
            });
            player2SelectButton.OnClickAsObservable().Subscribe(_ =>
            {
                playerSelectionPanel.SetActive(false);
                negotiationPanel2.SetActive(true);
                tableTopCardPresenter.CreateCard2(PlayerId.Player2);
                target = PlayerId.Player2;
            });
            player3SelectButton.OnClickAsObservable().Subscribe(_ =>
            {
                playerSelectionPanel.SetActive(false);
                negotiationPanel2.SetActive(true);
                tableTopCardPresenter.CreateCard2(PlayerId.Player3);
                target = PlayerId.Player3;
            });
            player4SelectButton.OnClickAsObservable().Subscribe(_ =>
            {
                playerSelectionPanel.SetActive(false);
                negotiationPanel2.SetActive(true);
                tableTopCardPresenter.CreateCard2(PlayerId.Player4);
                target = PlayerId.Player1;
            });


            // =>
            submmitButton2.OnClickAsObservable().Subscribe(_ =>
            {
                playerOKSelectionPanel.SetActive(true);
                negotiationPanel2.SetActive(false);
                playerText.text = target.ToString();
                afterCards = tableTopCardPresenter.GetTableTopCard2();
            });


            // =>
            playerOKButton.OnClickAsObservable().Subscribe(_ =>
            {
                playerOKSelectionPanel.SetActive(false);
                tableTopCardPresenter.DeleateCard2();
                cardConsumptionManeger.DeleteElement(toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value), beforeCards);
                cardConsumptionManeger.DeleteElement(toPleyerObject.ToPlayer(target), afterCards);
                AddCardForPlayer(toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value), afterCards);
                AddCardForPlayer(toPleyerObject.ToPlayer(target), beforeCards);
                tableTopCardPresenter.DeleateCard();
                tableTopCardPresenter.CreateCard(playerTurnManeger._currentPlayerId.Value);
                Debug.Log("交換成功！！");
            });
            playerCancelButton.OnClickAsObservable().Subscribe(_ =>
            {
                playerOKSelectionPanel.SetActive(false);
                tableTopCardPresenter.DeleateCard2();
            });

        }

        void AddCardForPlayer(GameObject player, CardType[] cards)
        {
            var c = player.GetComponent<Belongings>().cards;
            for (int i = 0; i < cards.Length; i++)
            {
                c.Add(toCardWithCardTypeObject.ToCard(cards[i]));
            }
        }
    }

}