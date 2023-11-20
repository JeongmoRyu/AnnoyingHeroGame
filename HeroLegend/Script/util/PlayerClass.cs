using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass
{
    private int score;
    private int playTime;
    private bool[] clear;

    public PlayerClass() { }

    public PlayerClass(int score, int playTime, bool[] clear)
    {
        this.score = score;
        this.playTime = playTime;
        this.clear = clear;
    }

    public int getScore() { return score; }
    public int getPlayTime() {  return playTime; }
    public bool[] getClear() { return clear; }
}
