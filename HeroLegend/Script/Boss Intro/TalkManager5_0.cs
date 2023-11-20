using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager5_0 : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;
    public Image GameRule;
    public AudioSource DialogueSound;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        // n0 ~ n9 : #n  
        talkData.Add(
            0,
            new string[] {
                "드디어 네 마왕을 모두 무찔렀군.:1",
                "그런데 공주, 지도 중앙에 있는 해골은 뭐죠?:7",
                "그곳이 이세계의 최강자인 파르펙토 마왕이 있는 곳이에요.:14",
                "지금까지 수많은 용사들이 마왕을 무찌르기 위해 도전하였으나 멀쩡하게 살아돌아온 자는 없었어요.:13",
                "운이 좋게 살아서 돌아오더라도, \n좌우대칭에 집착하게 된 용사님도 계셨고, \n말 끝에 마침표를 붙이지 않으면 말을 끝낼 수 없는 저주에 걸린 용사님도 계셨어요.:13",
                "아무래도 세계관 최강이다 보니 쉽지 않겠네요.:6",
                "대신에, 그동안의 제보를 통해 들은 사실이 하나 있어요.:8",
                "그게 뭐죠?:6",
                "ESC를 눌러서 두루마리를 확인해보세요, 용사님.:9",
                "그렇군요. 대칭 강박이라...:1",
                "shakeStart:desc",
                "shakeEnd:desc",
                "단, 주의할 점이 있어요.:14",
                "파르펙토 마왕은 그만의 고유한 필살기가 있다고 하는데, \n그것이 무엇인지는 아직 아무도 확인하지 못했다고 해요.:14",
                "그 점만 유의한다면… 용사님이 이 세계를 구하실 수 있을 거라고 생각해요.:9",
                "알겠어요. \n꼭 마왕을 무찔러서 이세계를 예전처럼 돌려놓을 수 있도록 할게요.:0",
                "보스존은 위험하니 저 혼자 다녀올게요. 공주 걱정말고 기다려요.:1",
                "(울먹) 네! 믿어요 용사님!:9"
        });
        talkData.Add(
            1,
            new string[] {
                "저 앞에 파르펙토 마왕성이 보이는 군..:6",
                "쭉 걸어가보자.:0"
        });

        // Knight
        portraitData.Add(0, portraitArr[0]);
        portraitData.Add(1, portraitArr[1]);
        portraitData.Add(2, portraitArr[2]);
        portraitData.Add(3, portraitArr[3]);
        portraitData.Add(4, portraitArr[4]);
        portraitData.Add(5, portraitArr[5]);
        portraitData.Add(6, portraitArr[6]);
        portraitData.Add(7, portraitArr[7]);

        // Princess
        portraitData.Add(8, portraitArr[8]);
        portraitData.Add(9, portraitArr[9]);
        portraitData.Add(10, portraitArr[10]);
        portraitData.Add(11, portraitArr[11]);
        portraitData.Add(12, portraitArr[12]);
        portraitData.Add(13, portraitArr[13]);
        portraitData.Add(14, portraitArr[14]);
        portraitData.Add(15, portraitArr[15]);

    }

    void Update()
    {
        // ESC 키가 눌러져 있는지 확인
        if (Input.GetKey(KeyCode.Escape))
        {
            // ESC 키가 눌러져 있으면 이미지 활성화
            GameRule.gameObject.SetActive(true);
        }
        else
        {
            // ESC 키가 눌러져 있지 않으면 이미지 비활성화
            GameRule.gameObject.SetActive(false);
        }

    }

    public string GetTalk(int idx, int talkIdx)
    {
        if (talkIdx == talkData[idx].Length)
            return null;
        else
        {
            DialogueSound.Play();
            return talkData[idx][talkIdx];
        }
    }

    public Sprite GetPortrait(int portraitIndex)
    {
        return portraitData[portraitIndex];
    }

}
