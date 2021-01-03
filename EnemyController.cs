using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public int HP = 30;
    float time1 , time2;
    public GameObject EnemyBullet , EnemyBoom;
    public AudioSource ExplosionSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time1 += Time.deltaTime;
        time2 += Time.deltaTime;

        this.transform.position += new Vector3 ( 0 , -speed , 0 );    //每幀以speed速度沿Y軸負向移動

        if (time1 > 1f)      //決定敵人左右隨機移動速度間隔
        {
            move();
            time1 = 0;
        }



        if (time2 > 0.7f)      //決定敵人射擊速度間隔
        {
            shoot();
            time2 = 0;
        }
    }

    void move()
    {
        float posX = this.transform.position.x;     //定義posX為現在之X座標
        float newposX = Random.Range(-4.2f,4.2f);   //給定newposX為-4.2~4.2之間隨機一數

        if (newposX > posX)                          //當newposX > posX時，令敵人向右移動，反之則向左
            {
                this.transform.position += new Vector3( 0.7f , 0 , 0 );
            }
        else
            {
                this.transform.position += new Vector3( -0.7f , 0 , 0 );
            }
    }

    void shoot()
    {
        Vector3 pos = this.transform.position + new Vector3( 0 , -1 , 0 );
        Instantiate(EnemyBullet,pos,this.transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Bullet")
        {
            HP -= 10;
            Destroy(other.gameObject);

            if(HP <= 0)
            {   
                GameFunction.Instance.AddScore(); 
                Destroy(this.gameObject);
                Instantiate(EnemyBoom,this.gameObject.transform.position,this.gameObject.transform.rotation);
                Instantiate(ExplosionSound);
            }
        }

    }
}
