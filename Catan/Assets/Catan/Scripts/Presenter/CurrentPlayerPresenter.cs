using UnityEngine;
using Catan.Scripts.Manager;
using UnityEngine.UI;

namespace Catan.Scripts.Presenter
{
    public class CurrentPlayerPresenter : MonoBehaviour
    {
        public PlayerTurnManeger playerTurnManeger;
        [SerializeField] Text currentPlayer;
        void Update()
        {
            currentPlayer.text = playerTurnManeger._currentPlayerId.ToString();
        }
    }
}