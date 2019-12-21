using System;
using UniRx;
using UnityEngine;

namespace Catan.Scripts.Manager
{
    public enum PlayerId
    {
        Player1 = 0,
        Player2 = 1,
        Player3 = 2,
        Player4 = 3
    }
    class PlayerTurnManeger : MonoBehaviour
    {
        PlayerId playerId = PlayerId.Player1;
        public void Start()
        {
        }

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