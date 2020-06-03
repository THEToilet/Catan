using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Catan.Scripts.Player;

public class PlayerTurnUI : MonoBehaviour
{
    public GameObject turnPanel;
    public Text playerText;
    private float time = 0;
    private bool turnFlag = false;

    public void DisplayPlayerName(PlayerId _playerId)
    {
        this.TurnFlag();
        playerText.color = PlayerIdExtensions.ToColor(_playerId);
        switch (_playerId)
        {
            case PlayerId.Player1:
                playerText.text = "player1";
                break;
            case PlayerId.Player2:
                playerText.text = "player2";
                break;
            case PlayerId.Player3:
                playerText.text = "player3";
                break;
            case PlayerId.Player4:
                playerText.text = "player4";
                break;
        }
    }

    private void TurnFlag()
    {
        turnFlag = true;
        turnPanel.SetActive(true);
    }

    private void Update()
    {

        if (turnFlag == true)
        {
            time++;
        }

        if (time > 300)
        {
            turnFlag = false;
            turnPanel.SetActive(false);
            time = 0;
        }
    }

}
