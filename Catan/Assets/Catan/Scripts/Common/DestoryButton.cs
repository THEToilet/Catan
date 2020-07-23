using UnityEngine;
using UnityEngine.UI;

namespace Catan.Scripts.Common
{
    /// <summary>
    /// ボタンを押したらボタンを消すクラス
    /// </summary>
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