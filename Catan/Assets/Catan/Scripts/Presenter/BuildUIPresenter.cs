using UnityEngine;
using UnityEngine.UI;
using Catan.Scripts.Manager;
using Catan.Scripts.Player;
using Catan.Scripts.Card;
using UniRx;
using Catan.Scripts.Terrain;

namespace Catan.Scripts.Presenter
{
    public class BuildUIPresenter : MonoBehaviour
    {
        [SerializeField] Button cityButton;
        [SerializeField] Button settlementButton;
        [SerializeField] Button roadButton;
        [SerializeField] Button drawCardButton;
        [SerializeField] Button actionButton;
        [SerializeField] Button actionCancelButton;
        public PlayerTurnManeger playerTurnManeger;
        public ToPleyerObject toPleyerObject;
        public CardEnumeration cardEnumeration;
        public CardConsumptionManeger cardConsumptionManeger;
        public DrawCard drawCard;
        public RoadBasePresenter roadBasePresenter;
        public PointChildrenPresenter pointChildrenPresenter;
        public UIRestrictionPresenter uIRestrictionPresenter;
        public CityPresenter cityPresenter;
        public CityKindsEnumeration cityKindsEnumeration;
        private bool isCheck = false;
        public int r, c;

        private void Start()
        {
            roadButton.interactable = false;
            settlementButton.interactable = false;
            cityButton.interactable = false;
            drawCardButton.interactable = false;

            roadButton.OnClickAsObservable()
        .Subscribe(_ =>
        {
            var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
            cardConsumptionManeger.BuyRoad();
            roadBasePresenter.ShowPossiblePoint(playerTurnManeger._currentPlayerId.Value);
            this.TurnOffAll();
            this.setCount(p);
            isCheck = true;
            uIRestrictionPresenter.TurnOffAll();
        });
            settlementButton.OnClickAsObservable()
        .Subscribe(_ =>
        {
            var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
            cardConsumptionManeger.BuySettlement();
            pointChildrenPresenter.ShowPossiblePlayerPoint(playerTurnManeger._currentPlayerId.Value);
            this.TurnOffAll();
            this.setCount(p);
            isCheck = true;
            uIRestrictionPresenter.TurnOffAll();
        });
            cityButton.OnClickAsObservable()
         .Subscribe(_ =>
         {
             var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
             cardConsumptionManeger.BuyCity();
             cityPresenter.ShowPossiblePoint(playerTurnManeger._currentPlayerId.Value);
             this.TurnOffAll();
             this.setCount(p);
             isCheck = true;
             uIRestrictionPresenter.TurnOffAll();
         });
            drawCardButton.OnClickAsObservable()
        .Subscribe(_ =>
        {
            drawCard.Draw();
            cardConsumptionManeger.BuyCard();
            this.TurnOffAll();
        });
        }

        public void TurnOffAll()
        {
            drawCardButton.interactable = false;
            cityButton.interactable = false;
            settlementButton.interactable = false;
            roadButton.interactable = false;
            this.Reset();
        }

        public void Reset()
        {
            actionButton.gameObject.SetActive(true);
            actionCancelButton.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (playerTurnManeger._currentTurnState.Value == TurnState.NormalTurn)
            {
                var t = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
                var num = cardEnumeration.Enumeration(playerTurnManeger._currentPlayerId.Value);
                var canLocateNum = pointChildrenPresenter.GetShowPossiblePlayerPointNum(playerTurnManeger._currentPlayerId.Value);
                var cityNum = cityKindsEnumeration.Enmeration(playerTurnManeger._currentPlayerId.Value);
                if (num[3] >= 1 && num[0] >= 1)
                {
                    roadButton.interactable = true;
                }
                if (num[3] >= 1 && num[0] >= 1 && num[2] >= 1 && num[4] >= 1 && canLocateNum > 0)
                {
                    settlementButton.interactable = true;
                }
                if (num[2] >= 2 && num[1] >= 3 && cityNum[1] > 0)
                {
                    cityButton.interactable = true;
                }
                if (num[2] >= 1 && num[4] >= 1 && num[1] >= 1)
                {
                    drawCardButton.interactable = true;
                }
            }
            if (isCheck)
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>();
                var dr = p.Road.Count;
                var dc = p.City.Count;
                if (dr > r)
                {
                    isCheck = false;
                    uIRestrictionPresenter.LetAction();
                    roadBasePresenter.EraseAll();
                }
                if (dc > c)
                {
                    isCheck = false;
                    uIRestrictionPresenter.LetAction();
                    pointChildrenPresenter.EraseAll();
                }
            }
        }
        private void setCount(GameObject g)
        {
            r = g.GetComponent<Belongings>().Road.Count;
            c = g.GetComponent<Belongings>().City.Count;
        }
    }
}