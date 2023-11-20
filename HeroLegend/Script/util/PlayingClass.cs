using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingClass
{
    private int score;
    private int playTime;
    private int sceneNum;

    public PlayingClass() { }

    public PlayingClass(int score, int playTime, int sceneNum)
    {
        this.score = score;
        this.playTime = playTime;
        this.sceneNum = sceneNum;
    }

    public int getScore() { return score; }
    public int getPlayTime() { return playTime; }
    public int getSceneNum() { return sceneNum; }
}
