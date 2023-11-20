using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkManager992 : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    public CameraShake99 cameraShake;
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
            "네 놈의 최후의 만찬을 가져왔다!:8",
            "...:8",
            "용사?...:8",
            "어디로 갔지? 숨어봤자 소용 없다!:9",
            "내 마지막 공격을 받아라!!:3",
            "아, 아니?!:9",
            "이럴 줄 알았다!!!:1",
            "이 감옥은 완벽한 대칭을 이루고 있어서, 심지어 반대편 감옥 칸에는 내 모형까지 들여 놓았더군...:1",
            "크흑, 당장 날 풀어줘!!:9",
            "마왕. 마지막으로 너의 가장 치명적인 약점을 알려주지.:4",
            "뭐? 이 완벽한 나에게 약점 같은 건 없다!!:9",
            "너가 대칭에 집착한다는 것은 지난 싸움을 통해 확실히 파악했다.:7",
            "그것이 너의 가장 치명적인 약점이야.:4",
            "대칭, 그것만 부숴진다면...:0",
            "너의 정체성 자체가 부숴지기 때문이다.:4",
            "크흑!! 용서치 않겠다!! 용사!!!!!!!!!!!:9",
            "잘 있어라, <퍼르펙토>. <설겆>이는 지옥에서 해라!:4",
            "아아악!!! 파르펙토야!!! 그리고 설겆이가 아니고 설거ㅈ:9"
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
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == 0 || talkIndex == 17)
        {
            cameraShake.shakeDuration = 1.0f;
        }
        if (talkIndex == talkData[id].Length)
        {
            SceneManager.LoadScene("Ending Credit");
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
