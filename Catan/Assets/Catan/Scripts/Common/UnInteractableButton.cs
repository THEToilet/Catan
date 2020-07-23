using UnityEngine;
using UnityEngine.UI;

namespace Catan.Scripts.Common
{
    /// <summary>
    /// ボタンを押したら押せなくするクラス
    /// </summary>

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