using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int HeartCount;
    public GameObject Heart3, Heart2, Heart1, Heart0;
    public Text scoreText, highScoreText,gameScore;
    public float scoreCounts, highScoreCounts, pointPerSecond,gameScoreCounts;
    public bool scoreIncreasing;
    public bool coinDoublePoints;
    public AudioSource deathSound;
    private GameManager gameManager;

    // Use this for initialization
    void Start() {
        
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
		HeartCount = 3;
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

        if(HeartCount == 3){
            Heart3.SetActive(true);
            Heart2.SetActive(false);
            Heart1.SetActive(false);
            Heart0.SetActive(false);
        }else if(HeartCount == 2){
			Heart3.SetActive(false);
            Heart2.SetActive(true);
			Heart1.SetActive(false);
			Heart0.SetActive(false);
        }else if(HeartCount == 1){
            Heart3.SetActive(false);
            Heart2.SetActive(false);
            Heart1.SetActive(true);
            Heart0.SetActive(false);
		}else if (HeartCount == 0)
		{
			Heart3.SetActive(false);
			Heart2.SetActive(false);
			Heart1.SetActive(false);
			Heart0.SetActive(true);

            gameManager.RestartGame();
		}
    }

    public void AddScore(int point) {
        scoreCounts += coinDoublePoints ? point * 2 : point;
        gameScoreCounts += coinDoublePoints ? point * 2 : point;
    }

	public static void MinusHeart(int toBeDeducted)
	{
        HeartCount -= toBeDeducted;

	}
	public static void AddHeart(int toBeAdded)
	{
		HeartCount += toBeAdded;

	}

	public static Vector4 hexColor(float r, float g, float b, float a)
	{
		Vector4 color = new Vector4(r / 255, g / 255, b / 255, a / 255);
		return color;
	}

}