using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Catan.Scripts.Presenter
{

  public class NortificationPresenter : MonoBehaviour
  {
    [SerializeField] private Text RecommendText;
    private String RecommendRoolDiceText = "サイコロを振ってください(Press 'D')";
    private String InitialArrangementText = "開拓地と路をおいてください";

    // Update is called once per frame
    void Update()
    {
    }
  }

}