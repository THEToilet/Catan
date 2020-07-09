using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Catan.Scripts.Common
{

    public class DestoryButton : MonoBehaviour
    {

        Button btn;

        private void Start()
        {
            btn = GetComponent<Button>();
        }

        public void OnClick()
        {
            GameObject.Destroy(this.btn.gameObject);
        }

    }

}