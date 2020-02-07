using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Dropdown dropdown;

    public GameObject knightText;
    public GameObject loadText;
    public GameObject monopolyText;
    public GameObject discoveryText;

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

    public void CardText(int value)
    {
        if (value == 0)
        {
            knightText.SetActive(true);
            monopolyText.SetActive(false);
            loadText.SetActive(false);
            discoveryText.SetActive(false);
        }
        else if (value == 1)
        {
            knightText.SetActive(false);
            monopolyText.SetActive(false);
            loadText.SetActive(true);
            discoveryText.SetActive(false);
        }
        else if (value == 2)
        {
            knightText.SetActive(false);
            monopolyText.SetActive(true);
            loadText.SetActive(false);
            discoveryText.SetActive(false);
        }
        else if (value == 3)
        {
            knightText.SetActive(false);
            monopolyText.SetActive(false);
            loadText.SetActive(false);
            discoveryText.SetActive(true);
        }
    }
}
