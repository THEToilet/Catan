using UnityEngine;
using Catan.Scripts.Generation;

namespace Catan.Scripts.Point
{
    public class PointParentRelevanceSetting : MonoBehaviour
    {
        public PointChildrenGeneration pointChildrenGeneration;
        public PointParentGeneration pointParentGeneration;

        // それぞれの親の点が持っている子の点
        int[][] havePoints =
        {
            new[] { 0 ,1 ,2, 3, 4, 5},          // 0
            new[] {1 ,2, 6, 7, 8 ,9},           // 1
            new[] {7 ,8 ,14 ,15 ,16 ,17},       // 2
            new[] {4 ,5 ,10 ,11 ,12, 13},       // 3
            new[] {11 ,12, 18, 19, 20 ,21},     // 4
            new[] {3 ,4 ,13 ,35 ,36, 37},       // 5
            new[] { 2, 3, 6 ,33 ,34 ,35},       // 6
            new[] {0 ,1, 9, 24, 25, 26},        // 7
            new[] {0 ,5 ,10 ,26 ,27 ,28},       // 8
            new[] {34 ,35, 36, 49, 50, 51},     // 9
            new[] {42 ,43 ,44 ,25 ,26 ,27},     // 10
            new[] {8 ,9 ,17, 22, 23, 24},       // 11
            new[] {10 ,11 ,21 ,28 ,29 ,30},     // 12
            new[] {6 ,7 ,14, 31, 32, 33},       // 13
            new[] {12 ,13 ,18 ,37 ,38 ,39},     // 14
            new[] {23 ,24 ,25 ,40 ,41, 42},     // 15
            new[] {27 ,28 ,29, 44, 45, 46},     // 16
            new[] {32 ,33 ,34, 47, 48, 49},     // 17
            new[] {36 ,37, 38, 51 ,52 ,53}      // 18
        };

        public void Allocation()
        {
            for (int i = 0; i < 19; i++)
            {
                GameObject tmpGameObject = pointParentGeneration.parentPointObjects[i];
                var setGameObject = tmpGameObject.GetComponent<PointParentBehavior>();
                setGameObject.childPoint_0 =
                        pointChildrenGeneration.childrenPointGameObjects[havePoints[i][0]];
                setGameObject.childPoint_1 =
                        pointChildrenGeneration.childrenPointGameObjects[havePoints[i][1]];
                setGameObject.childPoint_2 =
                        pointChildrenGeneration.childrenPointGameObjects[havePoints[i][2]];
                setGameObject.childPoint_3 =
                        pointChildrenGeneration.childrenPointGameObjects[havePoints[i][3]];
                setGameObject.childPoint_4 =
                        pointChildrenGeneration.childrenPointGameObjects[havePoints[i][4]];
                setGameObject.childPoint_5 =
                        pointChildrenGeneration.childrenPointGameObjects[havePoints[i][5]];
            }
        }
    }
}
