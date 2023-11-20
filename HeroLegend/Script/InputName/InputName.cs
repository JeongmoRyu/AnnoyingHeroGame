using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    /* UI 구성요소 */
    public GameObject NameView;
    public InputField InputField_Name;

    /* 닉네임 입력 버튼 클릭 이벤트 */
    public void NameButtonClick()
    {
        if (string.IsNullOrEmpty(InputField_Name.text)) return;

        string name = InputField_Name.text;
        Debug.Log("닉네임 입력 버튼 클릭 이벤트 발생 :: " + name);

        /* DB 저장 */
        if (DBManager.Instance.InputNickname(name))
        {
            NameView.SetActive(false);

            // 게임 내 모든 곳에서 사용할 닉네임 저장
            PlayerPrefs.SetString("nickname", name);
            NicknameManager.nickname = name;

            // 클리어한 기록이 있는지 여부 확인
            // 한개라도 클리어했으면 Map으로 보내고
            // 아직 클리어한 것이 없으면 Intro로 보내자
            bool[] clearinfo = DBManager.Instance.GetPlayerInfo(name).getClear();

            if (clearinfo.Contains(true))
            {
                // 하나라도 클리어한 기록이 있다면 Map으로 보내고
                SceneManager.LoadScene("Village");
            }
            else
            {
                // 아직 하나도 클리어하지 않았다면, Intro.01로 보내자
                // SceneManager.LoadScene("Map");
                SceneManager.LoadScene("Intro 01");
            }
        }
        else
        {
            /*
             * TO DO :: "다시 시도해주세요" ALERT
             */
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            NameButtonClick();
    }

    /* 취소 버튼 클릭 이벤트 */
    public void CancelButtonClick()
    {
        InputField_Name.text = "";
    }

    public void RankButtonClick()
    {
        SceneManager.LoadScene("Ranking");
    }
}