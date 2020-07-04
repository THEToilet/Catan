﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Catan.Scripts.Player;
using Catan.Scripts.Manager;
using Catan.Scripts.Card;

namespace Catan.Scripts.Presenter
{

    public class CardViewPresenter : MonoBehaviour
    {
        [SerializeField] Text WoodText;
        [SerializeField] Text BrickCard;
        [SerializeField] Text IronOreCard;
        [SerializeField] Text WheatCard;
        [SerializeField] Text WoolCard;
        public PlayerTurnManeger playerTurnManeger;
        public CardEnumeration cardEnumeration;


        // Update is called once per frame
        void Update()
        {
            if (playerTurnManeger._currentTurnState.Value == TurnState.NormalTurn)
            {
                var p = playerTurnManeger._currentPlayerId.Value;
                var o = cardEnumeration.Enumeration(p);
                WoodText.text = o[3].ToString();
                BrickCard.text = o[0].ToString();
                IronOreCard.text = o[1].ToString();
                WheatCard.text = o[2].ToString();
                WoolCard.text = o[4].ToString();
            }
        }
    }

}