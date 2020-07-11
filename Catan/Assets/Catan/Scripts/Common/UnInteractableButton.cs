using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Catan.Scripts.Common
{

public class UnInteractableButton : MonoBehaviour
{
        Button btn;

        private void Start()
        {
            btn = GetComponent<Button>();
        }

        public void OnClick()
        {
            btn.interactable = false; 
        }
    }

}