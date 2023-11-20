using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkManager1 : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    // public GameObject MainCamera;
    public GameObject MainCamera;



    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        talkData.Add(0, new string[] {"주인공 일행은 성의 마물들을 처리하고 성을 나갔다 : 0",
        "🗡️ 마물들을 처리하고 나니 배가 너무 고픈데.... : 1",
        "어!!! 어디선가 맛있는 냄새가? : 1", 
        "새로운 마을의 모든 마물들은 저번 마물들과 달리 오크의 모습을 하고 있다. : 0",
        "더욱 힘이 쎄보이고 덩치가 크다. : 0",
        "👗 헉 저 마물들은 이브르다다라 성의… : 2",
        "하지만 용사님 지금 전투로 인해 지치신 상태이니 일단 피해서 상황을 지켜봐요! : 2",
        "오크들과 마을 사람들 그리고 저잣거리에는 온갖 음식들이 더럽게 땅에 버려져 있다. : 0",
        "하지만 마물들과 사람들이 같이 붙잡혀 있는 모습이 뭔가 이상하다. : 0",
        "👗 마을 상황이 조금 이상하네요… : 2",
        "저기 식당이 있는데 한 번 들어가 볼까요? : 2",
        "아끼바리(식고문)을 통해 마물이 되어가는 주민들이 보인다. : 0",
        "👗 세상에!!! 마을 사람들이 오크로 변하는 거였어요!!! : 2", 
        "이건 틀림없이 이브르다다라 성의 `랭KING`의 짓일거예요! : 2", 
        "사람들을 아끼바리(식고문)을 통해 오크로 만들고 있는거죠! : 2",
        "🏅 나는 요리사, 세계는 내 조리기사이며 식탁은 내 전장! : 3",
        "이제 내 입 속에서 요리 대결이 벌어질 거야! : 3", 
        "음식의 맛을 모르는 무지몽매한 잡것들에게 파이프로 음식을 선사해라! : 3",
        "🗡️ (숨어서 음식을 먹으며) 그래도 맛은 있네 : 1",
        "쩝쩝!쩝쩝!쩝쩝!쩝쩝!쩝쩝!쩝쩝!쩝쩝!쩝쩝!쩝쩝!쩝쩝! : 1",
        "👗 용사님 그러고 계실 때가 아니에요!! : 2",
         "어서 용사님의 소리로 마을 사람들을 돌려주세요! : 2",
        "공격은 CTRL, 점프는 SPACE, 방어는 아래, 방향키는 앞과 위만 사용가능합니다. : 0",
        "🏅 허허, 내 적이 내 오크와 소스를 도둑질하려고 하는구나? : 3", 
        "도둑질해봐. 내 음식은 숨길 수 없는 맛이다! : 3",
        "공격은 CTRL, 점프는 SPACE, 방어는 아래, 방향키는 앞과 위만 사용가능합니다. : 0",
        "공격은 CTRL, 점프는 SPACE, 방어는 아래, 방향키는 앞과 위만 사용가능합니다. : 0"});


    }
    

    public string GetTalk(int id, int talkIdx)
    {
        if (talkIdx == 3)
        {
            MainCamera.GetComponent<ScriptCamera1>().MoveCameraOne();
            // MainCamera.animator.SetTrigg
            // animator = MainCamera.GetComponent<Animator>();

        }
        if (talkIdx == 15)
        {
            MainCamera.GetComponent<ScriptCamera1>().MoveCameraBoss();
            // animator = MainCamera.GetComponent<Animator>();

        }
        if (talkIdx == talkData[id].Length)
        {
            BossStage();
            return null;
        }
        else
            return talkData[id][talkIdx];
    }



    public void BossStage()
    {
        SceneManager.LoadScene("Scenes/Scene 1");
    }

    

}

