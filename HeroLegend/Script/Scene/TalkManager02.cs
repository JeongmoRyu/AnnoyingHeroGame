using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkManager02 : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    public AudioSource DialogueSound;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] {
            "후루룩 쩝쩝쩝 후루룩 쩝쩝쩝 달달달 후루룩 쩝쩝쩝:1",
            "…진짜 짜증나서 같이 못 먹겠네!:11",
            "나 먼저 갈 테니까 맘 편하게 쩝쩝거리면서 먹어.:15",
            "어? 야! 어디 가!:2",
            "... 얘는 아깝게 이걸 다 남기고 갔네.:5",
            "후루룩 쩝쩝쩝:1",
            "♪♩젓가락질 잘해야만 밥을 먹나요 잘못해도 서툴러도 밥 잘먹어요♪♩:1",
        });

        //talkData.Add(100, new string[] { "평범한 식탁이다." });
        //talkData.Add(200, new string[] { "평범한 식탁이다." });

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
        portraitData.Add(1000 + 10, portraitArr[10]);
        portraitData.Add(1000 + 11, portraitArr[11]);
        portraitData.Add(1000 + 12, portraitArr[12]);
        portraitData.Add(1000 + 13, portraitArr[13]);
        portraitData.Add(1000 + 14, portraitArr[14]);
        portraitData.Add(1000 + 15, portraitArr[15]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            SceneManager.LoadScene("Intro 03");
            return null;
        }
        else
        {
            DialogueSound.Play();
            return talkData[id][talkIndex];
        }
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
