﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int HeartCount;
    public GameObject Heart3, Heart2, Heart1, Heart0;
    public Text scoreText, highScoreText,gameScore;
    public static Text heartCounterText;
    public float scoreCounts, highScoreCounts, pointPerSecond, gameScoreCounts;
    //public bool scoreIncreasing;
    public bool coinDoublePoints;
    public AudioSource deathSound;
    private GameManager gameManager;
    private DataController dc;
    private EffectManager em;
    // Use this for initialization
    void Start() {
        
        em = GameObject.Find("EffectManager").GetComponent<EffectManager>();
        dc = GameObject.Find("DataController").GetComponent<DataController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

		HeartCount = 3;
        heartCounterText = GameObject.Find("heartCounter").GetComponent<Text>();
        //heartCounterText.GetComponent<Text>().enabled = false;
        heartCounterText.GetComponent<Text>().text = "";

        if (PlayerPrefs.HasKey("HighScores")) {
            highScoreCounts = PlayerPrefs.GetFloat("HighScores");
        }
    }
	
    // Update is called once per frame
    void Update () {
		//if (scoreIncreasing) {
		//    scoreCounts += pointPerSecond * Time.deltaTime;
		//}
        //extra heart indicator
		if ((heartCounterText != null) && (HeartCount > 3))
		{
			//heartCounterText.GetComponent<Text>().enabled = true;
			heartCounterText.GetComponent<Text>().text = "x" + HeartCount;
		}
		else
		{
			heartCounterText.GetComponent<Text>().text = "";
		}

        if (scoreCounts > highScoreCounts) {
            highScoreCounts = scoreCounts;
            PlayerPrefs.SetFloat("HighScores", highScoreCounts);
        }
		
        scoreText.text = "Coins: " + Mathf.Round(scoreCounts);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCounts);
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
            HeartCount = 3;
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

        if(((int)scoreCounts%10)==0){
            em.potHealthLevel += 1;
            em.updatePotLevel();
        }

    }

	public static void MinusHeart(int toBeDeducted)
	{
        HeartCount -= toBeDeducted;
		//if ((heartCounterText != null) && (HeartCount <= 3))
		//{
  //          heartCounterText.GetComponent<Text>().text = ""+HeartCount;
  //          heartCounterText.GetComponent<Text>().enabled = false;

		//}

	}
	public static void AddHeart(int toBeAdded)
	{
		HeartCount += toBeAdded;
        //if((heartCounterText != null) && (HeartCount > 3))
        //{
        //    //heartCounterText.GetComponent<Text>().enabled = true;
        //    heartCounterText.GetComponent<Text>().text = "x"+HeartCount;
        //}else{
        //    heartCounterText.GetComponent<Text>().text = "";
        //}

	}

	public static Vector4 hexColor(float r, float g, float b, float a)
	{
		Vector4 color = new Vector4(r / 255, g / 255, b / 255, a / 255);
		return color;
	}

}