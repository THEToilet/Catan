using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Card;
using Catan.Scripts.Territory;

namespace Catan.Scripts.Player
{
    public class Belongings : MonoBehaviour
    {
       // [SerializeField] private CardType type;
       // [SerializeField] private SpecialCardType stype;
        public List<CardEntity> cards = new List<CardEntity>();
        public List<SpecialCardEntity> scards = new List<SpecialCardEntity>();
        public List<TerritoryEntity> territories = new List<TerritoryEntity>();

    }
}