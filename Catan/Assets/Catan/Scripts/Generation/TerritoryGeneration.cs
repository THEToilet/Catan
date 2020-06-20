using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Presenter;
using Catan.Scripts.Territory;
using Catan.Scripts.Player;
using Catan.Scripts.Territory.TerritoryImplementation;

namespace Catan.Scripts.Generation
{
    public class TerritoryGeneration : MonoBehaviour
    {

        public ToPleyerObject toPleyerObject;
        [SerializeField] GameObject Road;
        [SerializeField] GameObject Settlement;
        [SerializeField] GameObject City;
        public ObjectClickPresenter objectClickPresenter;
        private GameObject tmpGameObject;
        private GameObject tmp;
        public void Generate(Vector3 position, TerritoryType territoryType, PlayerId playerId, GameObject _gameObject)
        {
            tmpGameObject = toPleyerObject.ToPlayer(playerId); // playerIdに対するオブジェクトを取得
            switch (territoryType)
            {
                case (TerritoryType.Road):
                    tmpGameObject.GetComponent<Belongings>().Road.Add(
                       tmp = GameObject.Instantiate(Road, new Vector3(position.x, 2f, position.z), Quaternion.Euler(0, 90, 0))
                    ) ;
                    tmp.GetComponent<Road>().TerritoryPosition = _gameObject;
                    break;
                case (TerritoryType.Settlement):
                    tmpGameObject.GetComponent<Belongings>().City.Add(
                        tmp = GameObject.Instantiate(Settlement, new Vector3(position.x, 2f, position.z), Quaternion.identity)
                    );
                    tmp.GetComponent<Settlement>().TerritoryPosition = _gameObject;
                    break;
                case (TerritoryType.City):
                    tmpGameObject.GetComponent<Belongings>().City.Add(
                        tmp = GameObject.Instantiate(City, position, Quaternion.identity)
                    );
                    tmp.GetComponent<City>().TerritoryPosition = _gameObject;
                    break;
            }

            tmp.GetComponent<Renderer>().material.color = PlayerIdExtensions.ToColor(playerId); //　生成したオブジェクトに色付ける
        }

    }
}