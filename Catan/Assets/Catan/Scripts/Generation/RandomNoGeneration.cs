using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Catan.Scripts.Generation
{
    public class RandomNoGeneration : MonoBehaviour
    {
        private static int terrainNumber = 19;
        public int[] terrainValue = new int[] { 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5 };

        /*
                Desert : 1 = 0, Mine : 3 = 1, Hill : 3 = 2, Pasture : 4 = 3, Field : 4 = 4, Forest : 4 = 5    --- Total 19
        ---------------------------------------------------------------------------------------------------------------
         +--------+---------+---------+---------+---------+---------+----------+------------+------------+------------+
         | 0      | 1       | 2       | 3       | 4       | 5       | 6        | 7          | 8          | 9          |
         | Desert | Mine[0] | Mine[1] | Mine[2] | Hill[0] | Hill[1] | Hille[2] | Pasture[0] | Pasture[1] | Pasture[2] |
         +--------+---+-----+----+----+-----+---+------+--+-------+-+---------++----------+-+---------+--+--------+---+
         | 10         | 11       | 12       | 13       | 14       | 15        | 16        | 17        | 18        |
         | Pasture[3] | Field[0] | Field[1] | Field[2] | Field[3] | Forest[0] | Forest[1] | Forest[2] | Forest[3] |
         +------------+----------+----------+----------+----------+-----------+-----------+-----------+-----------+

        */

        void Awake()
        {
            this.terrainValue = Shuffle(terrainValue);
        }
        void Start()
        {
            /*
            for (int i = 0; i < terrainNumber; i++)
            {
                Debug.Log(terrainValue[i]);
            }
            */
        }


        private int[] Shuffle(int[] array)
        {
            var length = array.Length;
            var result = new int[length];
            Array.Copy(array, result, length);

            var random = new System.Random();
            int n = length;
            while (1 < n)
            {
                n--;
                int k = random.Next(n + 1);
                var tmp = result[k];
                result[k] = result[n];
                result[n] = tmp;
            }
            return result;
        }
    }
}
