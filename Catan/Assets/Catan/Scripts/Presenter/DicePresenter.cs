using UnityEngine;
using UnityEngine.UI;
using UniRx.Async;

namespace Catan.Scripts.Presenter
{
    /// <summary>
    /// サイコロのUI表示class
    /// </summary>
    public class DicePresenter : MonoBehaviour
    {
        public Image diceImage1;
        public Image diceImage2;
        public Sprite[] diceNumSprite = new Sprite[6];
        [SerializeField] GameObject DicePanel;
        [SerializeField] Text diceText;
        public UIRestrictionPresenter uIRestrictionPresenter;

        public async UniTaskVoid ShowDice(int num1, int num2)
        {
            DicePanel.SetActive(false);
            uIRestrictionPresenter.TurnOffAll();
            DicePanel.SetActive(true);
            diceImage1.GetComponent<Image>().sprite = diceNumSprite[num1 - 1];
            diceImage2.GetComponent<Image>().sprite = diceNumSprite[num2 - 1];
            await UniTask.DelayFrame(120);
            DicePanel.SetActive(false);
            uIRestrictionPresenter.LetAction();
        }

        public void ShowDiceNum(int n)
        {
            diceText.text = n.ToString();
        }
    }
}