using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFunction : MonoBehaviour
{   
    public static GameFunction Instance;
    public AudioSource BackgroundMusic;         //載入標題頁（背景音樂、標題文字）
    public GameObject GameTitle , TitleText;
    int SpaceCount;     //設定參數計算玩家按Space的次數，作為轉換頁面的條件

    bool IsTutoring = false;        //載入教學頁（教學文字）
    public GameObject TutorialText , TutorialStart;

    bool IsPlaying = false;         //載入遊戲頁面（玩家、血條、計分板、敵人）

    public GameObject Player , HpText , ScoreTextObject , Enemy;
    public GameObject HpPic0 , HpPic1 , HpPic2 , HpPic3 , HpPic4 , HpPic5 , HpPic6 , HpPic7 , HpPic8 , HpPic9;
    public int EnemyMax;                         //載入遊戲參數（敵人生成數量計數、被擊次數計數、遊戲時間)
    int EnemyCount = 0 , HurtCount = 0;
    float time , EndTime;
    public AudioSource Hurt1;       //載入被擊音效、計分板文字參數、UI按鈕
    public Text ScoreText;
    public GameObject ReButtonSmall , ReTextSmall , ExitButtonSmall , ExitTextSmall;

    int KillCount = 0;       //載入擊墜敵人數量、被擊墜音效
    public AudioSource BoomSound;

    public GameObject GoodText , OverTitle , ReButton , ReText , ExitButton , ExitText;     //載入遊戲結束頁



    // Start is called before the first frame update
    void Start()
    {
        Instance = this;        //將此腳本內容設定為全域可存取、呼叫、更動
    }

    void GameTutor()     //教學頁狀態UI設定
    {
        IsTutoring = true;
        GameTitle.SetActive(false);
        TitleText.SetActive(false);
        TutorialText.SetActive(true);

        ReButtonSmall.SetActive(true);     //遊戲中熱鍵
        ReTextSmall.SetActive(true);
        ExitButtonSmall.SetActive(true);
        ExitTextSmall.SetActive(true);
    }

    void GameStart()     //遊戲狀態UI設定
    {   
        IsTutoring = false;
        TutorialText.SetActive(false);
        TutorialStart.SetActive(false); 

        IsPlaying = true;
        Player.SetActive(true);
        HpPic0.SetActive(true);
        HpText.SetActive(true);
        ScoreTextObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {   
        time += Time.deltaTime;         //設定時間參數

        if (Input.GetKeyDown(KeyCode.Space) && SpaceCount == 0)
        {
            SpaceCount += 1 ;       //標題頁至教學頁的轉換
            time = 0;           //計算教學頁閱讀說明間隔會用到，所以將time重置
            GameTutor();
        }

        if (IsTutoring == true && time > 1)     //一個閱讀說明的間隔後，指示跳出
        {
            TutorialStart.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpaceCount += 1;    //進入遊戲頁的條件式
                time = 0;       //遊戲狀態生成敵人會用到，所以將time重置
            }
        }

        if (SpaceCount == 2)    //進入遊戲狀態，同時讓SpaceCount增加，讓這個條件不被觸發
        {
            GameStart();
            SpaceCount += 1;
        }            

        if (IsPlaying == true)  //進入遊戲後將標題音樂停止
        {
            this.BackgroundMusic.Stop();
        }

        if (IsPlaying == true && EnemyCount < EnemyMax && time > 0.7f)      //決定第一隻敵人出現的時間、敵人出現的間隔
        {
            Vector3 pos = new Vector3(Random.Range(-4.2f,4.2f) , 9.3f , 0 ); //隨機給定pos(x,y,z)為(-4.2~4.2 , 9.3 , 0)範圍內的座標
            Instantiate(Enemy,pos,transform.rotation);                 //在pos生成敵人
            EnemyCount += 1;
            time = 0;
        }

        switch(HurtCount)
        {                       //以被擊次數為條件，計算並將當前血量可視化
            case 1 :
                HpPic0.SetActive(false);
                HpPic1.SetActive(true);
                break;
            case 2 :
                HpPic1.SetActive(false);
                HpPic2.SetActive(true);
                break;
            case 3 :
                HpPic2.SetActive(false);
                HpPic3.SetActive(true);
                break;
            case 4 :
                HpPic3.SetActive(false);
                HpPic4.SetActive(true);
                break;
            case 5 :
                HpPic4.SetActive(false);
                HpPic5.SetActive(true);
                break;
            case 6 :
                HpPic5.SetActive(false);
                HpPic6.SetActive(true);
                break;
            case 7 :
                HpPic6.SetActive(false);
                HpPic7.SetActive(true);
                break;
            case 8 :
                HpPic7.SetActive(false);
                HpPic8.SetActive(true);
                break;
            case 9 :
                HpPic8.SetActive(false);
                HpPic9.SetActive(true);
                break;
            case 10 :
                HpPic9.SetActive(false);
                break;
        }
 
        if (KillCount >= EnemyMax)       //設定過關標準（敵人全滅）
        {
            Succeed();
        }

        if (Input.GetKeyDown(KeyCode.R))    //可以按R鍵回到標題頁
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))   //可以按Esc退出遊戲程式
        {
            Application.Quit();
        }     
    }

    public void AddScore()      //加分函式，以EnemyCountroller和ShipController呼叫，同時計算擊殺數量
    {
        KillCount += 1;
        ScoreText.text = "Score : " + KillCount * 100;
    }

    public void Hurt()        //被擊函式，以ShipController呼叫，同時計算被擊次數並播放被擊音效
    {
        HurtCount += 1;
        Instantiate(Hurt1);
    }

    void Succeed()   //通關函式，在通關後一小段間隔跳出通關文字
    {
        EndTime += Time.deltaTime;
 
        if(EndTime > 1)
        {
             ReButtonSmall.SetActive(false);
             ReTextSmall.SetActive(false);
             ExitButtonSmall.SetActive(false);
             ExitTextSmall.SetActive(false);

             GoodText.SetActive(true);
             ReButton.SetActive(true);
             ReText.SetActive(true);
             ExitButton.SetActive(true);
             ExitText.SetActive(true);
        }
    }

    public void GameOver()  //遊戲失敗函式，以ShipController呼叫
    {
        Instantiate(BoomSound);
        IsPlaying = false;
        HpText.SetActive(false);
        ReButtonSmall.SetActive(false);
        ReTextSmall.SetActive(false);
        ExitButtonSmall.SetActive(false);
        ExitTextSmall.SetActive(false);

        OverTitle.SetActive(true);
        ReButton.SetActive(true);
        ReText.SetActive(true);
        ExitButton.SetActive(true);
        ExitText.SetActive(true);
    }
}