using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerVillage : MonoBehaviour
{
    public TalkManagerVillage talkManagerVillage;
    public Text talkText;
    // public GameObject talkPanel;    
    public bool isAction;
    public GameObject[] images;
    
    private int id = 0;

    private int talkIdx = 0;
    
    void Start()
    {
        Talk(id, talkIdx);
        Action();
        AudioManagerVillage.instance.PlayBgm(true);

    }
    public void Action()
    {
        // ObjectData1 objectData1 = new ObjectData1(id, talkIdx);
        if (Input.GetButtonDown("Jump"))
            talkIdx++;
            Talk(id, talkIdx);


    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            Action();
    }

    void Talk(int id, int talkIdx)
    {
        string talkData = talkManagerVillage.GetTalk(id, talkIdx);
        if (talkData.Split(":")[1] == " 1")
        {
            Debug.Log("one");
            images[0].gameObject.SetActive(false);
            images[1].gameObject.SetActive(true);
            images[2].gameObject.SetActive(false);
            // transform.GetChild(1).gameObject.SetActive(true);
            // transform.GetChild(2).gameObject.SetActive(false);
            // transform.GetChild(2).gameObject.SetActive(false);
        }
        if (talkData.Split(":")[1] == " 2")
        {
            Debug.Log("two");
            images[0].gameObject.SetActive(false);
            images[1].gameObject.SetActive(false);
            images[2].gameObject.SetActive(true);

        }

        if (talkData.Split(":")[1] == " 0")
        {
            Debug.Log("zero");
            images[0].gameObject.SetActive(true);
            images[1].gameObject.SetActive(false);
            images[2].gameObject.SetActive(false);
        }
        Debug.Log($"{talkData}");
        if (talkData == null)
        {
            isAction = false;
            return;
        }
        talkText.text = talkData.Split(":")[0];
        isAction = true;


    }

}
