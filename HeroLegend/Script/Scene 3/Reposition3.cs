using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Reposition3 : MonoBehaviour
{
    public UnityEvent onMove;

    void LateUpdate() // Update, FIxedUpdate 이후 실행 -> 후처리
    {
        // position : 절대 좌표, localPosition : 상대 좌표
        if (transform.position.x > -25.5)
            return;

        // 되돌아가기
        transform.Translate(49.5f, 0, 0, Space.Self); // Space.Self -> 상대 좌표
        onMove.Invoke();
    }
}

