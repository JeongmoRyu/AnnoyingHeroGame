using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MapRegion0 : MonoBehaviour
{
    public Button[] regions;
    bool[] clearStatus = new bool[5];

    AudioSource regionClickAudioSource;
    string nickname;

    private void Awake()
    {
        regionClickAudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // 클리어 정보 불러오기
        GetClearStatus();

        bool didClearAll = true;
        int numOfRegions = regions.Length;

        for (int i = 0; i < numOfRegions; i++)
        {
            // RGBA에서 Alpha 값이 0.5이상인 부분만 클릭 영역이 되도록 설정
            regions[i].GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;

            // 마지막 지역(보스)이 아니고, 클리어했을 경우, 설정되어 있는 초록색 Disabled Color가 뜨도록
            // + 다시 그 지역을 선택할 수 없게
            if (i < numOfRegions - 1)
            {
                if (clearStatus[i])
                {
                    regions[i].interactable = false;
                }
                else
                {
                    // 하나라도 안 깬 스테이지가 있는 경우
                    didClearAll = false;
                }
            }
        }

        // 마지막 보스는 이전 4 스테이지를 모두 클리어 해야 열리도록
        if (didClearAll)
        {
            regions[numOfRegions - 1].interactable = true;
        }
        else
        {
            regions[numOfRegions - 1].interactable = false;
        }
    }

    void GetClearStatus()
    {
        // 클리어 했는지 여부 불러오기
        // 이 부분이 적절히 바뀌어야 합니다
        nickname = PlayerPrefs.GetString("nickname", "defaultNickname");

        // 처음부터 플레이할 경우 없어도 되는 코드지만, Map에서부터 시작하는 경우 ///////////////
        // + 이전에 PlayerPrefs에 저장하지 않았거나 DB에 넣지 않은 경우 에러를 방지하기 위해서 //
        DBManager.Instance.InputNickname(nickname);
        /////////////////////////////////////////////////////////////////////////////////////////

        bool[] clearinfo = DBManager.Instance.GetPlayerInfo(nickname).getClear();

        clearStatus[0] = clearinfo[3];
        clearStatus[1] = clearinfo[1];
        clearStatus[2] = clearinfo[2];
        clearStatus[3] = clearinfo[0];
        clearStatus[4] = clearinfo[4];
    }

    public void MoveScene(string sceneName)
    {
        // 필요하다면 스크립트 추가 예정
        regionClickAudioSource.Play();
        SceneManager.LoadScene(sceneName);
    }

    // regions[i].interactable = false; 로 버튼을 disabled 상태로 만들 수 있다 => Disabled Color로 나옴
}
