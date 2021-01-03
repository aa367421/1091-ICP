using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float EnemyBulletSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        this.transform.position += new Vector3(0,-EnemyBulletSpeed,0); //令子彈以每幀EnemyBulletSpeed速度沿Y軸負向移動
    }
}
