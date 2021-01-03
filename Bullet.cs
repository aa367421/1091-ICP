using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0,BulletSpeed,0); //令子彈以每幀BulletSpeed速度沿Y軸移動
    }
}
