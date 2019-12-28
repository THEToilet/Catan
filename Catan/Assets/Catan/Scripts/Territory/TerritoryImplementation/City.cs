using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Territory.TerritoryImplementation
{

    public class City : TerritoryEntity
    {

        public override TerritoryType type => TerritoryType.City;
        public override Vector3 TerritoryPosition => new Vector3();
    }

}