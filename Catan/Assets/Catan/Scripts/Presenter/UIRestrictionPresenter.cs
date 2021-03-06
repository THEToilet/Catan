﻿using UnityEngine;
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
            RollDice.interactable = true;
            RollDice.gameObject.SetActive(true);
            ChangeButton.interactable = true;
        }
        public void LetAction()
        {
            ActionsButton.interactable = true;
            ChangeButton.interactable = true;
            RollDice.gameObject.SetActive(false);
        }

        public void TurnOffAll()
        {
            ActionsButton.interactable = false;
            RollDice.interactable = false;
            ChangeButton.interactable = false;
        }

        public void TurnOffRollDice()
        {
            RollDice.gameObject.SetActive(false);
        }
        public void Release()
        {
            ActionsButton.interactable = true;
            ChangeButton.interactable = true;
            RollDice.gameObject.SetActive(true);
            RollDice.interactable = true;
        }

        public void ReleaseExpectAction()
        {
            ChangeButton.interactable = true;
            RollDice.interactable = false;

        }
    }
}