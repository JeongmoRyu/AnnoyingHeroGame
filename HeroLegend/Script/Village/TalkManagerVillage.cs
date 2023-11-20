using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkManagerVillage : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    // public GameObject MainCamera;
    public GameObject MainCameraVillage;



    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        talkData.Add(0, new string[] {"용사님!! 몬스터들을 제압하시는 모습이 정말 멋져요  : 2",
        "훗!!! 이정도는 기본이죠 : 1",
        "그럼 다음 성으로 가볼까요? : 1", 
        "좋아요! 다음 성으로 가는길은 저기 마을 표지판에 지도가 그려져 있어요 : 2",
        "다음 마을로 가기 위해서 지도로 이동해서 선택해보자 : 0",
        "다음 마을로 가기 위해서 지도로 이동해서 선택해보자 : 0"});
    }
    

    public string GetTalk(int id, int talkIdx)
    {
        if (talkIdx == 3)
        {
            MainCameraVillage.GetComponent<ScriptCameraVillage>().MoveCameraMap();

        }
        if (talkIdx == talkData[id].Length)
        {
            MainCameraVillage.GetComponent<ScriptCameraVillage>().MoveCameraBasic();

            // TalkEnd();
            return null;
        }
        else
            return talkData[id][talkIdx];
    }



    // public void TalkEnd()
    // {
    //     MainCamera.GetComponent<ScriptCameraVillage>().MoveCameraBasic();
    // }

    

}

