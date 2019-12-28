using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Manager
{
    public class BattleManeger : MonoBehaviour
    {
        public PlayerTurn playerTurn;
        public ProgressStateManeger progressStateManeger;

        void Start()
        {

        }
        public void Excute()
        {
            //playerTurn.DescendingOrderTurnState();
            progressStateManeger._currentProgressState.SetValueAndForceNotify(ProgressState.Finished);
        }
    }

}