using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;

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
                "blackStart:desc",
                "용사님 세계를 구하는 것도 중요하지만 밥도 챙겨 드셔야죠! 마침 앞에 라멘집이 있네요!:9",
                "blackEnd:desc",
                "후루루룩 쩝쩝짜ㅃ짭짭:2",
                "움후후루룩 츄르릅 짭짭:2",
                "...:8",
                "애그래야? (면을 끊지 않으며):6",
                "아니 용사님… 그…:13",
                "blackShockStart:desc",
                "blackShockEnd:desc",
                "moveBoss:desc",
                "\"자네!!! 도대체.. 그런 면치기 기술은 어디서 배운 것인가…??\":default",
                "\"내 신경을 이렇게 거슬리게 하다니!!! 나에게 도전장을 내는 것인가?\":default",
                "에? 느그세야… (면을 끊지 않으며):6",
                "헉 저 치는… 후르브후릎 성의 후르브킹 ???:14",
                "네?? 원래 마왕이 마을 식당에서 밥을 먹기도 해요???:2",
                "\"내 걸어오는 싸움은 절대 피하지 않지!!! 당장 따라 나오게!\":default",
                "네?? 그게 무스…:2",
                "ruleStart:desc",
                "후르브후릎의 후르브킹은 면 요리를 먹을 때 0.1 초에 한 번씩 끊어 먹는 마왕이에요.:14",
                "지금까지 그 어떤 용사도 후르브킹을 이겨낼 수 없었어요..:13",
                "면을 끊지 않으며 면을 흡입하면서 주변에 음식물을 튀기고, 종종 사레를 들러가며 더럽고 치욕스러우며 요란스럽게 먹는 행위를 차마 하지 못했기 때문이죠…!!!:12",
                "말이 심하시네…:3",
                "하지만 용사님이라면 후르브킹을 물리칠 수 있을 거예요!\n여기 설명서를 드릴게요!:9",
                "ruleMid:desc",
                "ruleEnd:desc",
                "blackBossStart:desc",
                "나에게 싸움을 거는 이는 오랜만이군... 기대하겠어:16",
                "어디 한번 따라와보시게!!!:16",
                "blackBossEnd:desc"
                // 1번째 스테이지 시작 UI
        });
        talkData.Add(
            2,
            new string[] {
                "방이 이게 무슨...:17",
                "제법 면치기를 할 줄 아는 녀석이군...:17",
                "(꺼억):3",
                "큿...! 하지만 다음 방은 더 만만치 않을 것이야!!!:16"
                // 2번째 스테이지 시작 UI
        });
        talkData.Add(
            4,
            new string[] {
                "으아아악!!!!:17",
                "더이상.. 면치기로 튄 더러운 국물이 내 방을 어지럽히도록 내버려 둘 수 없어!!!!!!!!!:16",
                "slimeChangeStart:desc",
                "이제부터 본 모습으로 상대해주지:18",
                "지금까지와는 다른 모습으로 싸워야 할 것이야!:18",
                "slimeChangeEnd:desc"
                // 보스 스테이지 시작 UI
        });
        talkData.Add(
            6,
            new string[] {
                "skip:desc",
                "bossEndStart:desc",
                "\"이 몸을 쓰러뜨리다니...\":default",
                "\"너를 최고의 면치기러로 인정하겠다...\":default",
                "\"그러니 썩... 사라져라!!!\":default",
                "bossEndEnd:desc",
                "역시 용사님!!! 용사님이라면 해내실 줄 알았어요!!!:9",
                "하하핫! 역시 그렇죠?:1",
                "제가 한 면치기 하거든요... 어느정도냐면...:1",
                "그럼 어서 여기서 벗어날까요? 우욱...:9",
                "GameEnd:desc"
                // 스테이지 클리어 UI
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

        // Boss
        portraitData.Add(16, portraitArr[16]);
        portraitData.Add(17, portraitArr[17]);
        portraitData.Add(18, portraitArr[18]);

    }

    public string GetTalk(int idx, int talkIdx)
    {
        if (talkIdx == talkData[idx].Length)
            return null;
        else
            return talkData[idx][talkIdx];
    }

    public Sprite GetPortrait(int portraitIndex)
    {
        return portraitData[portraitIndex];
    }
}
