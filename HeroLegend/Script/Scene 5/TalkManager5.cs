using DG.Tweening.Core.Easing;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager5 : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    //public GameObject Board;
    public GameObject Score_Text;
    public GameManager5 gameManager;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] {
            "어두워서 아무것도 보이지 않는군.:0",
            "드디어 왔군.:9",
            "?!:0",
            "자네를 기다리고 있었다네.:9",
            "아니, 내가 온다는 사실을 알고 있었던 건가?:0",
            "음? 아니? 무슨 소리지?:9",
            "지금까지 내가 처치한 용사가 887명이라 매우 거슬렸는데 너의 등장으로 인해 888명을 채워 드디어 좌우대칭+상하대칭까지 맞물리는 완벽한 숫자가 되기를 기다리고 있었다는 뜻이다.:9",
            "소문대로 미친 놈이군.:0",
            "이 곳에 온 이상, 나를 <불편>하게 만드는 순간 엄청난 일을 각오해야 할 것이다.:9",
            "아, 이미 목숨은 포기할 각오로 온 것이니 상관 없으려나? 으하하.:8",
            "와라, 퍼르펙토!:0",
            "파르펙토다!!!!!!!:8"
        });
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(1000 + 4, portraitArr[4]);
        portraitData.Add(1000 + 5, portraitArr[5]);
        portraitData.Add(1000 + 6, portraitArr[6]);
        portraitData.Add(1000 + 7, portraitArr[7]);
        portraitData.Add(1000 + 8, portraitArr[8]);
        portraitData.Add(1000 + 9, portraitArr[9]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            // 짭니팡 보임
            Score_Text.SetActive(true);
            gameManager.isDialogueEnded = true;
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
