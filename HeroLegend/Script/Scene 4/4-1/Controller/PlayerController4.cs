using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour   
{
    public static bool s_canPresskey = true;

    TimingManager4 theTimingManager;

    private void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager4>();
        s_canPresskey = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (s_canPresskey)
            {
                // 판정 체크
                theTimingManager.CheckTiming();
            }
        }
    }
}
