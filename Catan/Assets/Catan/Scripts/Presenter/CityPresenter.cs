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
        List<GameObject> geneCityCube;
        public UIRestrictionPresenter uIRestrictionPresenter;
        public void ShowPossiblePoint(PlayerId playerId)
        {
            Debug.Log("okokokoko");
            var p = toPleyerObject.ToPlayer(playerId);
            var c = p.GetComponent<Belongings>().City;
            geneCityCube = new List<GameObject>();
            for (int i = 0; i < c.Count; i++)
            {
                var g = GameObject.Instantiate(cityColliderCube, new Vector3( c[i].transform.position.x , c[i].transform.position.y + 10,c[i].transform.position.z ),Quaternion.Euler(90,0,0));
                g.name = "CityColliderCube_" + i.ToString();
                geneCityCube.Add(g);
            }
        }

        public void DeleteLocateCity()
        {
            Debug.Log("okokokoko2");
            for (int i = 0; i < geneCityCube.Count; i++)
            {
                GameObject.Destroy(geneCityCube[i]);
            }
            Debug.Log("okokokoko3");
            uIRestrictionPresenter.LetAction();
        }
    }
}