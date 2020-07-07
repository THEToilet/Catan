using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Point;
using Catan.Scripts.Generation;


namespace Catan.Scripts.Terrain
{
    public class RoadToChildrenRelevanceSetting : MonoBehaviour
    {
        public PointChildrenGeneration pointChildrenGeneration;
        public RoadGeneration roadGeneration;

        // それぞれの路が持っている路の点
        int[][] roadToChildre =
        { new[] {3,35},           // 0
            new[] {26,0},            // 1
            new[] {1,2},            // 2
            new[] {5,4},           // 3
            new[] {34,49},           // 4
            new[] {36,51},           // 5
            new[] {42,25},           // 6
            new[] {44,27},           // 7
            new[] {6,33},           // 8
            new[] {28,10},           // 9
            new[] {24,9},          // 10
            new[] {13,37},         // 11
            new[] {7,8},         // 12
            new[] {11,12},          // 13
            new[] {15,16},          // 14
            new[] {19,20},          // 15
            new[] {38,53},          // 16
            new[] {32,47},          // 17
            new[] {18,39},          // 18
            new[] {14,31},          // 19
            new[] {29,46},          // 20
            new[] {23,40},         // 21
            new[] {21,30},          // 22
            new[] {17,22},         // 23
            new[] {47,48},          // 24
            new[] {49,50},         // 25
            new[] {51,52},          // 26
            new[] {31,31},         // 27
            new[] {33,34},         // 28
            new[] {35,36},         // 29
            new[] {14,15},          // 30
            new[] {6,7},          // 31
            new[] {2,3},         // 32
            new[] {4,13},          // 33
            new[] {12,18},         // 34
            new[] {20,21},          // 35
            new[] {8,17},         // 36
            new[] {1,9},         // 37
            new[] {0,5},         // 38
            new[] {10,11},          // 39
            new[] {23,24},          // 40
            new[] {25,26},          // 41
            new[] {27,28},         // 42
            new[] {41,42},          // 43
            new[] {43,44},         // 44
            new[] {45,46},          // 45
            new[] {29,30},          // 46
            new[] {52,53},          // 47
            new[] {50,51},          // 48
            new[] {48,49},         // 49
            new[] {38,39},          // 50
            new[] {36,37},         // 51
            new[] {34,35},          // 52
            new[] {37,38},          // 53
            new[] {18,19},          // 54
            new[] {12,13},          // 55
            new[] {3,4},          // 56
            new[] {2,6},          // 57
            new[] {7,14},          // 58
            new[] {11,21},          // 59
            new[] {5,10},          // 60
            new[] {0,1},          // 61
            new[] {8,9},          // 62
            new[] {28,29},          // 63
            new[] {26,27},          // 64
            new[] {24,25},          // 65
            new[] {44,45},          // 66
            new[] {42,43},          // 67
            new[] {40,41},          // 68
            new[] {32,33},          // 69
            new[] {16,17},          // 70
            new[] {22,23}          // 71
        };

        public void Allocation()
        {
            for (int i = 0; i < 72; i++)
            {
                Debug.Log("unnko");
                var r = roadGeneration.roads[i].GetComponent<RoadBaseBehavior>().adjacentPointChildren;
                r.Add(pointChildrenGeneration.childrenPointGameObjects[roadToChildre[i][0]]);
                r.Add(pointChildrenGeneration.childrenPointGameObjects[roadToChildre[i][1]]);
                
            }

        }
    }
}

