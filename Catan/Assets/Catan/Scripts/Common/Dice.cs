using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Common
{
    public class Dice : MonoBehaviour
    {
        List<int> numbers = new List<int>();
        int start = 1;
        int end = 7;
        int count = 4;
        int[] orderNum = new int[4];
        public int RollOnceDice()
        {
            return Random.Range(start, end);
        }

        // 重複を防ぐためにListを使って数字を渡している
        // しかしここで渡しているのは数字だけ
        public int[] RollTwiceDice()
        {
            for (int i = 0; i < 7; i++)
            {
                numbers.Add(i);
            }
            for (int i = 0; i < count; i++)
            {
                int index = Random.Range(0, numbers.Count);

                orderNum[i] = numbers[index];

                numbers.RemoveAt(index);
            }
            return orderNum;
        }

        public int RandomRollTwiceDice()
        {
            return RollOnceDice() + RollOnceDice();
        }



    }
}