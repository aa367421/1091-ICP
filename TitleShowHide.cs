using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleShowHide : MonoBehaviour
{
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShowHide",0.5f,0.5f);  //0.5秒後呼叫ShowHide函式，並以0.5秒/次的頻率反覆呼叫
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowHide()
    {
        if ( txt.text == "")        //字體閃爍函式
        {
            txt.text = "Press \"Space Bar\" to Start";
        }
        else
        {
            txt.text = "";
        }
    }
}
