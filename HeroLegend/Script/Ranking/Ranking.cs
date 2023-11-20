using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public GameObject[] obj=new GameObject[5];
    public Text[] rank = new Text[5];
    public Text[] name=new Text[5];
    public Text[] score = new Text[5];
    public Text[] playTime= new Text[5];

    public void Awake()
    {
        for(int i = 0; i < 5; i++)
        {
            obj[i].SetActive(false);
        }
    }

    public void Start()
    {
        List<PlayerRankingClass> players = DBManager.Instance.ShowRanking();

        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] == null) break;//5인 이하일 경우 종료
            if (players[i].getScore() == 0 && players[i].getPlayTime() == 0) break;//유의미한 데이터가 아닐 경우 종료

            rank[i].text = Convert.ToString(i+1);
            name[i].text = players[i].getNickname();
            score[i].text = Convert.ToString(players[i].getScore())+"점";
            playTime[i].text = setPlayerTimeText(players[i].getPlayTime());
            obj[i].SetActive(true);
        }
    }

    public string setPlayerTimeText(int playerTime)
    {
        string result = "";
        if (playerTime >= 60)
        {
            result += (playerTime / 60) + "분 ";
        }
        result += (playerTime % 60) + "초";
        return result;
    }

}