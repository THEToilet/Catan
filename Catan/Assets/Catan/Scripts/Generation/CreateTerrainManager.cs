using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Catan.Manager
{

    public class CreateTerrainManager : MonoBehaviour
    {
        [SerializeField] GameObject Forest;
        [SerializeField] GameObject Hill;
        [SerializeField] GameObject Mine;
        [SerializeField] GameObject Pasture;
        [SerializeField] GameObject Field;
        [SerializeField] GameObject Desert;
        // Start is called before the first frame update
        void Start()
        {
            GameObject.Instantiate(Forest, new Vector3(2.0F, 0, 0), Quaternion.identity);

            // Update is called once per frame
        }

    }
}