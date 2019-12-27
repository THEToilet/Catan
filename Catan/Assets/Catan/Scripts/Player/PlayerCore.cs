using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Player
{

    public class PlayerCore : MonoBehaviour
    {
        [SerializeField] private PlayerId playerId;
        [SerializeField] private Belongings _belongings;

        public void Initialize(PlayerId _playerId)
        {
            playerId = _playerId;
        }
    }
}