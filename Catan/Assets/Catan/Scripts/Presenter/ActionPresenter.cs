using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Manager;

namespace Catan.Scripts.Presenter
{
    public class ActionPresenter : MonoBehaviour
    {
        [SerializeField] private Button spreadActionButton;

        [SerializeField] private Button closeActionButton;

        [SerializeField] private Button turnEndButton;

        [SerializeField] private Button constructionButton;

        [SerializeField] private Button aboutCardButton;

        [SerializeField] private Button tradeButton;

        [SerializeField] private Button negotiationButton;

        public GameStateManeger gameStateManeger;
        public PlayerTurn playerTurn;

        public bool ownPlayer = false;
        public bool otherPlayer = false;
        public bool action = false;
        public bool build = false;
        public bool card = false;
        public bool trade = false;
        public bool negotiation = false;

        public GameObject turnPlayer;
        public GameObject ownPlayerPanel;
        public GameObject otherPlayerPanel;
        public GameObject actionPanel;

        public GameObject buildPanel;
        public GameObject cardPanel;
        public GameObject tradePanel;
        public GameObject negotiationPanel;


        // Start is called before the first frame update
        void Start()
        {
            spreadActionButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    spreadActionButton.interactable = false;
                    closeActionButton.interactable = true;

                });

            closeActionButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    closeActionButton.interactable = false;
                    spreadActionButton.interactable = true;

                });

            constructionButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                gameStateManeger._currentGameState
                    .SetValueAndForceNotify(GameState.Construction);
            });

            aboutCardButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                gameStateManeger._currentGameState
                    .SetValueAndForceNotify(GameState.AboutCard);
            });

            tradeButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                gameStateManeger._currentGameState
                    .SetValueAndForceNotify(GameState.Trade);
            });

            negotiationButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                gameStateManeger._currentGameState
                    .SetValueAndForceNotify(GameState.Negotiation);
            });

            turnEndButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                playerTurn.isActive = true;
            });

        }

        public void OwnPlayer()
        {
            if (ownPlayer == false)
            {
                ownPlayer = true;
                ownPlayerPanel.SetActive(true);

                if (otherPlayer == false && action == false)
                {
                    turnPlayer.transform.Translate(-400, 0, 0);
                }

                else
                {
                    otherPlayer = false;
                    action = false;
                    otherPlayerPanel.SetActive(false);
                    actionPanel.SetActive(false);
                }
            }
            else
            {
                ownPlayer = false;
                turnPlayer.transform.Translate(400, 0, 0);
                ownPlayerPanel.SetActive(false);
            }
        }

        public void OtherPlayer()
        {
            if (otherPlayer == false)
            {
                otherPlayer = true;
                otherPlayerPanel.SetActive(true);

                if (ownPlayer == false && action == false)
                {
                    turnPlayer.transform.Translate(-400, 0, 0);
                }

                else
                {
                    ownPlayer = false;
                    action = false;
                    actionPanel.SetActive(false);
                    ownPlayerPanel.SetActive(false);
                }
            }
            else
            {
                otherPlayer = false;
                turnPlayer.transform.Translate(400, 0, 0);
                otherPlayerPanel.SetActive(false);
            }
        }

        public void Action()
        {
            if (action == false)
            {
                action = true;
                actionPanel.SetActive(true);

                if (otherPlayer == false && ownPlayer == false)
                {
                    turnPlayer.transform.Translate(-400, 0, 0);
                }

                else
                {
                    otherPlayer = false;
                    ownPlayer = false;
                    ownPlayerPanel.SetActive(false);
                    otherPlayerPanel.SetActive(false);
                }
            }
            else
            {
                action = false;
                turnPlayer.transform.Translate(400, 0, 0);
                actionPanel.SetActive(false);
            }
        }

        public void Build()
        {
            if (cardPanel.activeSelf == false && tradePanel.activeSelf == false && negotiationPanel.activeSelf == false)
            {
                buildPanel.SetActive(true);
            }
        }

        public void BuildCancel()
        {
            buildPanel.SetActive(false);
        }

        public void Card()
        {
            if (buildPanel.activeSelf == false && tradePanel.activeSelf == false && negotiationPanel.activeSelf == false)
            {
                cardPanel.SetActive(true);
            }
        }

        public void CardCancel()
        {
            cardPanel.SetActive(false);
        }

        public void Trade()
        {
            if (buildPanel.activeSelf == false && cardPanel.activeSelf == false &&  negotiationPanel.activeSelf == false)
            {
                tradePanel.SetActive(true);
            }
        }

        public void TradeCancel()
        {
            tradePanel.SetActive(false);
        }

        public void Negotiation()
        {
            if (buildPanel.activeSelf == false && cardPanel.activeSelf == false && tradePanel.activeSelf == false)
            {
                negotiationPanel.SetActive(true);
            }
        }


        public void NegotiationCancel()
        {
            negotiationPanel.SetActive(false);
        }
    }


}