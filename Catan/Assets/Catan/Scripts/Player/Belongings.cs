using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Player
{
    /// <summary>
    /// プレイヤーの持ち物定義クラス
    /// </summary>
    public class Belongings : MonoBehaviour
    {
        public List<GameObject> cards = new List<GameObject>();
        public List<GameObject> scards = new List<GameObject>();
        public List<GameObject> City = new List<GameObject>();
        public List<GameObject> Road = new List<GameObject>();
    }
}