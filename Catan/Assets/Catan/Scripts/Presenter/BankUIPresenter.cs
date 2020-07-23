using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Manager;
using Catan.Scripts.Player;
using Catan.Scripts.Card;

namespace Catan.Scripts.Presenter
{
    public class BankUIPresenter : MonoBehaviour
    {
        [SerializeField] Button wood4Button;
        [SerializeField] Button wool4Button;
        [SerializeField] Button wheat4Button;
        [SerializeField] Button ironOre4Button;
        [SerializeField] Button brick4Button;
        [SerializeField] Button bankButton;
        [SerializeField] Button bankCancelButton;
        [SerializeField] GameObject deleteResourceSelectPanel;
        [SerializeField] GameObject bankPanel;
        public PlayerTurnManeger playerTurnManeger;
        public ToPleyerObject toPleyerObject;
        public CardEnumeration cardEnumeration;
        public CardConsumptionManeger cardConsumptionManeger;
        public ToCardObject toCardObject;
        public DeleteResourcePresenter deleteResourcePresenter;
        void Start()
        {
            bankButton.OnClickAsObservable().Subscribe(_ =>
            {
                bankPanel.SetActive(true);
            });
            bankCancelButton.OnClickAsObservable().Subscribe(_ =>
            {
                bankPanel.SetActive(false);
            });
            wood4Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Forest));
                deleteResourcePresenter.numberOfCards = 4;
                deleteResourceSelectPanel.SetActive(true);
                bankPanel.SetActive(false);
            });
            wool4Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Pasture));
                deleteResourcePresenter.numberOfCards = 4;
                deleteResourceSelectPanel.SetActive(true);
                bankPanel.SetActive(false);
            });
            wheat4Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Hill));
                deleteResourcePresenter.numberOfCards = 4;
                deleteResourceSelectPanel.SetActive(true);
                bankPanel.SetActive(false);
            });
            ironOre4Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Mine));
                deleteResourcePresenter.numberOfCards = 4;
                deleteResourceSelectPanel.SetActive(true);
                bankPanel.SetActive(false);
            });
            brick4Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Field));
                deleteResourcePresenter.numberOfCards = 4;
                deleteResourceSelectPanel.SetActive(true);
                bankPanel.SetActive(false);
            });

        }

        private void Update()
        {
            if (playerTurnManeger._currentTurnState.Value == TurnState.NormalTurn)
            {
                var num = cardEnumeration.Enumeration(playerTurnManeger._currentPlayerId.Value);
                if (num[0] >= 4 || num[1] >= 4 || num[2] >= 4 || num[3] >= 4 || num[4] >= 4)
                {
                    brick4Button.interactable = true;
                    ironOre4Button.interactable = true;
                    wheat4Button.interactable = true;
                    wood4Button.interactable = true;
                    wool4Button.interactable = true;
                }
                else
                {
                    wood4Button.interactable = false;
                    wool4Button.interactable = false;
                    wheat4Button.interactable = false;
                    ironOre4Button.interactable = false;
                    brick4Button.interactable = false;
                }
            }
        }
    }
}