using System;
using UniRx;
using UnityEngine;

namespace Catan.Scripts.Manager
{

    public enum GameState
    {
        Construction,
        AboutCard,
        Trade,
        Negotiation,
        VictoryDeclaration
    }
    class GameStateManeger : MonoBehaviour
    {
        GameState gameState = GameState.Construction;
        public void Start()
        {
        }

        public void Update()
        {
            switch (gameState)
            {
                case GameState.Construction:
                    break;
                case GameState.AboutCard:
                    break;
                case GameState.Trade:
                    break;
                case GameState.Negotiation:
                    break;
                case GameState.VictoryDeclaration:
                    break;
            }
        }
    }
}