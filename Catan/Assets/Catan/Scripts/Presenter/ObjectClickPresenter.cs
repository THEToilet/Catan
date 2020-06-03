using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx.Async;
using UniRx.Async.Triggers;
using UniRx;
using UnityEngine;
using Catan.Scripts.Territory;
using Catan.Scripts.Generation;
using Catan.Scripts.Player;
using Catan.Scripts.Manager;
using Catan.Scripts.Point;
using Catan.Scripts.Terrain;

public class ObjectClickPresenter : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    public TerritoryGenerationDecision terrainGenerationDecision;
    private RaycastHit hit; //レイキャストが当たったものを取得する入れ物
    GameObject getedGameObject;
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
                getedGameObject = hit.collider.gameObject; //オブジェクト名を取得して変数に入れる
                Debug.Log(getedGameObject.name); //オブジェクト名をコンソールに表示
                terrainGenerationDecision.GeneratingInstruction(getedGameObject); // 地形生成命令本部
            }
        }
    }
}
