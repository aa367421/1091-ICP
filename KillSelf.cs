using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelf : MonoBehaviour
{
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,t);  //令物件在t秒後自我清除
    }

    // Update is called once per frame
    void Update()
    {

    }
}
