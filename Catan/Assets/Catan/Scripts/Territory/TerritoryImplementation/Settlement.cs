using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Territory.TerritoryImplementation
{

    public class Settlement : TerritoryEntity
    {

        public override TerritoryType type => TerritoryType.Settlement;
        public override Vector3 TerritoryPosition => new Vector3();
    }

}