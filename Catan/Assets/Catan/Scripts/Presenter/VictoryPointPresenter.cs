using UnityEngine;
using UnityEngine.UI;
using Catan.Scripts.Manager;

namespace Catan.Scripts.Presenter

{
    public class VictoryPointPresenter : MonoBehaviour
    {
        public Text[] pT = new Text[4];
        public VictoryPointEnumeration victoryPointEnumeration;
        public PlayerTurnManeger playerTurnManeger;
        private void Update()
        {
            if (playerTurnManeger._currentTurnState.Value == TurnState.NormalTurn)
            {
                var p = victoryPointEnumeration.victoryPoint;
                for (int i = 0; i < pT.Length; i++)
                {
                    pT[i].text = p[i].ToString();
                }
            }
        }
    }
}