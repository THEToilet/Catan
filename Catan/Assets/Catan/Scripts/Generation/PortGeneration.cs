using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Catan.Scripts.Generation
{
    public class PortGeneration : MonoBehaviour
    {
        [SerializeField] GameObject portGameObject;
        [SerializeField] Sprite brick;
        [SerializeField] Sprite wood;
        [SerializeField] Sprite wool;
        [SerializeField] Sprite iron;
        Sprite[] sprites = new Sprite[5];
        public List<GameObject> portObjectCollections = new List<GameObject>();
        // 3:1の点4つ
        // 2:1の点5つ　羊は二つ
        Vector3[] portPoints = new Vector3[]{
            new Vector3(22f,0,-4.5f),                // 0 brick
            new Vector3(14.5f,0,-18.5f),             // 1 wood
            new Vector3(-13.5f,0,-18.5f),             // 2 wool
            new Vector3(-21.5f,0,-4f),              // 3 ironore
            new Vector3(-7.5f,0,23.5f),               // 4 wool
            new Vector3(0,0,-28f),            // 5 3:1
            new Vector3(-21.5f,0,14.5f),           // 6 3:1
            new Vector3(7.5f,0,23.5f),          // 7 3:1
            new Vector3(21.5f,0,14.5f),           // 8 3:1
        };

        int[] rotate = new int[] { 45, 125, -125, -125, 0, -185, -54, 0, 45 };
        //parentGameObjectは親要素のgameObject
        //GameObject obj = parentGameObject.transform.GetChild(0).gameObject;
        private void Awake()
        {
            sprites[0] = brick;
            sprites[1] = wood;
            sprites[2] = wool;
            sprites[3] = iron;
            sprites[4] = wool;
        }
        public void Generate()
        {
            GameObject tmpGameObject;
            for (int i = 0; i < portPoints.Length; i++)
            {
                tmpGameObject = GameObject.Instantiate(portGameObject, portPoints[i], Quaternion.Euler(90, rotate[i], 0));
                tmpGameObject.name = "PortGameObject_" + i;
                portObjectCollections.Add(tmpGameObject);
                if (i >= 0 && i <= 4)
                {
                    tmpGameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = sprites[i];
                    tmpGameObject.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = "2 : 1";
                }
                else
                {
                    tmpGameObject.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = "3 : 1";
                }
            }
        }
    }

}