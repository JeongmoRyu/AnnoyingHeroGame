using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager2 : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    public Sprite[] portraitData;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateDate();
    }

    // Update is called once per frame
    void GenerateDate()
    {
        talkData.Add(1, new string[] { "이곳인가...", 
            "여기가 맞는 것 같은데...", 
            "어렸을 때 방문했던 모습과는 너무 달라요.. 강이 흐르고 풍족한 지역이었는데...", 
            "지거국은 1000년 역사의 찍어먹는 탕수육 요리가 유명한 나라였어요.\n전세계 사람들이 찍어먹는 탕수육을 먹기 위해 올 정도로요! 하지만...", 
            "전에 간단하게 들었지만... 5마왕 중 찍어먹는 탕수육을 혐오하는 마왕 \"부머기라스\"가 그의 마법 군대와 함께 지거국을 침공했어요.",
            "그 이후로 한번도 방문해본적이 없었는데.. 이렇게 달라졌을 줄이야.. 흑흑 ㅜㅜㅠ", 
            "흑흑흑", "흑", "흐긓긓그", "흐긓ㄱ", 
            "용사님 이곳은 어렸을 적 저의 추억이 많은 왕국이에요. 꼭 이곳을 구해주세요.. ㅜㅜ.",
            "마왕 설명서는 이곳을 잘 찾아보면 나올 거에요. 많은 용사들이 이곳을 다녀갔다고 들었어요..",
            "설명서를 찾아 부머기라스와 그의 군대에 대해서 알아가고 \"부머기라스\"를 꼭 해치워주세요ㅜㅜ",
            "앞에 보이는 포탈을 타고 가면 마왕에게 갈 수 있어요..", 
            "울고 있을 때가 아니다. 내가 물리쳐 줄게!" });
        talkData.Add(2, new string[] {"조각상이다. 지거국의 여신상일까.."});
        talkData.Add(3, new string[] { "마왕에게 당한 사람의 해골인 것 같다." });
        talkData.Add(4, new string[] { "마왕에게 당한 사람의 해골인 것 같다." });
        talkData.Add(5, new string[] { "마왕에게 당한 사람의 해골인 것 같다." });
        talkData.Add(7, new string[] { "드래곤의 두개골이다. 마왕과 부하들은 드래곤인걸까.." });
        talkData.Add(8, new string[] { "마왕에게 갈 수 있는 포탈이다." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        } else
        {
            return talkData[id][talkIndex];
        }
    }

    public Sprite GetPortrait(int id, int talkIndex)
    {
        if (id == 1)
        {
            if (talkIndex == 0)
            {
                return portraitData[1];
            } else if (talkIndex == (talkData[id].Length - 1))
            {
                return portraitData[2];
            } else
            {
                return portraitData[3];
            }
        } else if (id == 6)
        {
            if (talkIndex == 0) return portraitData[0];
            return portraitData[portraitData.Length - 1];
        } else
        {
            return portraitData[0];
        }
    }
}
