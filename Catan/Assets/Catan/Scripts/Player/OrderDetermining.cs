using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Common;

namespace Catan.Scripts.Player
{
    public class OrderDetermining : MonoBehaviour
    {
        public Dice dice;
        public int[] orderNum = new int[4];

        public void OrderDecide()
        {
            for (int i = 0; i < 4; i++)
            {
                orderNum[i] = dice.RollTwiceDice();
            }
        }

    }

}