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
        [SerializeField] GameObject playerSelectionPanel;
        [SerializeField] Button player1SelectButton;
        [SerializeField] Button player2SelectButton;
        [SerializeField] Button player3SelectButton;
        [SerializeField] Button player4SelectButton;

        private void Start()
        {
            negotiationButton.OnClickAsObservable()  // カードを使う　
            .Subscribe(_ => { });
            submmitButton.OnClickAsObservable().Subscribe(_ => { });
        }



    }

}