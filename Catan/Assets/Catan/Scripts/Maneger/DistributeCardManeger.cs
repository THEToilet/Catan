using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Card;
using Catan.Scripts.Player;
using Catan.Scripts.Terrain;
using Catan.Scripts.Territory;
using Catan.Scripts.Generation;

namespace Catan.Scripts.Manager
{
    public class DistributeCardManeger : MonoBehaviour
    {
        public TerrainGeneration terrainGeneration;
        private GameObject[] tmpGameObjects;
        [SerializeField] GameObject BrickCard;
        [SerializeField] GameObject IronOre;
        [SerializeField] GameObject WheatCard;
        [SerializeField] GameObject WoodCard;
        [SerializeField] GameObject WoolCard;
        // terrainGeneration.terainObjectsColledtions 地形がある
        // Start is called before the first frame update
        
        public void Distribute(int diceNum)
        {
            /*
            for(int i=0;i<terrainGeneration.terrainObjectCollections.size();i++){
                if(dicNum == terrainGeneration.terrainObjectscollections[i]){
                    tempObjects.add(terrainGeneration.terrainObjectscollections[i])
                }
            }
            for(int i=0;i<tmpGameObjects.lengh;i++){
                for(int i=0;i<6;i++){
                    if(tmpGameOBjects[i].childPoint[i] == ture){
                        //Get PlayerId => add PlayerId Belongings card Terrain Type
                    }
                }
            }*/

            // でた数字からその数字に値するトークンを持っている地形に隣接する人にカードをあげる
        }
        public void Distribute2(GameObject Point)
        {
            /*
            for(int i=0;i<terrainGeneration.terrainObjectCollections.size();i++){
                if(dicNum == terrainGeneration.terrainObjectscollections[i]){
                    tempObjects.add(terrainGeneration.terrainObjectscollections[i])
                }
            }
            for(int i=0;i<tmpGameObjects.lengh;i++){
                for(int i=0;i<6;i++){
                    if(tmpGameOBjects[i].childPoint[i] == ture){
                        //Get PlayerId => add PlayerId Belongings card Terrain Type
                    }
                }
            }
*/
            // でた数字からその数字に値するトークンを持っている地形に隣接する人にカードをあげる
        }
    }
}
