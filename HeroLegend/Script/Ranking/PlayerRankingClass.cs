using System;

/* 랭킹 출력할 플레이어 클래스 */
public class PlayerRankingClass
{
    private long rank;
    private string nickname;
    private int score;
    private int playTime;

    public PlayerRankingClass() { }

    public PlayerRankingClass(long rank, string nickname, int score, int playTime)
    {
        this.rank = rank;
        this.nickname = nickname;
        this.score = score;
        this.playTime = playTime;
    }

    public long getRank() { return rank; }
    public string getNickname() { return nickname; }
    public int getScore() { return score; }
    public int getPlayTime() { return playTime; }
}