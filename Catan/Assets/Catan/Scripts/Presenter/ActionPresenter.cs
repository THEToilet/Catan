using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Manager;
using Catan.Scripts.Common;
using UnityEditor.VersionControl;
using UniRx.Triggers;
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

        public DicePresenter dicePresenter;


        // Start is called before the first frame update
        void Start()
        {

            negotiationButton.OnClickAsObservable()  // 交渉する
            .Subscribe(_ =>
            {
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
                }
                else
                {
                    distributeCardManeger.Distribute(d[0] + d[1]);
                }
                dicePresenter.ShowDiceNum(d[0] + d[1]);
                dicePresenter.ShowDice(d[0], d[1]);
            });


            submmitButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                tradeCardEnumeration.TableTopEnumeration();
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