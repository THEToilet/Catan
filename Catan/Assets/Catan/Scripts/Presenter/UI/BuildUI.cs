using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildUI : MonoBehaviour
{
    public Dropdown dropdown;

    public GameObject terrainText;
    public GameObject cityText;
    public GameObject loadText;

    void Start()
    {
        if (dropdown)
        {
            List<string> list = new List<string>();
            dropdown.AddOptions(list);  //新しく要素のリストを設定する
            dropdown.value = 1;         //デフォルトを設定(0～n-1)
        }
    }

    public void Value(int value)
    {
        Debug.Log("value = " + value);  //値を取得（先頭から連番(0～n-1)）
    }

    public void BuildText(int value)
    {
        if (value == 0)
        {
            terrainText.SetActive(true);
            cityText.SetActive(false);
            loadText.SetActive(false);
        }
        else if (value == 1)
        {
            terrainText.SetActive(false);
            cityText.SetActive(true);
            loadText.SetActive(false);
        }
        else if (value == 2)
        {
            terrainText.SetActive(false);
            cityText.SetActive(false);
            loadText.SetActive(true);
        }
    }
}
