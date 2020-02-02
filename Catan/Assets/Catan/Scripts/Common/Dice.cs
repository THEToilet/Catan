using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Common
{
    public static class Dice
    {
        public static int RollOnceDice()
        {
            int start = 1;
            int end = 7;
            return Random.Range(start, end);
        }

        // 重複を防ぐためにListを使って数字を渡している
        // しかしここで渡しているのは数字だけ
        // 主に最初の順番決めに仕様
        public static int[] RollTwiceDice()
        {
            int count = 4;

            List<int> numbers = new List<int>();

            int[] orderNum = new int[4];

            for (int i = 1; i < 7; i++)
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

        // 数字トークンを返すメソッド
        public static int[] NumberToken()
        {
            int[] token = { 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12 };

            int[] newToken = new int[token.Length];

            List<int> tokens = new List<int>();

            for (int i = 0; i < token.Length; i++)
            {
                tokens.Add(token[i]);
            }
            for (int i = 0; i < token.Length; i++)
            {
                int index = Random.Range(0, tokens.Count);

                newToken[i] = tokens[index];

                tokens.RemoveAt(index);
            }
            return newToken;
        }

        // 普段のサイコロはこっちを使う
        public static int RandomRollTwiceDice()
        {
            return RollOnceDice() + RollOnceDice();
        }
    }
}