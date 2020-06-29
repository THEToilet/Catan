using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Catan.Scripts.Common;
using UniRx.Async;

namespace Catan.Scripts.Presenter
{

    public class DicePresenter : MonoBehaviour
    {

        public Image diceImage1;
        public Image diceImage2;
      //  public bool isDiceSpin = false;
        private int diceNum1 = 1;
        private int diceNum2 = 1;
      //  private bool isDice = false;
        public Sprite[] diceNumSprite = new Sprite[6];
        [SerializeField] GameObject DicePanel;

        private void Start()
        {
       //     ShowDice(0 ,0).Forget();
        }
        void Update()
        {
            /*
            //ダイスを回し始める&ダイスの確定
            if (Input.GetKeyDown(KeyCode.D) && isDice == false)
            {
                isDice = true;
                diceNum1 = Dice.RollOnceDice();
                diceNum2 = Dice.RollOnceDice();
            }

            //ダイスを止める＆確定したダイスの目の表示
            else if (Input.GetKeyDown(KeyCode.D) && isDice == true)
            {
                isDice = false;
                diceImage1.GetComponent<Image>().sprite = diceNumSprite[diceNum1 - 1];
                diceImage2.GetComponent<Image>().sprite = diceNumSprite[diceNum2 - 1];
                isDiceSpin = true;
            }

            //回している間のさいころの目の表示
            if (isDice)
            {
                diceImage1.GetComponent<Image>().sprite = diceNumSprite[Dice.RollOnceDice() - 1];
                diceImage2.GetComponent<Image>().sprite = diceNumSprite[Dice.RollOnceDice() - 1];
            }*/
        }

        public async UniTask ShowDice(int num1, int num2)
        {
            DicePanel.SetActive(true);
            diceImage1.GetComponent<Image>().sprite = diceNumSprite[num1 - 1];
            diceImage2.GetComponent<Image>().sprite = diceNumSprite[num2 - 1];
            await UniTask.DelayFrame(120);
            DicePanel.SetActive(false);
        }
    }

}