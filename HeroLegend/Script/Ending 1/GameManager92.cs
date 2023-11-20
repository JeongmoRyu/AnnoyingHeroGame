using UnityEngine;
using UnityEngine.UI;

public class GameManager92 : MonoBehaviour
{
    public TalkManager92 talkManager;
    public GameObject talkPanel;
    public Image portraitImg;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public void Action(GameObject scanObj)
    {
        //if (isAction) { // Exit Action
        //    isAction = false;
        //}
        //else { // Enter Action
        //    isAction = true;
        //    scanObject = scanObj;
        //    ObjData objData = scanObject.GetComponent<ObjData>();
        //    Talk(objData.id, objData.isNpc);
        //}
        //talkPanel.SetActive(isAction);

        //scanObject = scanObj;
        //ObjData objData = scanObject.GetComponent<ObjData>();
        //Talk(objData.id, objData.isNpc);

        Talk(1000, true);

        talkPanel.SetActive(isAction);
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
