using UnityEngine;

namespace Catan.Scripts.Player
{

    public class PlayerCore : MonoBehaviour
    {
        [SerializeField] public PlayerId playerId;
        [SerializeField] private Belongings _belongings;
        public int playerScore = 0;

    }
}