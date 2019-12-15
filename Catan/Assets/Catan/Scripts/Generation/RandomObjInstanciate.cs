using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.Scripts.Generation
{
    public class RandomObjInstanciate : MonoBehaviour
    {

        [SerializeField]
        private GameObject point;

        [SerializeField]
        int batchNum = 1;

        private static int hexagon = 6;

        [SerializeField] int pointTotalNumber = 54;

        Vector3 cubeSize;
        Vector3 offset;
        const float min = -0.5f;
        const float max = 0.5f;

        private void Awake()
        {
            Vector3[] vertices = new Vector3[hexagon + 1];
            Vector3[] centerVertics = new Vector3[19];
                HexagonGeneration(1);

        }

        private void HexagonGeneration(int _point)
        {
            Vector3[] vertices = new Vector3[hexagon + 1];

            // 点生成
            vertices[0] = Vector3.zero;
            float angleStep = Mathf.PI * 2.0f / hexagon; // 1/3*π
            for (int i = 0; i < hexagon; i++)
            {
                vertices[i + 1] = new Vector3(Mathf.Sin(i * angleStep), 0, Mathf.Cos(i * angleStep));
            }

            for (int i = 0; i < hexagon + 1; i++)
            {
                GameObject obj = Instantiate(point, vertices[i], Quaternion.identity);
                obj.name = obj.name.Replace("(Clone)", "_" + i.ToString());
            }


            Vector3[] vertices2 = new Vector3[12 + 1];
            angleStep = Mathf.PI * 2.0f / 12;

            for (int i = 0; i < 12; i++)
            {
                vertices2[i + 1] = new Vector3(Mathf.Sin(i * angleStep)*2, 0, Mathf.Cos(i * angleStep)*2);
            }

            for (int i = 0; i < 12 + 1; i++)
            {
                GameObject obj = Instantiate(point, vertices2[i], Quaternion.identity);
                obj.name = obj.name.Replace("(Clone)", "_" + (i+7).ToString());
            }


        }

        /*
                void Start()
                {
                    cubeSize = gameObject.transform.localScale;
                    offset = gameObject.transform.localPosition;
                }

                void Update()
                {
                    InstantiateSmallCubeAtRandom();
                }

                void InstantiateSmallCubeAtRandom()
                {
                    // オブジェクトを立方体内のランダムな位置にインスタンス化する
                    for (int i = 1; i <= batchNum; i++)
                    {
                        float xPos = GetRandomRangeInCube() * cubeSize.x;
                        float yPos = GetRandomRangeInCube() * cubeSize.y;
                        float zPos = GetRandomRangeInCube() * cubeSize.z;
                        Vector3 position = new Vector3(xPos, yPos, zPos) + offset;

                        // Prefabをインスタンス化する
                        GameObject obj = Instantiate(cubePrefab, position, Quaternion.identity);
                        obj.transform.SetParent(gameObject.transform);
                    }
                }

                float GetRandomRangeInCube()
                {
                    float randomRange = Random.Range(min, max);
                    return randomRange;
                }
                */
    }
}