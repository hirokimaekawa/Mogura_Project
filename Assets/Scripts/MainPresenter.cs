using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class MainPresenter : MonoBehaviour
{
    [SerializeField] PlayerStatusView playerStatusView;
    [SerializeField] StageView stageView1;
    [SerializeField] StageView stageView2;
    [SerializeField] StageView stageView3;
    [SerializeField] GameObject menuView;
    [SerializeField] Text finalScoreText;
    [SerializeField] GameObject finalScoreObject;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject leftTimeText;
    [SerializeField] GameObject scoreObject;
    [SerializeField] AudioClip damageSE;
    [SerializeField] AudioSource audioSource;
    PlayerModel playerModel;

    public static string nowTime;
    public static int score_num;
    public float leftTime = 20;

    public void OnRetryButton()
    {
        SceneManager.LoadScene("Main");
        FinishGameRecord();
        InitScore();
    }

    // スコアを初期化する
    void InitScore()
    {
        score_num = 0;
    }

    public void OnToTitleButton()
    {
        SceneManager.LoadScene("Title");
        FinishGameRecord();
        InitScore();
    }

    void Start()
    {
       
        playerModel = new PlayerModel();
        StartCoroutine("CreateMole1");
        StartCoroutine("CreateMole2");
        StartCoroutine("CreateMole3");
        //playerStatusView.UpdateText(playerModel);
        leftTimeText.GetComponent<Text>().text = ((int)leftTime).ToString();
        playerStatusView.UpdateText(playerModel);
    }

    IEnumerator CreateMole1()
    {
        yield return new WaitForSeconds(0.5f);
        stageView1.SpawnMonster();
    }
    IEnumerator CreateMole2()
    {
        yield return new WaitForSeconds(1.0f);
        stageView2.SpawnMonster();
    }
    IEnumerator CreateMole3()
    {
        yield return new WaitForSeconds(1.5f);
        stageView3.SpawnMonster();
    }


  
    void Update()
    {
        //1秒に1ずつ減らしていく
        leftTime -= Time.deltaTime;
        //マイナスは表示しない
        if (leftTime < 0) leftTime = 0;
       
        if (leftTime <= 0)
        {
            finalScoreText = finalScoreObject.GetComponent<Text>();
            menuView.SetActive(true);
            finalScoreText.text = scoreText.text;
            finalScoreObject.SetActive(true);

        }

        leftTimeText.GetComponent<Text>().text = "残り時間：" + ((int)leftTime).ToString();
       
    }

    public void FinishGameRecord()
    {
       
        ////拡張メソッドバージョン
        var timeArray = PlayerPrefsX.GetStringArray("NOW2");
        nowTime = System.DateTime.Now.ToString();
        timeArray = timeArray.Add(nowTime);
        PlayerPrefsX.SetStringArray("NOW2", timeArray);

        for (int i = 0; i < timeArray.Length; i++)
        {
            Debug.Log(timeArray[i]);
        }



        ////拡張メソッドバージョン
        var scoreArray = PlayerPrefsX.GetIntArray("SCORE2");
        scoreArray = scoreArray.Add(score_num);
        PlayerPrefsX.SetIntArray("SCORE2", scoreArray);　//これで保存

        for (int i = 0; i < scoreArray.Length; i++)
        {
            Debug.Log(scoreArray[i]);
        }
    }

    public void OnToHistroyButton()
    {
        SceneManager.LoadScene("Histroy");
        FinishGameRecord();
        
    }
    void RefreshpScoreText()
    {
        scoreText = scoreObject.GetComponent<Text>();
        scoreText.text = string.Format("得点: {0}", score_num);
    }
    void TouchSound()
    {
        audioSource.PlayOneShot(damageSE);
    }

    public void GetMole()
    {
        score_num += 10;
        RefreshpScoreText();
        TouchSound();
    }


}
