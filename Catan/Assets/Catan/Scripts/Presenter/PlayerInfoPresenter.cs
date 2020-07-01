﻿using Catan.Scripts.Manager;
using Catan.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class PlayerInfoPresenter : MonoBehaviour
{
    public ToPleyerObject toPleyerObject;
    public ProgressStateManeger progressStateManeger;
    public PlayerTurnManeger playerTurnManeger;
    [SerializeField] List<Text> player = new List<Text>(4);
    [SerializeField] List<Text> point = new List<Text>(4);
    [SerializeField] List<Text> card = new List<Text>(4);

    private void Start()
    {
    }

    void Update()
    {
        var p = playerTurnManeger.playerIds;
        for (int i = 0; i < p.Length; i++)
        {
            point[i].text = (toPleyerObject.ToPlayer(p[i]).GetComponent<PlayerCore>().playerScore.Value).ToString();
            card[i].text = (toPleyerObject.ToPlayer(p[i]).GetComponent<Belongings>().cards.Count).ToString();
            player[i].text = toPleyerObject.ToPlayer(p[i]).name;
        }


    }
}
