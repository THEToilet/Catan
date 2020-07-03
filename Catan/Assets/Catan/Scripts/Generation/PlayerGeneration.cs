using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Player;

namespace Catan.Scripts.Generation
{

    public class PlayerGeneration : MonoBehaviour
    {
        [SerializeField] private GameObject Player;

        public ToPleyerObject toPleyerObject;

        Vector3[] PlayerPoint = new Vector3[]{
            new Vector3(-50f,0,0),   // player1
            new Vector3(0,0,-50f),   // player2
            new Vector3(50f,0,0),    // player3
            new Vector3(0,0,50f)     // player4
        };

        public void Generate()
        {
            for (int i = 0; i < PlayerPoint.Length; i++)
            {
                GameObject tmpObject = GameObject.Instantiate(Player, PlayerPoint[i], Quaternion.identity);
                PlayerCore playerCore = tmpObject.GetComponent<PlayerCore>();
                switch (i)
                {
                    case (0):
                        playerCore.name = "Player1";
                        playerCore.playerId = PlayerId.Player1;
                        playerCore.GetComponent<Renderer>().material.color = PlayerIdExtensions.ToColor(PlayerId.Player1);
                        toPleyerObject.Player1 = tmpObject;
                        break;
                    case (1):
                        playerCore.name = "Player2";
                        playerCore.playerId = PlayerId.Player2;
                        playerCore.GetComponent<Renderer>().material.color = PlayerIdExtensions.ToColor(PlayerId.Player2);
                        toPleyerObject.Player2 = tmpObject;
                        break;
                    case (2):
                        playerCore.name = "Player3";
                        playerCore.playerId = PlayerId.Player3;
                        playerCore.GetComponent<Renderer>().material.color = PlayerIdExtensions.ToColor(PlayerId.Player3);
                        toPleyerObject.Player3 = tmpObject;
                        break;
                    case (3):
                        playerCore.name = "Player4";
                        playerCore.playerId = PlayerId.Player4;
                        playerCore.GetComponent<Renderer>().material.color = PlayerIdExtensions.ToColor(PlayerId.Player4);
                        toPleyerObject.Player4 = tmpObject;
                        break;
                }
                tmpObject.SetActive(false);
            }
        }
    }

}