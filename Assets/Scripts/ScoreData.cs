[System.Serializable]
public class ScoreData
{
    public int Highscore { get; set; }

    public ScoreData(Score score)
    {
        Highscore = score.HighScore;
    }

}
