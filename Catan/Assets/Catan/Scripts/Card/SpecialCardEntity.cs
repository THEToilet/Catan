using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan .Scripts.Player;

namespace Catan.Scripts.Card
{

    /// <summary>
    /// CardEntity
    /// スペシャルノーマルカードの実態
    /// </summary>

    public abstract class SpecialCardEntity : MonoBehaviour
    {
        public abstract SpecialCardType type { get; }

        public PlayerId owner { get; private set; }

        public void SetParams(PlayerId _owner)
        {
            owner = _owner;
        }
    }

}
