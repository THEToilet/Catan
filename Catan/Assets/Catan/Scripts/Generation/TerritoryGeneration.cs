using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Presenter;
using Catan.Scripts.Territory;

namespace Catan.Scripts.Generation
{

    public class TerritoryGeneration : MonoBehaviour
    {
        [SerializeField] GameObject Road;
        [SerializeField] GameObject Settlement;
        [SerializeField] GameObject City;
        public ObjectClickPresenter objectClickPresenter;
        // Start is called before the first frame update
        public void Generate(Vector3 position, TerritoryType territoryType){
            switch(territoryType){
                case(TerritoryType.Road):
                    GameObject.Instantiate(Road,position,Quaternion.identity);
                    break;
                case(TerritoryType.Settlement):
                    GameObject.Instantiate(Settlement,position,Quaternion.identity);
                    break;
                case(TerritoryType.City):
                    GameObject.Instantiate(City,position,Quaternion.identity);
                    break;
            }
        }
    }

}