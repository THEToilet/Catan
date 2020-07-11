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
        public PlayerTurnManeger playerTurnManeger;
        public ToPleyerObject toPleyerObject;
        public CardEnumeration cardEnumeration;
        public CardConsumptionManeger cardConsumptionManeger;
        public ToCardObject toCardObject;
        public void TurnOffAll()
        {
            wood4Button.interactable = false;
            wool4Button.interactable = false;
            wheat4Button.interactable = false;
            ironOre4Button.interactable = false;
            brick4Button.interactable = false;
        }
        void Start()
        {
            wood4Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                cardConsumptionManeger.DeleteCard(new CardType[] { CardType.Wood, CardType.Wood, CardType.Wood, CardType.Wood });
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Forest));
                this.TurnOffAll();
            });
            wool4Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                cardConsumptionManeger.DeleteCard(new CardType[] { CardType.Wool, CardType.Wool, CardType.Wool, CardType.Wool });
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Pasture));
                this.TurnOffAll();
            });
            wheat4Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                cardConsumptionManeger.DeleteCard(new CardType[] { CardType.Wheat, CardType.Wheat, CardType.Wheat, CardType.Wheat });
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Hill));
                this.TurnOffAll();
            });
            ironOre4Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                cardConsumptionManeger.DeleteCard(new CardType[] { CardType.IronOre, CardType.IronOre, CardType.IronOre, CardType.IronOre });
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Mine));
                this.TurnOffAll();

            });
            brick4Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                cardConsumptionManeger.DeleteCard(new CardType[] { CardType.Brick, CardType.Brick, CardType.Brick, CardType.Brick });
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Field));
                this.TurnOffAll();

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
            }
        }

    }
}