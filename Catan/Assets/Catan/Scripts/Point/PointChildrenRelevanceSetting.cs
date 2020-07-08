using UnityEngine;
using Catan.Scripts.Generation;

namespace Catan.Scripts.Point
{
    public class PointChildrenRelevanceSetting : MonoBehaviour
    {

        public PointChildrenGeneration pointChildrenGeneration;
        // 隣接点
        int[][] adjacentPoint =
        {
            new[] {1, 5, 26},           // 0
            new[] {0, 9, 2},            // 1
            new[] {3, 1 ,6},            // 2
            new[] {4, 2 ,35},           // 3
            new[] {5 ,3 ,13},           // 4
            new[] {4 ,10 ,0},           // 5
            new[] {33 ,2, 7},           // 6
            new[] {8 ,14 ,6},           // 7
            new[] {9 ,7 ,17},           // 8
            new[] {1 ,24 ,8},           // 9
            new[] {11, 5, 28},          // 10
            new[] {12 ,10, 21},         // 11
            new[] {13 ,11, 18},         // 12
            new[] {12 ,27 ,4},          // 13
            new[] {7 ,31, 15},          // 14
            new[] {16 ,14,-1},          // 15
            new[] {17 ,15,-1},          // 16
            new[] {16 ,22,-1},          // 17
            new[] {19 ,39,-1},          // 18
            new[] {18 ,20,-1},          // 19
            new[] {19 ,21,-1},          // 20
            new[] {20 ,30, 11},         // 21
            new[] {17 ,23,0},          // 22
            new[] {22 ,24, 40},         // 23
            new[] {23 ,25 ,9},          // 24
            new[] {24 ,26, 42},         // 25
            new[] {0 ,25 ,27},          // 26
            new[] {26 ,28, 44},         // 27
            new[] {27 ,29, 10},         // 28
            new[] {28 ,30, 46},         // 29
            new[] {21 ,29,-1},          // 39
            new[] {14 ,32,-1},          // 31
            new[] {31 ,33, 47},         // 32
            new[] {6 ,32 ,34},          // 33
            new[] {33, 35 ,49},         // 34
            new[] {3 ,34 ,36},          // 35
            new[] {35 ,37, 51},         // 36
            new[] {36 ,38 ,13},         // 37
            new[] {37 ,39, 53},         // 38
            new[] {38, 18,-1},          // 39
            new[] {41 ,23,-1},          // 40
            new[] {40 ,42,-1},          // 41
            new[] {41 ,43 ,25},         // 42
            new[] {42, 44,-1},          // 43
            new[] {43 ,45, 27},         // 44
            new[] {44 ,46,-1},          // 45
            new[] {29 ,45,-1},          // 46
            new[] {32 ,48,-1},          // 47
            new[] {47 ,49,-1},          // 48
            new[] {34 ,48, 50},         // 49
            new[] {49 ,51,-1},          // 50
            new[] {36 ,50, 52},         // 51
            new[] {51 ,53,-1},          // 52
            new[] {38 ,52,-1}           // 53
      };

        public void Allocation()
        {
            for (int i = 0; i < 54; i++)
            {
                GameObject tmpGameObject = pointChildrenGeneration.childrenPointGameObjects[i];
                var setGameObject = tmpGameObject.GetComponent<PointChildrenBehavior>();
                setGameObject.adjacentPoint.Add(
                       pointChildrenGeneration.childrenPointGameObjects[adjacentPoint[i][0]]);
                setGameObject.adjacentPoint.Add(
                        pointChildrenGeneration.childrenPointGameObjects[adjacentPoint[i][1]]);
                if (adjacentPoint[i][2] != -1)
                {
                    setGameObject.adjacentPoint.Add(
                            pointChildrenGeneration.childrenPointGameObjects[adjacentPoint[i][2]]);
                }
            }
        }
    }

}