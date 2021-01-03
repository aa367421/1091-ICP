using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shine : MonoBehaviour
{
    public Text txt;
    public float t;
    public string s;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShowHide",t,t);  //t秒後呼叫ShowHide函式，並以t秒/次的頻率反覆呼叫
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowHide()
    {
        if ( txt.text == "")        //字體閃爍函式
        {
            txt.text = s;
        }
        else
        {
            txt.text = "";
        }
    }
}
