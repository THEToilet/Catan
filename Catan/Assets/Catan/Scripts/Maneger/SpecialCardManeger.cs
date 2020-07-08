using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

namespace Catan.Scripts.Manager
{

    public class SpecialCardManeger : MonoBehaviour
    {

        public TheifManeger theifManeger;

        public void Knight()
        {
            Debug.Log("Knight");
            theifManeger.MoveTheif();
        }

        public void MainRoad()
        {
            // 路を二つ置く
            Debug.Log("MainRoad");
        }

        public void Harvest()
        {
            Debug.Log("Harvest");
            // 資源カードを二枚もらえる
        }

        public void Monopolization()
        {
            Debug.Log("Monopolization");
               // 指定した資源一種類全部もらえる
        }


    }

}