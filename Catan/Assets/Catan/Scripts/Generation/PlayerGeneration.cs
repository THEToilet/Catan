using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Player;

namespace Catan.Scripts.Generation
{

    public class PlayerGeneration : MonoBehaviour
    {
        [SerializeField] private GameObject Player;


        Vector3[] PlayerPoint = new Vector3[]{
            new Vector3(-40f,0,0),   // player1
            new Vector3(0,0,-40f),   // player2
            new Vector3(40f,0,0),    // player3
            new Vector3(0,0,40f)     // player4
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
                        playerCore.Initialize(PlayerId.Player1);
                        playerCore.name = "Player1";
                        playerCore.GetComponent<Renderer>().material.color = PlayerIdExtensions.ToColor(PlayerId.Player1);
                        break;
                    case (1):
                        playerCore.Initialize(PlayerId.Player2);
                        playerCore.name = "Player2";
                        playerCore.GetComponent<Renderer>().material.color = PlayerIdExtensions.ToColor(PlayerId.Player2);
                        break;
                    case (2):
                        playerCore.Initialize(PlayerId.Player3);
                        playerCore.name = "Player3";
                        playerCore.GetComponent<Renderer>().material.color = PlayerIdExtensions.ToColor(PlayerId.Player3);
                        break;
                    case (3):
                        playerCore.Initialize(PlayerId.Player4);
                        playerCore.name = "Player4";
                        playerCore.GetComponent<Renderer>().material.color = PlayerIdExtensions.ToColor(PlayerId.Player4);
                        break;
                }
            }
        }
    }

}