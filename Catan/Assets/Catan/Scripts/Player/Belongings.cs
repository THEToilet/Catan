using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Card;

namespace Catan.Scripts.Player
{
    public class Belongings : MonoBehaviour
    {
        [SerializeField] private PlayerId playerId;

        [SerializeField] private CardType type;
        public CardType TrapType => type;
        List<CardType> cards = new List<CardType>();


    }
}