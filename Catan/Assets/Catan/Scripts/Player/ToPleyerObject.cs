using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Catan.Scripts.Player
{
    public class ToPleyerObject : MonoBehaviour
    {
        public GameObject Player1;
        public GameObject Player2;
        public GameObject Player3;
        public GameObject Player4;
        public GameObject ToPlayer(PlayerId id)
        {
            switch (id)
            {
                case PlayerId.Player1:
                    return Player1;
                case PlayerId.Player2:
                    return Player2;
                case PlayerId.Player3:
                    return Player3;
                case PlayerId.Player4:
                    return Player4;
                default:
                    throw new ArgumentOutOfRangeException("id", id, null);
            }


        }

    }
}