using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Card;
using Catan.Scripts.Player;
using Catan.Scripts.Terrain;
using Catan.Scripts.Territory;
using Catan.Scripts.Generation;
using Catan.Scripts.Point;
using Catan.Scripts.Territory.TerritoryImplementation;

namespace Catan.Scripts.Manager
{
    public class DistributeCardManeger : MonoBehaviour
    {
        public TerrainGeneration terrainGeneration;
        public PointParentGeneration pointParentGeneration;
        public ToPleyerObject toPleyerObject;
        public ToCardObject toCardObject;
        PlayerId[] playerIds = new PlayerId[4] { PlayerId.Player1, PlayerId.Player2, PlayerId.Player3, PlayerId.Player4 };

        public void Distribute(int diceNum)
        {
            List<GameObject> tmpGameObjects = new List<GameObject>();
            Debug.Log("超うんこ");
            var t = pointParentGeneration.parentPointObjects;

            for (int i = 0; i < t.Count; i++)
            {
                if (diceNum == t[i].GetComponent<PointParentBehavior>().tokenNumber)
                {
                    tmpGameObjects.Add(t[i]);
                }
            }

            for (int k = 0; k < playerIds.Length; k++)
            {
                var n = toPleyerObject.ToPlayer(playerIds[k]).GetComponent<Belongings>();
                for (int l = 0; l < n.City.Count; l++)
                {
                    for (int i = 0; i < tmpGameObjects.Count; i++)
                    {
                        for (int j = 0; j < 6; j++)
                            if (tmpGameObjects[i].GetComponent<PointParentBehavior>().childPointObjects[k].Equals(n.City[l].GetComponent<Settlement>().TerritoryPosition))
                            {
                                Debug.Log("Hello unnko");
                                n.cards.Add(toCardObject.ToCard(tmpGameObjects[i].GetComponent<PointParentBehavior>().terrainType));
                            }
                    }
                }
            }
        }

        public void InitDistribute()
        {
            Debug.Log("神うんこ");
            for (int i = 0; i < playerIds.Length; i++)
            {
                var pb = toPleyerObject.ToPlayer(playerIds[i]).GetComponent<Belongings>();
                var tt = pb.City[1].GetComponent<Settlement>().TerritoryPosition;
                Debug.Log(tt.name);
                for (int j = 0; j < pointParentGeneration.parentPointObjects.Count; j++)
                {
                    var tmp = pointParentGeneration.parentPointObjects[j].GetComponent<PointParentBehavior>();
                    Debug.Log(tmp.name);
                    for (int k = 0; k < 6; k++)
                    {
                        if (tt.Equals(tmp.childPointObjects[k]))
                        {
                            Debug.Log("真うんこ");
                            pb.cards.Add(toCardObject.ToCard(tmp.terrainType));
                        }
                    }
                }
            }
        }
    }
}
