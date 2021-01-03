using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed , Rspeed , timeM , timeS;
    public int HP = 30;
    public GameObject EnemyBullet , EnemyBoom;
    public AudioSource ExplosionSound;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomMove",timeM,timeM);  //令敵人以timeM秒/次的頻率隨機移動
        InvokeRepeating("Shoot",timeS,timeS);       //令敵人以timeS秒/次的頻率射擊
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3 ( 0 , -speed , 0 );    //每幀以speed速度沿Y軸負向移動
    }

    void RandomMove()
    {
        float posX = this.transform.position.x;     //定義posX為現在之X座標
        float newposX = Random.Range(-4.2f,4.2f);   //給定newposX為-4.2~4.2之間隨機一數

        if (newposX > posX)                          //當newposX > posX時，令敵人向右移動，反之則向左
            {
                this.transform.position += new Vector3( Rspeed , 0 , 0 );
            }
        else
            {
                this.transform.position += new Vector3( -Rspeed , 0 , 0 );
            }
    }

    void Shoot()    //定義pos為敵人機頭位置，並在pos處生成子彈
    {
        Vector3 pos = this.transform.position + new Vector3( 0 , -1 , 0 );
        Instantiate(EnemyBullet,pos,this.transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Bullet")  //若敵人受到子彈碰撞，則HP減少，並摧毀子彈
        {
            HP -= 10;
            Destroy(other.gameObject);

            if(HP <= 0)     //若敵人HP<=0，則呼叫加分函式，並消除自己，生成爆炸物件以及音效
            {   
                GameFunction.Instance.AddScore(); 
                Destroy(this.gameObject);
                Instantiate(EnemyBoom,this.gameObject.transform.position,this.gameObject.transform.rotation);
                Instantiate(ExplosionSound);
            }
        }
    }
}
