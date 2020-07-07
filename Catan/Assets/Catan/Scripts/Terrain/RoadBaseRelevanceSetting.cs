using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Point;
using Catan.Scripts.Generation;


namespace Catan.Scripts.Terrain
{
    public class RoadBaseRelevanceSetting : MonoBehaviour
    {
        public PointChildrenGeneration pointChildrenGeneration;
        public RoadGeneration roadGeneration;

        // それぞれの子点が持っている路の点
        int[][] roadBasePoints =
        { new[] {1, 38, 61},           // 0
            new[] {61, 37, 2},            // 1
            new[] {2, 32 ,57},            // 2
            new[] {0, 56 ,32},           // 3
            new[] {0 ,3 ,33},           // 4
            new[] {60 ,38 ,56},           // 5
            new[] {8 ,31, 57},           // 6
            new[] {31 ,12 ,58},           // 7
            new[] {12 ,62 ,36},           // 8
            new[] {37 ,62 ,10},           // 9
            new[] {9, 39, 60},          // 10
            new[] {59 ,13, 39},         // 11
            new[] {13 ,34, 18},         // 12
            new[] {11 ,33 ,55},          // 13
            new[] {19 ,30, 58},          // 14
            new[] {30 ,14,-1},          // 15
            new[] {14 ,70,-1},          // 16
            new[] {23 ,36,70},          // 17
            new[] {18 ,34,54},          // 18
            new[] {15 ,54,-1},          // 19
            new[] {15 ,35,-1},          // 20
            new[] {22 ,35, 59},         // 21
            new[] {71 ,23,-1},          // 22
            new[] {21 ,40, 71},         // 23
            new[] {10 ,40 ,65},          // 24
            new[] {8 ,41, 65},         // 25
            new[] {1 ,64 ,41},          // 26
            new[] {7 ,42, 64},         // 27
            new[] {9 ,42, 63},         // 28
            new[] {20 ,46, 63},         // 29
            new[] {22 ,46,-1},          // 30
            new[] {19 ,27,-1},          // 31
            new[] {17 ,27, 69},         // 32
            new[] {8 ,69 ,28},          // 33
            new[] {4, 28 ,52},         // 34
            new[] {0 ,29 ,52},          // 35
            new[] {5 ,29, 51},         // 36
            new[] {11 ,51 ,53},         // 37
            new[] {16 ,50, 53},         // 38
            new[] {50, 18,-1},          // 39
            new[] {21 ,68,-1},          // 40
            new[] {43 ,68,-1},          // 41
            new[] {6 ,43 ,67},         // 42
            new[] {44, 67,-1},          // 43
            new[] {7 ,44, 66},         // 44
            new[] {45 ,68,-1},          // 45
            new[] {20 ,45,-1},          // 46
            new[] {17 ,24,-1},          // 47
            new[] {24 ,49,-1},          // 48
            new[] {4 ,49, 25},         // 49
            new[] {25 ,48,-1},          // 50
            new[] {5 ,26, 48},         // 51
            new[] {26 ,47,-1},          // 52
            new[] {16 ,47,-1}           // 53
        };

        public void Allocation()
        {
            for (int i = 0; i < 54; i++)
            {
                Debug.Log("unnko");
                GameObject tmpGameObject = pointChildrenGeneration.childrenPointGameObjects[i];
                var setGameObject = tmpGameObject.GetComponent<PointChildrenBehavior>();
                setGameObject.adjacentRoadBase.Add(
                             roadGeneration.roads[roadBasePoints[i][0]]);
                setGameObject.adjacentRoadBase.Add(
                        roadGeneration.roads[roadBasePoints[i][1]]);
                if (roadBasePoints[i][2] != -1)
                {
                    setGameObject.adjacentRoadBase.Add(
                           roadGeneration.roads[roadBasePoints[i][2]]);
                }
            }
        }
    }

}