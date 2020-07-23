using UnityEngine;
using Catan.Scripts.Terrain;
using Catan.Scripts.Territory;
using Catan.Scripts.Manager;
using Catan.Scripts.Point;
using Catan.Scripts.Presenter;

namespace Catan.Scripts.Generation
{
    /// <summary>
    /// 陣地を置けるか判断するクラス
    /// </summary>
    public class TerritoryGenerationDecision : MonoBehaviour
    {
        public TerritoryGeneration territoryGeneration;
        public PlayerTurnManeger playerTurn;
        public TheifGeneration theifGeneration;
        public CityGeneration cityGeneration;
        private bool hasPointTerritory;
        private bool hasRoadBaseTerritory;
        public CityPresenter cityPresenter;
        public void GeneratingInstruction(GameObject _gameObject)
        {

            if ((_gameObject.name).Contains("PointChild_"))
            {
                hasPointTerritory = _gameObject.GetComponent<PointChildrenBehavior>().hasTerritory;
                if (!hasPointTerritory) // オブジェクトがおいてあったら置かない
                {
                    _gameObject.GetComponent<PointChildrenBehavior>().hasTerritory = true;
                    territoryGeneration.Generate(_gameObject.transform.position, TerritoryType.Settlement, playerTurn._currentPlayerId.Value, _gameObject);
                }
            }

            if ((_gameObject.name).Contains("RoadBase_"))
            {
                hasRoadBaseTerritory = _gameObject.GetComponent<RoadBaseBehavior>().hasTerritory;
                if (!hasRoadBaseTerritory) // オブジェクトがおいてあったら置かない
                {
                    _gameObject.GetComponent<RoadBaseBehavior>().hasTerritory = true;
                    territoryGeneration.Generate(_gameObject.transform.position, TerritoryType.Road, playerTurn._currentPlayerId.Value, _gameObject);
                }
            }

            // Theifの移動
            if ((_gameObject.name).Contains("PointParent_"))
            {
                if (!_gameObject.GetComponent<PointParentBehavior>().hasThief)
                {
                    theifGeneration.Move(_gameObject);
                }
            }

            if ((_gameObject.name).Contains("CityColliderCube_"))
            {
                cityGeneration.Generation(int.Parse(_gameObject.name.Substring("CityColliderCube_".Length)));
                cityPresenter.DeleteLocateCity();
            }
        }
    }
}
