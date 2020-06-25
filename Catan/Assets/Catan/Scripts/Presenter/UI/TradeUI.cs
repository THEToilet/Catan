using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeUI : MonoBehaviour
{
    public Dropdown exportDropdown;
    public Dropdown importDropdown;
    public Dropdown dropdown;

    public GameObject unfavorableText;
    public GameObject normalText;
    public GameObject advantageousText;

    // Start is called before the first frame update
    void Start()
    {
        if (exportDropdown)
        {
            exportDropdown.options.Clear();    //現在の要素をクリアする
            exportDropdown.options.Add(new Dropdown.OptionData("木材"));//新しく要素を追加する
            exportDropdown.options.Add(new Dropdown.OptionData("小麦"));
            exportDropdown.options.Add(new Dropdown.OptionData("羊毛"));
            exportDropdown.options.Add(new Dropdown.OptionData("レンガ"));
            exportDropdown.options.Add(new Dropdown.OptionData("鉄鉱石"));
            exportDropdown.value = 1;          //デフォルトを設定(0～n-1)
        }
        if (importDropdown)
        {
            importDropdown.options.Clear();    //現在の要素をクリアする
            importDropdown.options.Add(new Dropdown.OptionData("木材"));//新しく要素を追加する
            importDropdown.options.Add(new Dropdown.OptionData("小麦"));
            importDropdown.options.Add(new Dropdown.OptionData("羊毛"));
            importDropdown.options.Add(new Dropdown.OptionData("レンガ"));
            importDropdown.options.Add(new Dropdown.OptionData("鉄鉱石"));
            importDropdown.value = 1;          //デフォルトを設定(0～n-1)
        }
        if (dropdown)
        {
            dropdown.value = 1;
        }
    }

    public void TradeText(int value)
    {
        if (value == 0)
        {
            unfavorableText.SetActive(true);
            normalText.SetActive(false);
            advantageousText.SetActive(false);
        }
        else if (value == 1)
        {
            unfavorableText.SetActive(false);
            normalText.SetActive(true);
            advantageousText.SetActive(false);
        }
        else if (value == 2)
        {
            unfavorableText.SetActive(false);
            normalText.SetActive(false);
            advantageousText.SetActive(true);
        }
    }

    /*public void InportDropdownCanged(int value)
    {
        importDropdown.options.Clear();    //現在の要素をクリアする
        if (value != 0)
        {
            importDropdown.options.Add(new Dropdown.OptionData("木材"));
        }//新しく要素を追加する
        if (value != 1)
        {
            importDropdown.options.Add(new Dropdown.OptionData("小麦"));
        }
        if (value != 2)
        {
            importDropdown.options.Add(new Dropdown.OptionData("羊毛"));
        }
        if (value != 3)
        {
            importDropdown.options.Add(new Dropdown.OptionData("レンガ"));
        }
        if (value != 4)
        {
            importDropdown.options.Add(new Dropdown.OptionData("鉄鉱石"));
        }
        importDropdown.value = 1;          //デフォルトを設定(0～n-1)

    }*/

}
