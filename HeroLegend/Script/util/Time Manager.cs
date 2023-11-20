using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/* 공통으로 사용할 타이머 스크립트 */
public class TimeManager : MonoBehaviour
{

    /* 시간 */
    private float sec;
    private int min;

    /* 텍스트 UI */
    public Text text;

    public void setTime(int time)
    {
        min = 0;
        sec = 0;
        if (sec >= 60)
        {
            min = time / 60;
        }
        sec = time % 60;
    }

    public int getTime()
    {
        // 씬 종료 시마다 호출할 메소드의 playTime에 넣기 편하도록 추가
        return 60 * min + (int)sec;
    }

    public void Update()
    {
        sec += Time.deltaTime;
        if (sec >= 60f)
        {
            min++;
            sec = 0;
        }

        text.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);
    }
}