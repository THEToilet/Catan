using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnUI : MonoBehaviour
{
    public GameObject turnPanel;
    public Text playerText;
    int turn=0;
    float time = 0;
    bool turnFlag = false;

    void PlayerName()
    {
        if (turn == 0)
        {
            playerText.text = "player1";
            playerText.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
        }
        else if (turn == 1)
        {
            playerText.text = "player2";
            playerText.color = new Color(0f / 255f, 255f / 255f, 0f / 255f);
        }
        else if (turn == 2)
        {
            playerText.text = "player3";
            playerText.color = new Color(0f / 255f, 0f / 255f, 255f / 255f);
        }
        else if (turn == 3)
        {
            playerText.text = "player4";
            playerText.color = new Color(255f / 255f, 255f / 255f, 0f / 255f);
        }
        if (turn < 3)
        {
            turn++;
        }
        else
        {
            turn = 0;
        }
    }

    void TurnFlag()
    {
        turnFlag = true;
        turnPanel.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TurnFlag();
            PlayerName();
        }

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
