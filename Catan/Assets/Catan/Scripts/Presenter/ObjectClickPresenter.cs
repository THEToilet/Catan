using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx.Async;
using UniRx.Async.Triggers;
using UniRx;
using UnityEngine;
using Catan.Scripts.Territory;
using Catan.Scripts.Generation;

public class ObjectClickPresenter : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    public TerritoryGeneration territoryGeneration;
    private RaycastHit hit; //レイキャストが当たったものを取得する入れ物
    GameObject gameObjectsa;

    // TODO : この機能をUniRxで実装する
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //マウスがクリックされたら
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //マウスのポジションを取得してRayに代入

            if (Physics.Raycast(ray, out hit))  //マウスのポジションからRayを投げて何かに当たったらhitに入れる
            {
                gameObjectsa = hit.collider.gameObject; //オブジェクト名を取得して変数に入れる
                Debug.Log(gameObjectsa.name); //オブジェクト名をコンソールに表示
                territoryGeneration.Generate(gameObjectsa.transform.position, TerritoryType.Settlement);

            }
        }
    }
}
