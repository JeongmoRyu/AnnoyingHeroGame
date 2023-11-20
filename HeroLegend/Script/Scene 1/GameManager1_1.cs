using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1_1 : MonoBehaviour
{
    public TalkManager1 talkManager1;
    public GameObject talkPanel;
    public Text talkText;
    
    public bool isAction;
    public GameObject[] images;
    
    private int id = 0;
    // private int number = TalkManager1.talkData[1][0]; // 수정된 부분

    // private int number = TalkManager1.talkData[1][0]; 
    private int talkIdx = 0;
    
    void Start()
    {
        Talk(id, talkIdx);
        Action();
        AudioManager1_1.instance.PlayBgm(true);

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
        string talkData = talkManager1.GetTalk(id, talkIdx);
        if (talkData.Split(":")[1] == " 1")
        {
            Debug.Log("one");
            images[0].gameObject.SetActive(false);
            images[1].gameObject.SetActive(true);
            images[2].gameObject.SetActive(false);
            images[3].gameObject.SetActive(false);
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
            images[3].gameObject.SetActive(false);

        }
        if (talkData.Split(":")[1] == " 3")
        {
            Debug.Log("three");
            images[0].gameObject.SetActive(false);
            images[1].gameObject.SetActive(false);
            images[2].gameObject.SetActive(false);
            images[3].gameObject.SetActive(true);
        }
        if (talkData.Split(":")[1] == " 0")
        {
            Debug.Log("zero");
            images[0].gameObject.SetActive(true);
            images[1].gameObject.SetActive(false);
            images[2].gameObject.SetActive(false);
            images[3].gameObject.SetActive(false);
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