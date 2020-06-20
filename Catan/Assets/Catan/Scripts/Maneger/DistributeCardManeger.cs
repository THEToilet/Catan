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
        private List< GameObject> tmpGameObjects = new List<GameObject>();
        public ToPleyerObject toPleyerObject;
        public ToCardObject toCardObject;
        PlayerId[] playerIds = new PlayerId[4] { PlayerId.Player1, PlayerId.Player2, PlayerId.Player3, PlayerId.Player4 };

        public void Distribute(int diceNum)
        {
            var t = pointParentGeneration.parentPointObjects ;// 地形がある

            for(int i=0;i<t.Count; i++){
                if(diceNum == t[i].GetComponent<PointParentBehavior>().tokenNumber){
                    tmpGameObjects.Add(t[i]);
            }
            }
            for(int i=0;i<tmpGameObjects.Count;i++){
                for(int j=0;j<6;j++){
                   // if(tmpGameObjects[i].childPoint[j] == ture){

                        //Get PlayerId => add Playerd Belongings card Terrain Type
                    //}
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
