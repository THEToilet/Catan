using UnityEngine;
using Catan.Scripts.Terrain;
using Catan.Scripts.Territory;
using Catan.Scripts.Manager;
using Catan.Scripts.Point;

namespace Catan.Scripts.Generation
{
    public class TerritoryGenerationDecision : MonoBehaviour
    {
        public TerritoryGeneration territoryGeneration;
        public PlayerTurn playerTurn;
        private bool hasPointTerritory;
        private bool hasRoadBaseTerritory;
        public void GeneratingInstruction(GameObject _gameObject)
        {

            if ((_gameObject.name).Contains("PointChild_"))
            {
                hasPointTerritory = _gameObject.GetComponent<PointChildrenBehavior>().hasTerritory;
                if (!hasPointTerritory) // オブジェクトがおいてあったら置かない
                {
                    _gameObject.GetComponent<PointChildrenBehavior>().hasTerritory = true;
                    territoryGeneration.Generate(_gameObject.transform.position, TerritoryType.Settlement, playerTurn._currentPlayerId.Value);
                }
            }

            if ((_gameObject.name).Contains("RoadBase_"))
            {
                hasRoadBaseTerritory = _gameObject.GetComponent<RoadBaseBehavior>().hasTerritory;
                if (!hasRoadBaseTerritory) // オブジェクトがおいてあったら置かない
                {
                    _gameObject.GetComponent<RoadBaseBehavior>().hasTerritory = true;
                    territoryGeneration.Generate(_gameObject.transform.position, TerritoryType.Road, playerTurn._currentPlayerId.Value);
                }
            }
        }
    }
}
