using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 instance;
    [Header("# Game Control")]
    public bool isLive;
    public float gameTime;
    [Header("# Player Info")]
    public float health;
    public float maxHealth = 100;
    public float bosshealth = 1000;
    public float maxbosshealth = 1000;
    public float characterdamage;


    // public int level;
    [Header("# Game Object")]
    public PoolManager1 pool;
    public Player1 player;
    public Result1 uiResult;
    public GameObject EscapeUI;
    // TimeManager timeManager;
    // public Transform uiJoy;

    void Awake()
    {
        instance = this;
        Stop();
        // timeManager.setTime(0);

    }
    public void GameStart() 
    {
        health = maxHealth;
        isLive = true;
        // bosshealth = maxbosshealth;
        player.gameObject.SetActive(true);
        Resume();  
        AudioManager1.instance.PlayBgm(true);
        DBManager.Instance.StartGame(1, NicknameManager.Nickname);
        // timeManager = new TimeManager();
        // timeManager.setTime(0);
        
    }
    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }
    IEnumerator GameOverRoutine()
    {
        isLive = false;
        yield return new WaitForSeconds(0.5f);
        uiResult.gameObject.SetActive(true);
        uiResult.Lose();
        Stop();
        AudioManager1.instance.PlayBgm(false);
        AudioManager1.instance.PlaySfx(AudioManager1.Sfx.Lose);

    }
    public void GameVictory()
    {
        StartCoroutine(GameVictoryRoutine());
    }
    IEnumerator GameVictoryRoutine()
    {
        isLive = false;
        yield return new WaitForSeconds(0.5f);
        uiResult.gameObject.SetActive(true);
        uiResult.Win();
        Stop();

        AudioManager1.instance.PlayBgm(false);
        AudioManager1.instance.PlaySfx(AudioManager1.Sfx.Win);
        // Debug.Log(timeManager);
        // int playerTime = timeManager.getTime();
        DBManager.Instance.EndGame(1, NicknameManager.Nickname, 100, 60);

    }
    public void GameRetry()
    {
        SceneManager.LoadScene("Scenes/Scene 1");
    }
    public void NextGameStage()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Scenes/Village");
    }


    void Update()
    {
        if (!isLive)
            return;

        gameTime += Time.deltaTime;
        if (bosshealth <= 0)
        {
            GameVictory();
        }

        // if (gameTime > maxGameTime)
        // {
        //     gameTime = maxGameTime;
        //     GameVictory();
        // }
    }

    public void Stop() 
    {

        isLive = false;
        Time.timeScale = 0;
        // uiJoy.localScale = Vector3.zero;
    }
    public void Resume() 
    {
        isLive = true;
        Time.timeScale = 1;
        // uiJoy.localScale = Vector3.one;
    }

}