using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager5_0 : MonoBehaviour
{
    public int stageIndex;
    public GameObject[] stages;

    public TalkManager5_0 talkManager;
    public GameObject talkPanel;
    public GameObject defaultPanel;
    public Image portrait;
    public Text talkText;
    public Text defaultText;
    public int talkIdx;
    public bool isAction;
    public Camera MainCamera;

    public CameraManager5_0 cameraManager;
    CameraShake5_0 cameraShake;

    private int[] TopDownStages = { 1 };
    private bool TopDownScriptEnd = false;

    BGMSounder5_0 sounder;

    void Start()
    {
        sounder = GetComponent<BGMSounder5_0>();
        cameraShake = MainCamera.GetComponent<CameraShake5_0>();
        Talk(stageIndex);
    }

    public void NextStage()
    {
        if (stageIndex == stages.Length - 1) // Ending
        {
            SceneManager.LoadScene("Scene 5");
        }
        // Change Stages
        if (stageIndex < stages.Length - 1)
        {
            stages[stageIndex].SetActive(false);
            stageIndex++;
            stages[stageIndex].SetActive(true);
            cameraManager.ChangeCamera(stageIndex - 1, stageIndex);
            Talk(stageIndex);
        }

        if (TopDownStages.Contains(stageIndex)) // Top-Down Scene
        {
            TopDownScriptEnd = false;
        }
        // Talk(stageIndex);
    }

    void Talk(int stage)
    {
        if (TopDownScriptEnd)
            return;

        string talkData = talkManager.GetTalk(stage, talkIdx);

        if (talkData == null)
        {
            isAction = false;
            talkIdx = 0;
            talkPanel.SetActive(false);
            defaultPanel.SetActive(false);
            if (!TopDownStages.Contains(stageIndex))
                NextStage();
            else
                TopDownScriptEnd = true;
            return;
        }

        if (talkData.Split(":")[1] == "default")
        {
            defaultPanel.SetActive(true);
            defaultText.text = talkData.Split(":")[0];
        }
        else if (talkData.Split(":")[1] == "desc")
        {
            switch (talkData.Split(":")[0])
            {
                case "shakeStart":
                    defaultPanel.SetActive(true);
                    defaultText.text = "(잠시 생각하면서 다리를 떤다)";
                    cameraShake.shakeDuration = 1.0f;
                    break;
                case "shakeEnd":
                    cameraShake.shakeDuration = 0f;
                    break;
                default:
                    break;
            }
        }
        else
        {
            talkPanel.SetActive(true);
            talkText.text = talkData.Split(":")[0];
            portrait.sprite = talkManager.GetPortrait(int.Parse(talkData.Split(":")[1]));
        }

        isAction = true;
        talkIdx++;
    }

    public void Action()
    {
        talkPanel.SetActive(false);
        defaultPanel.SetActive(false);
        Talk(stageIndex);
    }
}
