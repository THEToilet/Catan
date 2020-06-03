using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Player;

namespace Catan.Scripts.Territory
{
    public abstract class TerritoryEntity : MonoBehaviour
    {
        public abstract TerritoryType type { get; }

        public abstract Vector3 TerritoryPosition { get;}

    }

}
