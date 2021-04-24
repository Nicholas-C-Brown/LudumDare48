using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int HighScore { get; private set; }

    public float PlayerScore { get; private set; }

    [SerializeField]
    private GameController controller;

    [SerializeField]
    private int scoreMultiplier;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private TMP_Text highscoreText;

    private bool playing;

    private void Start()
    {
        //Load Highscore
        if (SaveSystem.ScoreFileExists())
            HighScore = SaveSystem.LoadScore().Highscore;
        else HighScore = 0;
        
        //Set Player Score
        PlayerScore = 0;

        //Set Text
        highscoreText.text = "Highscore: " + HighScore;
        scoreText.text = "Score: " + (int)PlayerScore;

        playing = true;
        controller.GameOverAction += () =>
        {
            playing = false;
            
            //Update highscore
            if (PlayerScore > HighScore) HighScore = (int)PlayerScore;
            SaveSystem.SaveScore(this);
            highscoreText.text = "Highscore: " + HighScore;
        };
    }

    void Update()
    {
        if (playing)
        {
            PlayerScore += Time.deltaTime * scoreMultiplier;
            scoreText.text = "Score: " + (int)PlayerScore;
        }
    }

    public void AddToScore(float amount)
    {
        if (amount < 0)
        {
            Debug.LogError("Negative score cannot be added.");
            return;
        }

        PlayerScore += amount;
    }
}
