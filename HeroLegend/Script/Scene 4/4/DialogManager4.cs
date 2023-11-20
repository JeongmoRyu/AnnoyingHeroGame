using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager4 : MonoBehaviour
{
    public TalkManager4 talkManager;
    public GameObject talkPanel;
    public Image portraitImg;   
    public Text talkText;
    public GameObject scanObject;
    public GameManager4 gameManager;
    public Camera4 camera4;

    public bool isAction;
    public int talkIndex;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData4 objData = scanObject.GetComponent<ObjData4>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);
    }

    public void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        audioSource.Play();

        // 인트로에서 몬스터가 죽을 타이밍
        if (id == 4001 && talkIndex == 6)
        {
            MonsterDead4 monsterDead = FindObjectOfType<MonsterDead4>();
            monsterDead.MonsterDead();
        }
        else if (id == 4010) // 인트로에서 할머니와의 대화 회상 타이밍
        {
            if (talkIndex == 9)
            {
                // 회색 배경을 입힐 타이밍
                PastBackground4 pastBackground4 = FindObjectOfType<PastBackground4>();
                pastBackground4.PastBackgroun4FadeIn();

            }
            else if (talkIndex == 16)
            {
                // 회색 배경을 걷을 타이밍
                PastBackground4 pastBackground4 = FindObjectOfType<PastBackground4>();
                pastBackground4.PastBackgroun4FadeOut();
            }
        }
        else if (id == 4100)
        {
            if (talkIndex == 6)
            {
                SpecialMonster4 specialMonster4 = FindObjectOfType<SpecialMonster4>();
                specialMonster4.ActivateSpecialMonster();
            }
            else if (talkIndex == 9)
            {
                SpecialMonster4 specialMonster4 = FindObjectOfType<SpecialMonster4>();
                specialMonster4.SpecialMonsterDead();
            }
            else if (talkIndex == 14)
            {
                PastBackground4 pastBackground4 = FindObjectOfType<PastBackground4>();
                pastBackground4.PastBackgroun4FadeIn();
                pastBackground4.ActivateMapUI();
            }
            else if (talkIndex == 25)
            {
                PastBackground4 pastBackground4 = FindObjectOfType<PastBackground4>();
                pastBackground4.PastBackgroun4FadeOut();
                pastBackground4.DeactivateMapUI();
            }
        }
        else if (id == 1020)
        {
            if (talkIndex == 1)
            {
                RuleUIManager ruleUIManager = FindObjectOfType<RuleUIManager>();
                ruleUIManager.ActivateRuleUI();
            }
            else if (talkIndex == 2)
            {
                RuleUIManager ruleUIManager = FindObjectOfType<RuleUIManager>();
                ruleUIManager.DeactivateRuleUI();
            }
        }

        if (talkData == null)
        {
            talkIndex = 0;
            isAction = false;

            // 보스와의 대화가 끝났다면 보스전 시작
            if (id == 100)
            {
                camera4.ZoomCamera();
                Invoke("StartLegBoss", 1.75f);
            }
            else if (id == 101)
            {
                gameManager.DeactivateResultDelieverObject();

                // 다음 지역 선택하는 곳으로 전환하자
                Invoke("GoToMap", 1f);
            }
            else if (id == 102)
            {
                gameManager.DeactivateResultDelieverObject();
            }
            else if (id == 4001)
            {
                gameManager.DeactivateResultDelieverObject();
            }
            else if (id == 4030)
            {
                // 인트로에서 문 넘어갈 때 나오는 대사였다면
                PastBackground4 pastBackground = FindObjectOfType<PastBackground4>();
                pastBackground.DeactivateResultDelieverObject2();
            }
            else if (id == 4100)
            {
                GoToMap();
            }

            return;
        }

        // 여기서 npc에 따른 분기처리도 가능
        if (isNpc)
        {
            talkText.text = talkData.Split(':')[0];

            // 초상화를 다 보여주기
            portraitImg.sprite = talkManager.GetPortrait(int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;

            // 안보이게 하기
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

    void StartLegBoss()
    {
        gameManager.SceneMove4("Scene 4 - 1");
    }

    void GoToMap()
    {
        gameManager.SceneMove4("Scenes/Village");
    }
}
