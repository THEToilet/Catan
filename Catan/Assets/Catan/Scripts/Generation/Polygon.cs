using UnityEngine;


namespace Catan.Scripts.Generation
{

    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class Polygon : MonoBehaviour
    {
        [SerializeField] private int vertexNum = 5;

        private void Awake()
        {
            Mesh mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;

            Vector3[] vertices = new Vector3[vertexNum + 1];
            int[] triangles = new int[vertexNum * 3];

            vertices[0] = Vector3.zero;
            float angleStep = Mathf.PI * 2.0f / vertexNum;
            for (int i = 0; i < vertexNum; i++)
            {
                vertices[i + 1] = new Vector3(Mathf.Sin(i * angleStep), Mathf.Cos(i * angleStep), 0);
            }
            for (int i = 0; i < vertexNum; i++)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = (i + 2 == vertexNum + 1) ? 1 : i + 2;
            }

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();
        }
    }
}