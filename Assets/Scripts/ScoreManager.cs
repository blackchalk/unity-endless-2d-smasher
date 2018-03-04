using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText, highScoreText,gameScore;
    public float scoreCounts, highScoreCounts, pointPerSecond,gameScoreCounts;
    public bool scoreIncreasing;
    public bool coinDoublePoints;
	
    // Use this for initialization
    void Start() {
        if (PlayerPrefs.HasKey("HighScores")) {
            highScoreCounts = PlayerPrefs.GetFloat("HighScores");
        }
    }
	
    // Update is called once per frame
    void Update () {
        //if (scoreIncreasing) {
        //    scoreCounts += pointPerSecond * Time.deltaTime;
        //}

        if (scoreCounts > highScoreCounts) {
            highScoreCounts = scoreCounts;
            PlayerPrefs.SetFloat("HighScores", highScoreCounts);
        }
		
        scoreText.text = "Coins: " + Mathf.Round(scoreCounts);
        //highScoreText.text = "High Score: " + Mathf.Round(highScoreCounts);
        gameScore.text = ""+Mathf.Round(gameScoreCounts);
    }

    public void AddScore(int point) {
        scoreCounts += coinDoublePoints ? point * 2 : point;
        gameScoreCounts += coinDoublePoints ? point * 2 : point;
    }
}