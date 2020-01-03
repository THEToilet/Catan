using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickPresenter : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    private RaycastHit hit; //レイキャストが当たったものを取得する入れ物

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
                string objectName = hit.collider.gameObject.name; //オブジェクト名を取得して変数に入れる
                Debug.Log(objectName); //オブジェクト名をコンソールに表示
            }
        }
    }
}
