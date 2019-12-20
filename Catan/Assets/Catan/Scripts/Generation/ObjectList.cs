using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Generation
{
    //Inspectorに複数データを表示するためのクラス
    [System.SerializableAttribute]
    public class ObjectList
    {
        public List<GameObject> List = new List<GameObject>();

        public ObjectList(List<GameObject> list)
        {
            List = list;
        }
    }
}