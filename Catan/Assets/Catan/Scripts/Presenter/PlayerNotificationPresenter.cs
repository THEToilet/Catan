using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Player;

namespace Catan.Scripts.Manager
{

    public class PlayerNotificationPresenter : MonoBehaviour
    {

        public ReactiveProperty<PlayerId> _currentPlayerId;
        public PlayerTurn playerTurn;

        [SerializeField] private Text playerText;

        void Update(){
          //  Debug.Log(playerTurn._currentPlayerId.Value);
            switch(playerTurn._currentPlayerId.Value){
                case(PlayerId.Player1):
                    playerText.text = "Player1";
                    break;
                case(PlayerId.Player2):
                    playerText.text = "Player2";
                    break;
                case(PlayerId.Player3):
                    playerText.text = "Player3";
                    break;
                case(PlayerId.Player4):
                    playerText.text = "Player4";
                    break;
            }
        }

    }

}