using UnityEngine;

namespace Catan.Scripts.Player
{
    /// <summary>
    /// playerの所持している物クラス
    /// </summary>
    public class PlayerCore : MonoBehaviour
    {
        [SerializeField] public PlayerId playerId;
        [SerializeField] private Belongings _belongings;
        public int playerScore = 0;
    }
}