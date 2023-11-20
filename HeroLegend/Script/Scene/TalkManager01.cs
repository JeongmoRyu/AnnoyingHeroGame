using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TalkManager01 : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    public CameraShake0 cameraShake;
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
            "후루룩 쩝쩝쩝 후루룩 쩝쩝쩝 (달달달) 후루룩 쩝쩝쩝:1",
            "…:13",
            "후루룩 쩝쩝쩝 후루룩 쩝쩝쩝 (달달달) 후루룩 쩝쩝쩝:1",
            "자기야.:10",
            "음? 왜? 후루룩 쩝쩝쩝:1",
            "좀 조용히 먹을 수 없어?:10",
            "자기가 면치기 하니까 나한테 춘장이 다 튀잖아.:10",
            "에~ 그치만 이렇게 먹어야 더 맛있는 걸. (달달달):2",
            "젓가락질도 엉망이고…:15",
            "다리는 또 왜 이렇게 떠는 거야? 지진 난 줄 알았어.:15",
            "...알았어. 조심할게.:5",
            "하여튼... 엇, 탕수육 나왔다. (소스를 부으려 한다):9",
            "야야!!!! 붓지마!!!!:2",
            "탕수육은 찍먹이지 뭘 부으려고 해?? 진짜 큰일날 뻔했네.:4",
            "…:12"
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
        portraitData.Add(1000 + 10, portraitArr[10]);
        portraitData.Add(1000 + 11, portraitArr[11]);
        portraitData.Add(1000 + 12, portraitArr[12]);
        portraitData.Add(1000 + 13, portraitArr[13]);
        portraitData.Add(1000 + 14, portraitArr[14]);
        portraitData.Add(1000 + 15, portraitArr[15]);
    }

    public string GetTalk(int id, int talkIndex)
    {

        if (talkIndex == 0 || talkIndex == 2 || talkIndex == 7) // "달달달" 스크립트가 있을 때에만 화면 진동
        {
            cameraShake.shakeDuration = 1.0f;
        }

        if (talkIndex == talkData[id].Length)
        {
            SceneManager.LoadScene("Intro 02");
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
