using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Catan.Scripts.Generation
{
    public class RandomNoGeneration : MonoBehaviour
    {
   //   private static int terrainNumber = 19;
        public int[] terrainValue = new int[] { 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5 };

        /*
                Desert : 1 = 0, Mine : 3 = 1, Hill : 3 = 2, Pasture : 4 = 3, Field : 4 = 4, Forest : 4 = 5    --- Total 19

        */

        public int[] Generate()
        {
            return Shuffle(terrainValue);
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
