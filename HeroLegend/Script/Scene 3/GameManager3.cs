using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager3 : MonoBehaviour
{
    const float ORIGIN_SPEED = 3;
    public int stageIndex;
    public int health;
    private int preHealth;
    public Player3 player;
    public PlayerBoss3 playerBoss;
    public Scene3_Boss scene3_Boss;
    public GameObject[] stages;
    public GameObject playerObj;

    public static float globalSpeed;
    public static float score;
    public static bool isLive;
    public static bool isRestart;
    public static int restartObj;
    public static int tempRestartObj;
    public GameObject uiHealth;
    public GameObject uiOver;
    public GameObject uiStatus;
    public GameObject uiTime;

    public TalkManager talkManager;
    public GameObject talkPanel;
    public GameObject defaultPanel;
    public GameObject rulePanel;
    public GameObject black;
    public Image portrait;
    public Text talkText;
    public Text defaultText;
    public int talkIdx;
    public bool isAction;

    private int[] storyStages = { 0, 2, 4, 6 };
    public GameObject boss0;
    public GameObject UIMask;
    public GameObject UISlime;
    public GameObject UIBoss;
    public GameObject UIGameStart;
    public GameObject UIEnd;

    string playerName;
    string testName = "scene3test";
    public TimeManager3 timeManager;

    BGMSounder3 sounder;

    void Awake()
    {
        sounder = GetComponent<BGMSounder3>();
        isLive = true;
        isRestart = false;
        restartObj = 0;

        if (!PlayerPrefs.HasKey("Score"))
            PlayerPrefs.SetFloat("Score", 0);

        playerName = NicknameManager.Nickname;
        DBManager.Instance.InputNickname(playerName);
        StartGame(playerName);
        Talk(stageIndex);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (!isLive)
            return;

        score = health;
        globalSpeed = ORIGIN_SPEED;
    }

    public void NextStage()
    {
        if (stageIndex == 6) // Ending
        {
            EndGame(playerName);
            SceneManager.LoadScene("Scenes/Village");
        }
        // Change Stages
        if (stageIndex < stages.Length - 1)
        {
            stages[stageIndex].SetActive(false);
            stageIndex++;
            stages[stageIndex].SetActive(true);
        }

        if (storyStages.Contains(stageIndex)) // Story Scene
        {
            EndScene(playerName);
            preHealth = health;
            playerObj.SetActive(false);
            uiHealth.SetActive(false);
            uiStatus.SetActive(false);
            uiTime.SetActive(false);
            Talk(stageIndex);
        } else // Game Scene
        {
            GameStartUI();
            StartScene(playerName);
            if (stageIndex == 5) // Boss
            {
                uiHealth.SetActive(true);
                uiStatus.SetActive(true);
                uiTime.SetActive(true);
            }
            else
            {
                playerObj.SetActive(true);
                uiHealth.SetActive(true);
                uiStatus.SetActive(true);
                uiTime.SetActive(true);
            }
            Invoke("GameStartUIEnd", 1);
        }
    }

    public void HealthDown()
    {
        if (health > 1)
        {
            health--;
        }
        else
        {
            // Player Die Effect
            if (stageIndex == 5)
            {
                playerBoss.OnDie();
            }
            else
            {
                player.OnDie();
            }

            uiOver.SetActive(true);
            isLive = false;
        }
    }

    void Talk(int stage)
    {
        string talkData = talkManager.GetTalk(stage, talkIdx);

        if (talkData == null)
        {
            isAction = false;
            talkIdx = 0;
            talkPanel.SetActive(false);
            defaultPanel.SetActive(false);
            NextStage();
            return;
        }

        if (talkData.Split(":")[1] == "default")
        {
            defaultPanel.SetActive(true);
            defaultText.text = talkData.Split(":")[0];
        }
        else if (talkData.Split(":")[1] == "desc")
        {
            switch (talkData.Split(":")[0])
            {
                case "ruleStart":
                    rulePanel.SetActive(true);
                    break;
                case "ruleEnd":
                    rulePanel.SetActive(false);
                    break;
                case "blackStart":
                    black.SetActive(true);
                    break;
                case "blackEnd":
                    black.SetActive(false);
                    break;
                case "blackShockStart":
                    black.SetActive(true);
                    defaultPanel.SetActive(true);
                    sounder.PlaySound(BGMSounder3.BGMSfx.Trouble);
                    defaultText.text = "쾅!!!!!!!!!!!!!";
                    break;
                case "blackShockEnd":
                    defaultPanel.SetActive(false);
                    black.SetActive(false);
                    break;
                case "moveBoss":
                    boss0.transform.Translate(-7.5f, -2f, 0, Space.Self);
                    break;
                case "blackBossStart":
                    sounder.PlaySound(BGMSounder3.BGMSfx.Stage);
                    black.SetActive(true);
                    UIMask.SetActive(true);
                    break;
                case "blackBossEnd":
                    black.SetActive(false);
                    UIMask.SetActive(false);
                    isAction = false;
                    talkIdx = 0;
                    talkPanel.SetActive(false);
                    defaultPanel.SetActive(false);
                    NextStage();
                    break;
                case "slimeChangeStart":
                    black.SetActive(true);
                    UISlime.SetActive(true);
                    sounder.PlaySound(BGMSounder3.BGMSfx.Boss);
                    break;
                case "slimeChangeEnd":
                    black.SetActive(false);
                    UISlime.SetActive(false);
                    isAction = false;
                    talkIdx = 0;
                    talkPanel.SetActive(false);
                    defaultPanel.SetActive(false);
                    NextStage();
                    break;
                case "bossEndStart":
                    black.SetActive(true);
                    UIBoss.SetActive(true);
                    break;
                case "bossEndEnd":
                    black.SetActive(false);
                    UIBoss.SetActive(false);
                    sounder.PlaySound(BGMSounder3.BGMSfx.End);
                    break;
                case "GameEnd":
                    black.SetActive(true);
                    UIEnd.SetActive(true);
                    break;
                default:
                    break;
            }
        }
        else
        {
            talkPanel.SetActive(true);
            talkText.text = talkData.Split(":")[0];
            portrait.sprite = talkManager.GetPortrait(int.Parse(talkData.Split(":")[1]));
        }

        isAction = true;
        talkIdx++;
    }

    public void Action()
    {
        talkPanel.SetActive(false);
        defaultPanel.SetActive(false);
        Talk(stageIndex);
    }

    public void Restart()
    {
        health = preHealth;
        uiOver.SetActive(false) ;
        Time.timeScale = 1;
        isRestart = true;
        isLive = true;
        if (stageIndex == 5)
        {
            playerBoss.ChangeAnim(0);
            playerBoss.transform.GetChild(1).gameObject.SetActive(true);
            playerBoss.gameObject.layer = 8;
            scene3_Boss.GetComponent<Scene3_Boss>().Think();
        }
        else
        {
            player.ChangeAnim(Player3.State.Run);
            player.transform.GetChild(1).gameObject.SetActive(true);
            player.gameObject.layer = 8;
        }
    }

    public void StartGame(string nickname)
    {
        DBManager.Instance.StartGame(3, nickname);
    }

    public void EndGame(string nickname)
    {
        DBManager.Instance.EndGame(3, nickname, (int)score * 10, (int)timeManager.getTime());
    }

    public void StartScene(string nickname)
    {
        PlayingClass data = DBManager.Instance.StartScene(3, nickname);
        TimeManager3.countTime = true;
        Debug.Log("점수 :: " + data.getScore());
        Debug.Log("시간 :: " + data.getPlayTime());
    }

    public void EndScene(string nickname)
    {
        DBManager.Instance.ChangeScene(3, stageIndex - 1, nickname, (int)score, (int)timeManager.getTime());
        TimeManager3.countTime = false;
    }

    public void GameStartUI()
    {
        UIGameStart.SetActive(true);
    }

    public void GameStartUIEnd()
    {
        UIGameStart.SetActive(false);
    }
}
