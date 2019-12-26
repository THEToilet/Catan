using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Player
{

    public class PlayerCore : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private PlayerId playerId;
        [SerializeField] private Belongings _belongings;

        void Initialize(PlayerId _playerId)
        {
            playerId = _playerId;
            GameObject.Instantiate(_player, new Vector3(0, 0, 0), Quaternion.Euler(0, 30, 0));
        }
    }
}