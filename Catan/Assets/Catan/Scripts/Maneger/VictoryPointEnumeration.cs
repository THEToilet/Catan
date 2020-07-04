using Catan.Scripts.Card;
using Catan.Scripts.Player;
using Catan.Scripts.Territory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Manager
{

    public class VictoryPointEnumeration : MonoBehaviour
    {

        public PlayerTurnManeger playerTurnManeger;
        public ProgressStateManeger progressStateManeger;
        public ToPleyerObject toPleyerObject;
        private PlayerId[] playerIds = new PlayerId[] { PlayerId.Player1, PlayerId.Player2, PlayerId.Player3, PlayerId.Player4 };
        public int[] victoryPoint;
        private void Update()
        {
            if (progressStateManeger._currentProgressState.Value == ProgressState.Battle)
            {
                victoryPoint = new int[] { 0, 0, 0, 0 };

                for (int i = 0; i < 4; i++)
                {
                    var p = toPleyerObject.ToPlayer(playerIds[i]).GetComponent<Belongings>();
                    for (int j = 0; j < p.City.Count; j++)
                    {
                        if (p.City[j].GetComponent<TerritoryEntity>().territoryType == TerritoryType.Settlement)
                        {
                            victoryPoint[i]++;
                        }
                        else
                        {
                            victoryPoint[i] += 2;
                        }
                    }

                    for (int j = 0; j < p.scards.Count; j++)
                    {
                        if (p.scards[j].GetComponent<SpecialCardEntity>().specialCardType == SpecialCardType.Wining)
                        {
                            victoryPoint[i]++;
                        }
                    }
                    toPleyerObject.ToPlayer(playerIds[i]).GetComponent<PlayerCore>().playerScore.Value = victoryPoint[i];
                }

            }
        }
    }

}