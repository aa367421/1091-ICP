using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownWallFuntion : MonoBehaviour
{
    public ShipController shipcontroller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet" | other.tag == "Enemy" | other.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);      //若碰觸到的物件標籤為Bullet或Enemy則消除它

            if (other.tag == "Enemy")       //若有敵人逃走（碰到遊戲畫面底下的牆）則遊戲結束
            {
                shipcontroller.Die();
            }
        }
    }
}
