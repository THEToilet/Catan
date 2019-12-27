using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Common
{
    public class Dice : MonoBehaviour
    {
        public int RollOnceDice()
        {
            return Random.Range(1, 7);
        }

        public int RollTwiceDice()
        {
            return RollOnceDice() + RollOnceDice();
        }
    }
}