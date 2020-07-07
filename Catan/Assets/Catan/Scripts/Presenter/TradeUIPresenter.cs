using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Manager;
using Catan.Scripts.Player;
using Catan.Scripts.Card;

namespace Catan.Scripts.Presenter
{

    public class TradeUIPresenter : MonoBehaviour
    {
        [SerializeField] Button wood3Button;
        [SerializeField] Button wool3Button;
        [SerializeField] Button wheat3Button;
        [SerializeField] Button ironOre3Button;
        [SerializeField] Button brick3Button;
        [SerializeField] Button wood2Button;
        [SerializeField] Button wool2Button;
        [SerializeField] Button wheat2Button;
        [SerializeField] Button ironOre2Button;
        [SerializeField] Button brick2Button;
        public PlayerTurnManeger playerTurnManeger;
        public ToPleyerObject toPleyerObject;
        public CardEnumeration cardEnumeration;
        public CardConsumptionManeger cardConsumptionManeger;
        public ToCardObject toCardObject;

        public void TurnOffAll()
        {
            wood2Button.interactable = false;
            wool2Button.interactable = false;
            wheat2Button.interactable = false;
            ironOre2Button.interactable = false;
            brick2Button.interactable = false;
            wood3Button.interactable = false;
            wool3Button.interactable = false;
            wheat3Button.interactable = false;
            ironOre3Button.interactable = false;
            brick3Button.interactable = false;
        }
        void Start()
        {
            wood2Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                cardConsumptionManeger.DeleteCard(new CardType[] { CardType.Wood, CardType.Wood });
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Forest));
                this.TurnOffAll();
            });
            wool2Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                cardConsumptionManeger.DeleteCard(new CardType[] { CardType.Wool, CardType.Wool });
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Pasture));
                this.TurnOffAll();
            });
            wheat2Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                cardConsumptionManeger.DeleteCard(new CardType[] { CardType.Wheat, CardType.Wheat });
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Hill));
                this.TurnOffAll();
            });
            ironOre2Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                cardConsumptionManeger.DeleteCard(new CardType[] { CardType.IronOre, CardType.IronOre });
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Mine));
                this.TurnOffAll();
            });
            brick2Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                cardConsumptionManeger.DeleteCard(new CardType[] { CardType.Brick, CardType.Brick });
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Field));
                this.TurnOffAll();
            });


            wood3Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                cardConsumptionManeger.DeleteCard(new CardType[] { CardType.Wood, CardType.Wood, CardType.Wood });
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Forest));
                this.TurnOffAll();
            });
            wool3Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                cardConsumptionManeger.DeleteCard(new CardType[] { CardType.Wool, CardType.Wool, CardType.Wool });
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Pasture));
                this.TurnOffAll();
            });
            wheat3Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                cardConsumptionManeger.DeleteCard(new CardType[] { CardType.Wheat, CardType.Wheat, CardType.Wheat });
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Hill));
                this.TurnOffAll();
            });
            ironOre3Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                cardConsumptionManeger.DeleteCard(new CardType[] { CardType.IronOre, CardType.IronOre, CardType.IronOre });
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Mine));
                this.TurnOffAll();
            });
            brick3Button.OnClickAsObservable().Subscribe(_ =>
            {
                var p = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value).GetComponent<Belongings>().cards;
                cardConsumptionManeger.DeleteCard(new CardType[] { CardType.Brick, CardType.Brick, CardType.Brick });
                p.Add(toCardObject.ToCard(Terrain.TerrainType.Field));
                this.TurnOffAll();
            });

        }

        private void Update()
        {
            if (playerTurnManeger._currentTurnState.Value == TurnState.NormalTurn)
            {
                var t = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
                var num = cardEnumeration.Enumeration(playerTurnManeger._currentPlayerId.Value);
                if (num[0] >= 2)
                {
                    brick2Button.interactable = true;
                }
                if (num[1] >= 2)
                {
                    ironOre2Button.interactable = true;
                }
                if (num[2] >= 2)
                {
                    wheat2Button.interactable = true;
                }
                if (num[3] >= 2)
                {
                    wood2Button.interactable = true;
                }
                if (num[4] >= 2)
                {
                    wool2Button.interactable = true;
                }
                if (num[0] >= 3)
                {
                    brick2Button.interactable = true;
                    brick3Button.interactable = true;
                }
                if (num[1] >= 3)
                {
                    ironOre2Button.interactable = true;
                    ironOre3Button.interactable = true;
                }
                if (num[2] >= 3)
                {
                    wheat2Button.interactable = true;
                    wheat3Button.interactable = true;
                }
                if (num[3] >= 3)
                {
                    wood2Button.interactable = true;
                    wood3Button.interactable = true;
                }
                if (num[4] >= 3)
                {
                    wool2Button.interactable = true;
                    wool3Button.interactable = true;
                }
            }

        }
    }

}
