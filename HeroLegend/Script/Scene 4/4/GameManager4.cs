using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager4 : MonoBehaviour
{
    public PlayerMovement4 player;
    public LegBossShape4 legBoss;
    public GameObject[] Stages;
    public DialogManager4 dialogManager;
    public GameObject resultDelieverObject;
    public GameObject talkPanel;
    public BgmManager4 bgmManager;

    public bool isIntro;

    private int curStage = 0;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (isIntro)
        {
            resultDelieverObject.SetActive(true);
            ObjData4 objData = resultDelieverObject.GetComponent<ObjData4>();
            dialogManager.Talk(objData.id, objData.isNpc);

            talkPanel.SetActive(true);
        }

        if (PlayerPrefs.GetInt("isReturnToTopDownWorld") == 1)
        {
            // 미니게임에서 돌아왔을 경우
            // 다시 0으로 초기화하자, 다음 번의 오작동을 막기 위해서
            PlayerPrefs.SetInt("isReturnToTopDownWorld", 0);
            WhenReturnToTopDownWorld();

            resultDelieverObject.SetActive(true);

            // 보스를 클리어하고 나왔을 때
            if (PlayerPrefs.GetInt("isClear4") == 1)
            {
                // dialogManager.Talk(101, true);
                resultDelieverObject.GetComponent<ObjData4>().id = 101;
            }
            else // 실패했다면
            {
                // dialogManager.Talk(102, true);
                resultDelieverObject.GetComponent<ObjData4>().id = 102;

                // 클리어 실패 시에도 브금 출력
                bgmManager.StartBgm();
            }

            // force one action (dialog)
            ObjData4 objData = resultDelieverObject.GetComponent<ObjData4>();
            dialogManager.Talk(objData.id, objData.isNpc);

            talkPanel.SetActive(true);
        }
        else
        {
            // 도전하고 나온 것이 아닌 경우(도전하러 온 것 => 브금 출력)
            bgmManager.StartBgm();
        }

        if (PlayerPrefs.GetInt("isClear4") == 1)
        {
            // 보스를 클리어하고 했을 때, (나왔을 때만 반영됨, 이후는 반영X)
            legBoss.ChangeShapeWhenClear();

            // 나중에 초기화하는 부분을 다른 적절한 곳에 넣자
            PlayerPrefs.SetInt("isClear4", 0);
        }
    }

    public void StageMove4()
    {
        // 문 여는 소리
        audioSource.Play();
        Stages[curStage].SetActive(false);

        if (curStage == 0)
        {
            PlayerReposition(new Vector3(7.5f, -3.5f, -1f));

            // 인트로라면 문 넘어갈 때 대사 출력
            if (isIntro)
            {
                PastBackground4 pastBackground = FindObjectOfType<PastBackground4>();
                pastBackground.ActivateResultDelieverObject2();

                // 대화 출력
                dialogManager.Talk(4030, true);
                talkPanel.SetActive(true);
            }
        }
        else if(curStage == 1)
        {
            PlayerReposition(new Vector3(7.5f, -7f, -1f));
        }

        curStage = 1 - curStage;
        Stages[curStage].SetActive(true);
    }

    public void SceneMove4(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void PlayerReposition(Vector3 newPos)
    {
        player.transform.position = newPos;
    }

    void WhenReturnToTopDownWorld()
    {
        curStage = 1;
        Stages[0].SetActive(false);
        Stages[1].SetActive(true);
        player.transform.position = new Vector3(7.5f, 12.7f, -1f);
    }

    public void DeactivateResultDelieverObject()
    {
        resultDelieverObject.SetActive(false);
    }
}
