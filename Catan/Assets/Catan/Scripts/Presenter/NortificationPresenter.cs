using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Catan.Scripts.Presenter
{

  public class NortificationPresenter : MonoBehaviour
  {
    [SerializeField] private Text RecommendText;
    public DicePresenter dicePresenter;
    private String RecommendRoolDiceText = "サイコロを振ってください(Press 'D')";
    private String InitialArrangementText = "開拓地と路をおいてください";

    // Update is called once per frame
    void Update()
    {
    }

/*
    public async UniTask UnitilRollDice() // ここを初期化用として路と陣地がおかれたらに変更する
    {
      await UniTask.WaitUntil(() => dicePresenter.isDiceSpin == true); // Diceボタンが押されるまで待機
      dicePresenter.isDiceSpin = false;
    }
*/
  }
}