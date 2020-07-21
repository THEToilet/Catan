using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Async;
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
        public Text noteText;
        public Text nnoteText;
        public UIRestrictionPresenter uIRestrictionPresenter;
        public PlayerTurnManeger playerTurnManeger;

        async public void DisplayPlayerName(PlayerId _playerId)
        {
            uIRestrictionPresenter.TurnOffAll();
            noteText.color = PlayerIdExtensions.ToColor(_playerId);
            notePanel.SetActive(true);
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
            }// FixedUpdateのタイミングで10フレーム待つ
            await UniTask.DelayFrame(50, PlayerLoopTiming.FixedUpdate);
            notePanel.SetActive(false);
            if (playerTurnManeger._currentTurnState.Value == TurnState.NormalTurn)
            {
                uIRestrictionPresenter.Release();
            }
        }

        async public void DisplayNote(string mess)
        {
            uIRestrictionPresenter.TurnOffAll();
            nnotePanel.SetActive(true);
            nnoteText.text = mess;
            await UniTask.DelayFrame(30, PlayerLoopTiming.FixedUpdate);
            nnotePanel.SetActive(false);
            if (playerTurnManeger._currentTurnState.Value == TurnState.NormalTurn)
            {
                uIRestrictionPresenter.Release();
            }
        }


    }

}