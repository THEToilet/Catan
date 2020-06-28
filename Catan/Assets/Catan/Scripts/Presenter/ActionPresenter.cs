using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Manager;
using Catan.Scripts.Common;

namespace Catan.Scripts.Presenter
{
    public class ActionPresenter : MonoBehaviour
    {
        [SerializeField] private Button turnEndButton;
        [SerializeField] private Button rollDiceButton;

        [SerializeField] private Button constructionButton;

        [SerializeField] private Button tradeButton;
        [SerializeField] private Button useCardButton;

        [SerializeField] private Button negotiationButton;

        [SerializeField] private Button drawCardButton;

        public GameStateManeger gameStateManeger;
        public PlayerTurnManeger playerTurn;
        public DistributeCardManeger distributeCardManeger;
        public UIRestrictionPresenter uIRestrictionPresenter;



        // Start is called before the first frame update
        void Start()
        {
            constructionButton.OnClickAsObservable()  // 建設する
            .Subscribe(_ =>
            {
                gameStateManeger._currentGameState
                    .SetValueAndForceNotify(GameState.Construction);
            });

            useCardButton.OnClickAsObservable()  // カードを使う　
            .Subscribe(_ =>
            {
                gameStateManeger._currentGameState
                    .SetValueAndForceNotify(GameState.UseCard);
            });


            drawCardButton.OnClickAsObservable() // カードを引く  
            .Subscribe(_ =>
            {
                gameStateManeger._currentGameState
                    .SetValueAndForceNotify(GameState.DrawCard);
            });

            tradeButton.OnClickAsObservable() //  トレードする
            .Subscribe(_ =>
            {
                gameStateManeger._currentGameState
                    .SetValueAndForceNotify(GameState.Trade);
            });

            negotiationButton.OnClickAsObservable()  // 交渉する
            .Subscribe(_ =>
            {
                gameStateManeger._currentGameState
                    .SetValueAndForceNotify(GameState.Negotiation);
            });
           
            turnEndButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                playerTurn.Next();
            });

            rollDiceButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                Debug.Log(Dice.RandomRollTwiceDice());

                uIRestrictionPresenter.TurnOffRollDice();
                distributeCardManeger.Distribute(Dice.RandomRollTwiceDice());
            });
        }

    }
}