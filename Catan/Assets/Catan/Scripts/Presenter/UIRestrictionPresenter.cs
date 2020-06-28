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

        public void Release()
        {
            ActionsButton.interactable = true;
            ChangeButton.interactable = true;
            RollDice.interactable = true;
        }

    }

}