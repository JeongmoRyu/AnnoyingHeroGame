using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
public class TalkManager03 : MonoBehaviour
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
            "진짜 갔네…:5",
            "하긴… 오늘 흰 옷 입었는데 춘장 튀었으니 화 많이 났겠지...:5",
            "아직도 화 많이 났으려나? 연락해 봐야겠다.:5",
            "[발신 메시지] 여친아. 아까는 미안했어. 내가 다리 떨고 쩝쩝거리니까 같이 밥 먹는'대' 신경 쓰였지?:5",
            "[발신 메시지] 아까는 너가 갑자기 화내서 좀 <어의>없었는데 <곰곰히> 생각해보니 내 잘못이 큰 것 같아.:5",
            "[발신 메시지] 내가 <어떻해> 하면 너 화가 풀릴지 모르겠네. 연락 기다릴게.:1",
            "[수신 메시지] 진짜 맞춤법으로도 정 떨어지게 하네. 우리 헤어져.:10",
            "[수신 메시지] 너가 다리떠는 것도 싫고. 젓가락질도 이상하고 쩝쩝대는 것도 싫어.:10",
            "[수신 메시지] 탕수육 찍어먹는 걸로 유난 떠는것도 이제는 미쳐버릴 것 같아.:15",
            "[수신 메시지] 다시는 만나지 말자.:15",
            "뭐??? 젓가락질?? 시대가 어느 시대인데 젓가락질 타령이야?!:2",
            "내 젓가락질로 자기가 피해보는 것도 아니고? 웃겨 진짜!:2",
            "[발신 메시지] 야!! 내 <젖가락질>로 너한테 피해 주는 거 있어??:4"
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
            //SceneManager.LoadScene("Intro 04");
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
