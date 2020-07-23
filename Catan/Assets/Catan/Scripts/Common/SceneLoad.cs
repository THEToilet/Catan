using UnityEngine;
using UnityEngine.SceneManagement;

namespace Catan.Scripts.Common
{
    /// <summary>
    /// シーン遷移クラス
    /// </summary>
    public class SceneLoad : MonoBehaviour
    {
        public void ToMain()
        {
            SceneManager.LoadScene("Main");
        }
        public void ToTitle()
        {
            SceneManager.LoadScene("Title");
        }
    }
}