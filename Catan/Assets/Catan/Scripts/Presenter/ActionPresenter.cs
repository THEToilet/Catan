using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Manager;
using Catan.Scripts.Common;
using Catan.Scripts.Card;

namespace Catan.Scripts.Presenter
{
    public class ActionPresenter : MonoBehaviour
    {
        [SerializeField] private Button turnEndButton;
        [SerializeField] private Button rollDiceButton;
        [SerializeField] private Button useCardButton;
        [SerializeField] private Button negotiationButton;
        [SerializeField] Button submmitButton;

        public PlayerTurnManeger playerTurn;
        public DistributeCardManeger distributeCardManeger;
        public UIRestrictionPresenter uIRestrictionPresenter;
        public TradeCardEnumeration tradeCardEnumeration;
        public PlayerNotificationPresenter playerNotificationPresenter;
        public TheifManeger theifManeger;
        [SerializeField] Button actionButton;
        [SerializeField] Button actionCancelButton;
        [SerializeField] Button costButton;
        [SerializeField] Button costCancelButton;
        [SerializeField] Button settingButton;
        [SerializeField] Button settingCancelButton;
        [SerializeField] GameObject settingPanel;

        public DicePresenter dicePresenter;

        void Start()
        {
            settingButton.OnClickAsObservable().Subscribe(_ =>
            {
                settingButton.gameObject.SetActive(false);
                settingCancelButton.gameObject.SetActive(true);
                settingPanel.SetActive(true);
            });
            settingCancelButton.OnClickAsObservable().Subscribe(_ =>
            {
                settingButton.gameObject.SetActive(true);
                settingCancelButton.gameObject.SetActive(false);
                settingPanel.SetActive(false);
            });
            turnEndButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                playerTurn._currentCursole.Value++;
            });

            rollDiceButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                uIRestrictionPresenter.LetAction();
                var d = Dice.RandomRollTwiceDice();
                if (d[0] + d[1] == 7)
                {
                    Debug.Log("Thief");
                    playerNotificationPresenter.DisplayNote("Theif time");
                    theifManeger.ReduceCard();
                    theifManeger.MoveTheif();
                    uIRestrictionPresenter.TurnOffAll();
                }
                else
                {
                    distributeCardManeger.Distribute(d[0] + d[1]);
                    dicePresenter.ShowDiceNum(d[0] + d[1]);
                    dicePresenter.ShowDice(d[0], d[1]);
                }
            });

            actionButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                actionButton.gameObject.SetActive(false);
                actionCancelButton.gameObject.SetActive(true);
            });

            actionCancelButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                actionCancelButton.gameObject.SetActive(false);
                actionButton.gameObject.SetActive(true);
            });

            costButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                costButton.gameObject.SetActive(false);
                costCancelButton.gameObject.SetActive(true);
            });

            costCancelButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                costCancelButton.gameObject.SetActive(false);
                costButton.gameObject.SetActive(true);
            });

        }
    }
}