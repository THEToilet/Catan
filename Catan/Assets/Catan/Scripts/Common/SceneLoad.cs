using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Catan.Scripts.Common
{

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