using System;
using UniRx;
using UnityEngine;
using Catan.Scripts.Game;

namespace Catan.Scripts.Manager
{
    class GameStateManeger : MonoBehaviour
    {
        GameState gameState = GameState.Construction;

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