using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using Catan.Scripts.Player;

namespace Catan.Scripts.Presenter
{
    /// <summary>
    /// CityButton押された際にクリックできるオブジェクトを生成するclass 
    /// </summary>
    public class CityPresenter : MonoBehaviour
    {
        public bool isLocate = false;
        public ToPleyerObject toPleyerObject;
        [SerializeField] GameObject cityColliderCube;
        private void Update()
        {
            CheckLocateCity().Forget();
        }
        async public void ShowPossiblePoint(PlayerId playerId)
        {
            var p = toPleyerObject.ToPlayer(playerId);
            var c = p.GetComponent<Belongings>().City;
            List<GameObject> geneCityCube = new List<GameObject>();
            for (int i = 0; i < c.Count; i++)
            {
                var g = GameObject.Instantiate(cityColliderCube, c[i].transform.position, c[i].transform.rotation);
                g.name = "CityColliderCube_" + i.ToString();
                geneCityCube.Add(g);
            }
            await CheckLocateCity();
            for (int i = 0; i < geneCityCube.Count; i++)
            {
                GameObject.Destroy(geneCityCube[i]);
            }
        }

        async UniTaskVoid CheckLocateCity()
        {
            await UniTask.WaitUntil(() => isLocate);
        }
    }
}