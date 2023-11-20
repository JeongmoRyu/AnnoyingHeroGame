using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkManager91 : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    public CameraShake9 cameraShake;
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
            "젠장!! <퍼르펙토>의 강함을 너무 얕봤군...:7",
            "이대로 끝인 건가...:5",
            "'용사님, 전 용사님을 믿어요':10",
            "그래... 공주를 위해, 여기서 포기할 순 없지!:4",
            "이 감옥을 빠져나갈 수 있는 방법은 없을까?...:5",
            "...:7",
            "그래! 바로 그거야!:2",
            "퍼르펙토!! 퍼르펙토!! 거기 있는 것 다 안다!!:1",
            "퍼르펙토가 아니라 파르펙토다!:8",
            "그래, 파르펙토.:1",
            "완벽을 추구하는 당신이 한 가지 잊은 게 있는 것 같은데...:1",
            "뭐?? 이 내가.. 놓친 게 있다고???:8",
            "그게 뭐지???!!!!:8",
            "설마 나를 잡아두고, 계속 이 감옥에서 썩어가게 할 것은 아니겠지?:4",
            "잡았으면 완벽한 끝 마무리를 지어야지! 그 전에 마지막 만찬도 제공하고!:4",
            "?? 내가 왜 그래야 하지 ??:8",
            "이래서 마물이란… 인간계에서는 그게 당연한 순리야! 인간계까지 모두 점령할 것 아니었나?:4",
            "그러면 그 문화도 받아들여야 비로소 <완벽>하다고 할 수 있지 않겠어?:0",
            "...:8",
            "(통했나? 꿀꺽):0",
            "...조금만 기다려라.:8",
            "(통했다!):1"
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
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            SceneManager.LoadScene("Ending 2");
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
