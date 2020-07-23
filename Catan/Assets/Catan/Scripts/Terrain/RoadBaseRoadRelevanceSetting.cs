using UnityEngine;
using Catan.Scripts.Generation;

namespace Catan.Scripts.Terrain
{
    /// <summary>
    /// 路と隣接する路を割り当てるclass
    /// </summary>
    public class RoadBaseRoadRelevanceSetting : MonoBehaviour
    {
        public PointChildrenGeneration pointChildrenGeneration;
        public RoadGeneration roadGeneration;

        // それぞれの路が持っている路の点
        int[][] roadBaseRoads =
        { new[] {29,32,56,52},             // 0
            new[] {41,64,61,38},           // 1
            new[] {37,61,57,32},           // 2
            new[] {38,60,56,33},           // 3
            new[] {28,52,49,25},           // 4
            new[] {29,51,48,26},           // 5
            new[] {43,67,65,41},           // 6
            new[] {44,66,64,42},           // 7
            new[] {31,57,69,28},           // 8
            new[] {42,63,60,39},           // 9
            new[] {40,65,62,37},           // 10
            new[] {33,55,51,53},           // 11
            new[] {36,62,58,31},           // 12
            new[] {39,59,55,34},           // 13
            new[] {70,30,-1,-1},           // 14
            new[] {35,54,-1,-1},           // 15
            new[] {53,50,47,-1},           // 16
            new[] {27,69,24,-1},           // 17
            new[] {34,54,50,-1},           // 18
            new[] {30,58,27,-1},           // 19
            new[] {45,63,46,-1},           // 20
            new[] {68,71,40,-1},           // 21
            new[] {46,59,35,-1},           // 22
            new[] {71,70,36,-1},           // 23
            new[] {17,49,-1,-1},           // 24
            new[] {4,49,48,-1},            // 25
            new[] {5,48,47,-1},            // 26
            new[] {19,69,17,-1},           // 27
            new[] {8,69,52,4},             // 28
            new[] {0,52,51,5},             // 29
            new[] {14,58,19,-1},           // 30
            new[] {12,58,57,8},            // 31
            new[] {2,57,0,56},             // 32
            new[] {3,56,55,11},            // 33
            new[] {13,55,18,54},           // 34
            new[] {22,59,15,-1},           // 35
            new[] {23,70,62,12},           // 36
            new[] {10,62,61,2},            // 37
            new[] {1,61,60,3},             // 38
            new[] {9,60,13,59},            // 39
            new[] {21,71,65,10},           // 40
            new[] {6,65,64,1},             // 41
            new[] {7,64,63,9},             // 42
            new[] {68,67,6,-1},            // 43
            new[] {67,7,66,-1},            // 44
            new[] {66,20,-1,-1},           // 45
            new[] {20,63,22,-1},           // 46
            new[] {26,16,-1,-1},           // 47
            new[] {25,5,26,-1},            // 48
            new[] {24,4,25,-1},            // 49
            new[] {18,53,16,-1},           // 50
            new[] {11,53,29,5},            // 51
            new[] {28,4,0,29},             // 52
            new[] {11,51,50,16},           // 53
            new[] {15,34,18,-1},           // 54
            new[] {33,13,34,11},           // 55
            new[] {3,33,32,0},             // 56
            new[] {2,32,31,8},             // 57
            new[] {12,31,30,19},           // 58
            new[] {22,35,39,13},           // 59
            new[] {9,39,38,3},             // 60
            new[] {1,38,37,2},             // 61
            new[] {10,37,36,12},           // 62
            new[] {20,46,42,9},            // 63
            new[] {7,42,41,1},             // 64
            new[] {6,41,40,10},            // 65
            new[] {45,44,7,-1},            // 66
            new[] {44,43,6,-1},            // 67
            new[] {43,21,-1,-1},           // 68
            new[] {27,17,28,8},            // 69
            new[] {14,36,23,-1},           // 70
            new[] {23,21,40,-1}            // 71
        };

        public void Allocation()
        {
            for (int i = 0; i < 72; i++)
            {
                var p = roadGeneration.roads[i].GetComponent<RoadBaseBehavior>().adjacentRoadBase;
                p.Add(roadGeneration.roads[roadBaseRoads[i][0]]);
                p.Add(roadGeneration.roads[roadBaseRoads[i][1]]);
                if (roadBaseRoads[i][2] != -1)
                {
                    p.Add(roadGeneration.roads[roadBaseRoads[i][2]]);
                }
                if (roadBaseRoads[i][3] != -1)
                {
                    p.Add(roadGeneration.roads[roadBaseRoads[i][3]]);
                }
            }
        }
    }
}

