using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodShowHide : MonoBehaviour
{
    public Text txt;        //載入文字區域
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShowHide", 1 , 1 );      //在1秒後呼叫ShowHide函式，並以1秒/次的頻率反覆呼叫
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowHide()     //字體閃爍函式
    {
        if ( txt.text == "")
        {
            txt.text = "拯救ㄌ世界！\n你好讚ㄟ！";
        }
        else
        {
            txt.text = "";
        }
    }
}
