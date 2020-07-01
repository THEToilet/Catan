using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Catan.Scripts.Presenter
{

    public class UIRestrictionPresenter : MonoBehaviour
    {

        [SerializeField] Button ActionsButton;
        [SerializeField] Button ChangeButton;
        [SerializeField] Button RollDice;

        public void LetRollDice()
        {
            ActionsButton.interactable = false;
        }

        public void TurnOffAll()
        {
            ActionsButton.interactable = false;
            RollDice.interactable = false;
        }

        public void TurnOffRollDice()
        {
            RollDice.gameObject.SetActive(false);
        }
        public void Release()
        {
            ActionsButton.interactable = true;
            ChangeButton.interactable = true;
            RollDice.interactable = true;
        }

        public void ReleaseExpectAction()
        {
            ChangeButton.interactable = true;
            RollDice.interactable = false;

        }

    }

}