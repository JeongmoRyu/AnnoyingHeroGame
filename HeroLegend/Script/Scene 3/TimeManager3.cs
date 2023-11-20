using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager3 : MonoBehaviour
{
    /* 시간 */
    private float sec;
    private int min;
    public static bool countTime;

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

    public float getTime()
    {
        return min * 60 + sec;
    }

    public void Update()
    {
        if (countTime)
        {
            sec += Time.deltaTime;
            if (sec >= 60f)
            {
                min++;
                sec = 0;
            }
        }

        text.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);
    }
}
