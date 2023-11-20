using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note4 : MonoBehaviour
{
    public float noteSpeed = 800;

    UnityEngine.UI.Image noteImage;

    // 객체가 활성화 될 때마다 호출되는 함수
    private void OnEnable()
    {
        // 이미지 컴포넌트를 계속 가져오면, 쓸 데 없는 행동을 반복하는거
        // null값일때만 가져오게 만들고
        if (noteImage == null)
            noteImage = GetComponent<UnityEngine.UI.Image>();

        // 큐를 돌다보면 이전에 스페이스 맞춰서 아래가 false 되어 있는 경우 있으니까
        noteImage.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;
    }

    public void HideNote()
    {
        noteImage.enabled = false;
    }

    public bool GetNoteFlag()
    {
        return noteImage.enabled;
    }
}
