using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Player;
using Catan.Scripts.Manager;

namespace Catan.Scripts.Presenter
{

    public class PlayerNotificationPresenter : MonoBehaviour
    {

        public GameObject notePanel;
        public GameObject nnotePanel;
        public ReactiveProperty<PlayerId> _currentPlayerId;
        public PlayerTurnManeger playerTurn;
        private float time = 0;
        private bool turnFlag = false;
        public Text noteText;
        private float ntime = 0;
        private bool noteFlag= false;
        public Text nnoteText;

        public void DisplayPlayerName(PlayerId _playerId)
        {
            this.TurnFlag();
            noteText.color = PlayerIdExtensions.ToColor(_playerId);
            switch (_playerId)
            {
                case PlayerId.Player1:
                    noteText.text = "player1";
                    break;
                case PlayerId.Player2:
                    noteText.text = "player2";
                    break;
                case PlayerId.Player3:
                    noteText.text = "player3";
                    break;
                case PlayerId.Player4:
                    noteText.text = "player4";
                    break;
                default:
                    noteText.text = "undfined";
                    break;
            }
        }

        public void DisplayNote(string mess)
        {
            this.NoteFlag();
            nnoteText.text = mess;
        }

        private void TurnFlag()
        {
            turnFlag = true;
            notePanel.SetActive(true);
        }
        private void NoteFlag()
        {
            noteFlag = true;
            nnotePanel.SetActive(true);
        }

        private void Update()
        {
            if (turnFlag) time++;
            if (noteFlag) ntime++;

            if (time >= 300)
            {
                turnFlag = false;
                notePanel.SetActive(false);
                this.time = 0;
            }
            
            if (ntime >= 200)
            {
                noteFlag= false;
                nnotePanel.SetActive(false);
                this.ntime = 0;
            }
        }

    }

}