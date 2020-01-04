using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Manager
{
    public class BattleManeger : MonoBehaviour
    {
        public PlayerTurn playerTurn;
        public ProgressStateManeger progressStateManeger;
        public void Excute()
        {
            // TODO ここでplayerTurnをそれぞれのプレイヤーのスコアが10以上になるまで回す
            progressStateManeger._currentProgressState.SetValueAndForceNotify(ProgressState.Finished);
        }
    }

}