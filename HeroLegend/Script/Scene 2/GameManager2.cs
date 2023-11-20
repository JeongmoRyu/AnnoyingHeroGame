using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    public int stageIndex;
    public int health;
    public int bossHealth;
    public int enemyNum;
    public bool gameClear;
    
    public PlayerDamaged2 player;
    public BossMove2 boss;
    public GameObject[] Stages;

    public Image[] UIhealth;
    public Image[] BossHealth;
    public GameObject RestartButton;
    public GameObject NextButton;
    public GameObject bossHealthBar;
    public GameObject ClearText;
    public GameObject ClearButton;
    public GameObject TutorialQuit;
    TimeManager timeManager;

    private void Awake()
    {
        timeManager = FindObjectOfType<TimeManager>();
        timeManager.setTime(0);
        DBManager.Instance.StartGame(2, NicknameManager.nickname);
        AudioManager2.instance.PlayBgm(true);
    }

    public void BossHealthDown()
    {
        // 보스 피격
        bossHealth--;
        if (bossHealth >= 0) BossHealth[bossHealth].enabled = false;

        // 보스 사망 
        if (bossHealth <= 0)
        {
            boss.OnDie();
            NextStage();
        }
    }

    public void EnemyCountDown()
    {
        if (stageIndex < Stages.Length - 1)
        {
            enemyNum--;
            
            if (enemyNum <= 0)
            {
                enemyNum = 7;
                NextButton.SetActive(true);                
            }
        }
    }

    public void NextStage()
    {

        // 스테이지 변경 
        if (stageIndex < Stages.Length - 1)
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;

            // SFX
            AudioManager2.instance.ChangeBgm(stageIndex);

            if (stageIndex == Stages.Length - 1)
            {
                bossHealthBar.SetActive(true);
            }
            Stages[stageIndex].SetActive(true);
            PlayerReposition();
        }
        else
        {
            // 게임클리어

            // SFX
            AudioManager2.instance.PlaySfx(AudioManager2.Sfx.Clear);

            // BGM 변경 
            AudioManager2.instance.ChangeBgm(3);

            // 클리어 시간 측정 및 점수 측정
            int clearTime = (int) timeManager.getTime();
            Time.timeScale = 0;
            int score = (clearTime < 480) ? 100 : (480/clearTime) * 100;

            // 점수 저장 
            DBManager.Instance.EndGame(2, NicknameManager.nickname, score, clearTime);

            // 버튼 활성화
            ClearButton.SetActive(true);
            ClearText.SetActive(true);

            gameClear = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HealthDown();

            // 플레이어 원위치
            if (health >= 1)
            {
                PlayerReposition() ;
            }
        }
    }

    public void HealthDown()
    {
        health--;
        Debug.Log(health);
        if (health >= 0) UIhealth[health].color = new Color(1, 1, 1, 0.2f);
        
        if (health <= 0)
        {
            UIhealth[health].color = new Color(1, 1, 1, 0.2f);

            // SFX
            AudioManager2.instance.PlaySfx(AudioManager2.Sfx.Die);

            // 플레이어 사망 
            player.OnDie();
            
            // 재시작 버튼 활성화
            RestartButton.SetActive(true);
        }
    }

    public void HealthUp()
    {
        if (health < 3)
        {
            UIhealth[health].color = new Color(1, 1, 1, 1);
            health++;
        }
    }

    // 플레이어 원위치 
    void PlayerReposition()
    {
        player.transform.position = new Vector3(8.5f, 2, 0);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    // 처음부터 재시작
    public void Restart()
    {
        SceneManager.LoadScene("Scene 2");
    }

    public void GoNext()
    {
        NextStage();
        NextButton.SetActive(false);
    }

    public void GoMap()
    {
        SceneManager.LoadScene("Map");
    }

    public void GoVillage()
    {
        SceneManager.LoadScene("Village");
    }
}
