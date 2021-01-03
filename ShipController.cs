using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public GameObject Player , Bullet;      //載入玩家物件和子彈物件、音樂和音效
    public AudioSource GameMusic , BulletSound;

    public int HP =100;     //載入飛船素質（血量、速度、射速）
    public float speed;
    float Delay = 0;
    float ShootDelay = 0;

    public GameObject EnemyBoom , PlayerBoom;       //載入爆炸動畫

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        if (ShootDelay <= 0)
        {
            ShootDelay = 0;     //當ShootDelay小於0時重置至0
        }

        if(Input.GetKey(KeyCode.UpArrow))   //以↑↓←→控制飛船，每幀以speed速度移動
        {
            this.transform.position += new Vector3( 0 , speed , 0 );
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position += new Vector3( 0 ,-speed , 0 );
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3( speed , 0 , 0 );
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += new Vector3( -speed , 0 , 0 );
        }

        if(Input.GetKey(KeyCode.Space) && (ShootDelay == Delay))       //按下空格鍵且ShootDelay值=Delay值，射擊
        {
            Vector3 pos = this.transform.position + new Vector3( 0 , 1 , 0 ); //定義pos在玩家機頭前方位置
            Instantiate(Bullet,pos,this.transform.rotation);        //在pos位置生成子彈
            Instantiate(BulletSound);           //生成子彈音效
            ShootDelay += 150;  //增加射擊延遲值
        }

        if(HP <= 0)     //死亡狀態，破壞飛船物件後生成爆炸和音效，停止音樂後播放遊戲結束頁
            {
                Die();
            }

        ShootDelay -= 10;       //每幀減少射擊延遲值
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" | other.tag =="EnemyBullet")        //角色與敵人、敵人子彈碰撞時減少十點HP，會摧毀對方物件並呼叫Hurt函式，
        {
            HP -= 10;
            GameFunction.Instance.Hurt();
            Destroy(other.gameObject);

            if (other.tag == "Enemy")   //若碰撞物件是敵人，除破壞外會額外算進GameFunction的擊殺數(KillCount)
            {
                GameFunction.Instance.AddScore(); 
                Instantiate(EnemyBoom,other.gameObject.transform.position,other.gameObject.transform.rotation);
            }
        }
    }

    public void Die()
    {
       HP = 0;
       speed = 0;
       Instantiate(PlayerBoom,this.gameObject.transform.position,this.gameObject.transform.rotation);
       Destroy(this.gameObject);
       this.GameMusic.Stop();
       GameFunction.Instance.GameOver();
    }
 }

