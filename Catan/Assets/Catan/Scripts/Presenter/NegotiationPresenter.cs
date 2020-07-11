using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Catan.Scripts.Presenter
{

    public class NegotiationPresenter : MonoBehaviour
    {
        [SerializeField] Button submmitButton;
        [SerializeField] Button negotiationButton;


        private void Start()
        {
            negotiationButton.OnClickAsObservable()  // カードを使う　
            .Subscribe(_ => { });
            submmitButton.OnClickAsObservable().Subscribe(_ => { });
        }



    }

}