using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Manager;
using Catan.Scripts.Player;
using Catan.Scripts.Card;
using Catan.Scripts.Generation;
using Catan.Scripts.Territory;

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
        public PointChildrenGeneration pointChildrenGeneration;
        int[] wd2 = new int[] { 31, 32 };
        int[] wl2 = new int[] { 22, 23 };
        int[] wt2 = new int[] { 21, 30 };
        int[] io2 = new int[] { 42, 43 };
        int[] br2 = new int[] { 49, 50 };
        int[] trade3 = new int[] { 15, 16, 45, 46, 18, 39, 52, 53 };

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

        public bool CheckLocate(int[] point, List<GameObject> list)
        {
            for (int i = 0; i < point.Length; i++)
            {
                var checkPoint = pointChildrenGeneration.childrenPointGameObjects[i];
                for (int j = 0; j < list.Count; j++)
                {
                    if (checkPoint.Equals(list[j].GetComponent<TerritoryEntity>().TerritoryPosition))
                    {
                        return true;
                    }
                }

            }
            return true;
        }

        private void Update()
        {
            if (playerTurnManeger._currentTurnState.Value == TurnState.NormalTurn)
            {
                var t = toPleyerObject.ToPlayer(playerTurnManeger._currentPlayerId.Value);
                var num = cardEnumeration.Enumeration(playerTurnManeger._currentPlayerId.Value);
                var c = t.GetComponent<Belongings>().City;
                if (num[0] >= 2 || num[1] >= 2 || num[2] >= 2 || num[3] >= 2 || num[4] >= 2)
                {
                    if (CheckLocate(br2, c))
                    {
                        brick2Button.interactable = true;
                    }
                    if (CheckLocate(io2, c))
                    {
                        ironOre2Button.interactable = true;
                    }
                    if (CheckLocate(wt2, c))
                    {
                        wheat2Button.interactable = true;
                    }
                    if (CheckLocate(wd2, c))
                    {
                        wood2Button.interactable = true;
                    }
                    if (CheckLocate(wl2, c))
                    {
                        wool2Button.interactable = true;
                    }
                }
                if ((num[0] >= 3 || num[1] >= 3 || num[2] >= 3 || num[3] >= 3 || num[4] >= 3) && (CheckLocate(trade3, c)))
                {
                    brick3Button.interactable = true;
                    ironOre3Button.interactable = true;
                    wheat3Button.interactable = true;
                    wood3Button.interactable = true;
                    wool3Button.interactable = true;
                }
            }

        }
    }

}
