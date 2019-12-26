using System;
using UniRx;
using UnityEngine;
using Catan.Scripts.Player;

namespace Catan.Scripts.Manager
{
    class PlayerTurnManeger : MonoBehaviour
    {
        PlayerId playerId = PlayerId.Player1;

        public void Update()
        {
            switch (playerId)
            {
                case PlayerId.Player1:
                    break;
                case PlayerId.Player2:
                    break;
                case PlayerId.Player3:
                    break;
                case PlayerId.Player4:
                    break;
            }
        }
    }
}