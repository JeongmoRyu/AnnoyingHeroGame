using UnityEngine;
using UnityEngine.UI;

public class GameManager01 : MonoBehaviour
{
    public TalkManager01 talkManager;
    public GameObject talkPanel;
    public Image portraitImg;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;
    public AudioSource backgroundMusic;

    public void Action(GameObject scanObj)
    {
        Talk(1000, true);

        talkPanel.SetActive(isAction);
    }

    void Start()
    {
        backgroundMusic.loop = true;  // 음악이 끝나면 다시 처음부터 재생
        backgroundMusic.Play();  // 배경음악 재생 시작
    }


    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        if (isNpc && talkData.Split(':').Length >= 2)
        {
            talkText.text = talkData.Split(':')[0];
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }
}
