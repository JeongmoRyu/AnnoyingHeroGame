using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeUIManager0 : MonoBehaviour
{
    GameObject childContainer;
    AudioSource clickAudioSource;

    private void Awake()
    {
        clickAudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        childContainer = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleEscapeUI();
        }
    }

    public void ToggleEscapeUI()
    {
        // active를 반전
        childContainer.SetActive(!childContainer.activeSelf);

        // 사운드
        clickAudioSource.Play();

        // 게임 일시 중지 및 재개
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        else if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
    }

    public void QuitGame()
    {
        // 사운드
        clickAudioSource.Play();

        // 게임 종료
        // 에디터 창에서는 동작하지 않고, 실제 빌드 후에 동작합니다
        Application.Quit();
    }

    public void GoMap()
    {
        clickAudioSource.Play();

        SceneManager.LoadScene("Map");
    }
}
