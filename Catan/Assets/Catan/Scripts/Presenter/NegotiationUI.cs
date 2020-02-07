using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NegotiationUI : MonoBehaviour
{
    public Dropdown exportDropdown;
    public Dropdown importDropdown;
    public Dropdown partnerDropdown;

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
        if (partnerDropdown)
        {
            partnerDropdown.options.Clear();    //現在の要素をクリアする
            partnerDropdown.options.Add(new Dropdown.OptionData("全員"));//新しく要素を追加する
            partnerDropdown.options.Add(new Dropdown.OptionData("player1"));
            partnerDropdown.options.Add(new Dropdown.OptionData("player2"));
            partnerDropdown.options.Add(new Dropdown.OptionData("player3"));
            partnerDropdown.options.Add(new Dropdown.OptionData("player4"));
            partnerDropdown.options.Add(new Dropdown.OptionData("player1以外"));
            partnerDropdown.options.Add(new Dropdown.OptionData("player2以外"));
            partnerDropdown.options.Add(new Dropdown.OptionData("player3以外"));
            partnerDropdown.options.Add(new Dropdown.OptionData("player4以外"));
            partnerDropdown.value = 1;
        }
    }
}
