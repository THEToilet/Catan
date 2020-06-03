using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.Scripts.Card;
using Catan.Scripts.Territory;

namespace Catan.Scripts.Player
{
    public class Belongings : MonoBehaviour
    {
        public List<GameObject> cards = new List<GameObject>();
        public List<GameObject> scards = new List<GameObject>();
        public List<GameObject> territories = new List<GameObject>();

    }
}