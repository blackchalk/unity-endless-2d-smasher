using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    private ScoreManager scoreManager;
    private PlayerController playerController;
    private DataController dc;
    private GameManager gm;
    public float playersCurrentSpeed;
    public float lastKnownPlayerMoveSpeed;
    public float currentSpeedAtIce;
    public int duration = 0;
    public int itemScore = 0;
    public int potHealthLevel = 1;
    public string itemType;
	//
	public Text scoreText;
	private bool doublePointMode;
    private bool iceMode;
    public bool starMode;
    //timers
    public Text c_coins;
    public Text c_snow;
    public Text c_star;
    //pot level text indicator
    public Text c_potlevel;
    //bee
    public bool beeMode;
    public float beeModeTimeLength;
    public GameObject bee;

	private bool powerUpActive;
	public float powerUpLengthCounter;
	public float iceLengthCounter;
    public float starLengthCounter;

	//private PlatformGenerator platformGenerator;

	private float normalPointPerSecond;
	//private float normalSpikeRate;
    private bool powerUpIceActive;
    public bool powerUpStarActive;

    private void Awake()
    {
        
        //scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
		scoreManager = FindObjectOfType<ScoreManager>();
        playerController = FindObjectOfType<PlayerController>();
        gm = FindObjectOfType<GameManager>();
        dc = GameObject.Find("DataController").GetComponent<DataController>();
		normalPointPerSecond = scoreManager.pointPerSecond;
		//normalSpikeRate = platformGenerator.spikeGenerateThreshold;
	}

    // Use this for initialization
    void Start () {

        beeMode = false;
        beeModeTimeLength = 5f;
        bee.SetActive(false);

	}

    public void updatePotLevel(){
        c_potlevel.text = "Pot Level: " + potHealthLevel;
    }
	
	// Update is called once per frame
	void Update () {
        //updatePotLevel();
		//check whether its paused
		if (!gm.isPaused)
		{

			if(beeMode){
            beeModeTimeLength -= Time.deltaTime;
            //StartCoroutine("startBeeAnim");
            //do something
        }

        if(beeModeTimeLength<0){
            beeMode = false;
            beeModeTimeLength = 5f;
            //StartCoroutine("startBeeAnim");
        }
  
            if (powerUpActive)
            {
                powerUpLengthCounter -= Time.deltaTime;
                //run timer
                if (powerUpLengthCounter > 1)
                {
                    c_coins.text = "" + Mathf.Round(powerUpLengthCounter) + "s";

                }
                else
                {
                    c_coins.text = "";
                }

                if (doublePointMode)
                {
                    scoreManager.coinDoublePoints = true;
                    scoreText.GetComponent<Text>().color = Color.yellow;
                }

                //if (spikeProffMode) {
                //    platformGenerator.spikeGenerateThreshold = 0f;
                //    scoreText.GetComponent<Text>().color = Color.white;
                //}

                if (powerUpLengthCounter < 0)
                {
                    powerUpLengthCounter = 0;
                    scoreText.GetComponent<Text>().color = ScoreManager.hexColor(169, 117, 69, 255);
                    //platformGenerator.spikeGenerateThreshold = normalSpikeRate;//null
                    scoreManager.coinDoublePoints = false;
                    doublePointMode = false;
                    //spikeProffMode = false;
                    powerUpActive = false;
                }
            }
            //when ice active
            if (powerUpIceActive)
            {

                iceLengthCounter -= Time.deltaTime;

                //run timer
                if (iceLengthCounter > 1)
                {
                    c_snow.text = "" + Mathf.Round(iceLengthCounter) + "s";

                }
                else
                {
                    c_snow.text = "";
                }

                if (iceMode)
                {
                    scoreText.GetComponent<Text>().color = ScoreManager.hexColor(0, 234, 255, 255);
                }

                if (iceLengthCounter < 0)
                {
                    iceLengthCounter = 0;
                    scoreText.GetComponent<Text>().color = ScoreManager.hexColor(169, 117, 69, 255);
                    //get back to last speed
                    playerController.moveSpeed = lastKnownPlayerMoveSpeed;
                    iceMode = false;
                    powerUpIceActive = false;
                }
            }
            //when star active
            if (powerUpStarActive)
            {

                starLengthCounter -= Time.deltaTime;

				GameObject[] objs;
				objs = GameObject.FindGameObjectsWithTag("KillBox");
                foreach (GameObject u in objs)
				{
					u.GetComponent<BoxCollider2D>().enabled = false;
				}

				GameObject[] objs1;
				objs1 = GameObject.FindGameObjectsWithTag("bomb");
				foreach (GameObject u in objs1)
				{
					u.GetComponent<BoxCollider2D>().enabled = false;
				}

				GameObject[] objs2;
				objs2 = GameObject.FindGameObjectsWithTag("beehive");
				foreach (GameObject u in objs2)
				{
					u.GetComponent<BoxCollider2D>().enabled = false;
				}
                //run timer
                if (starLengthCounter > 1)
                {
                    c_star.text = "" + Mathf.Round(starLengthCounter) + "s";

                }
                else
                {
                    c_star.text = "";
                }

                if (starMode)
                {
                    scoreText.GetComponent<Text>().color = ScoreManager.hexColor(0, 255, 97, 255);

                }

                if (starLengthCounter < 0)
                {
                    starLengthCounter = 0;
                    scoreText.GetComponent<Text>().color = ScoreManager.hexColor(169, 117, 69, 255);
                    starMode = false;
                    powerUpStarActive = false;
                }
            }
        }
	}

    public void setItemType(string type){
        this.itemType = type;
    }

    public string getItemType(){
        return this.itemType;
    }

	public void InActivePowerUpMode()
	{
		powerUpLengthCounter = 0;
	}

    public void ActivateDoublePoint(bool doublePointMode, float length)
    {

        powerUpActive = true;
        //add to current length when already active
        if (this.doublePointMode)
        {
            this.powerUpLengthCounter += length;
        }
        else
        {
            this.doublePointMode = doublePointMode;
            this.powerUpLengthCounter = length;
        }
    }

	public void ActivateIcePoint(bool _icePointMode, float _playersLastKnownSpeed,float length)
	{

        powerUpIceActive = true;
		//add to current length when already active
        if (this.iceMode)
		{
            this.iceLengthCounter += length;
		}
		else
		{
			//check if already in ice
			if (_icePointMode)
			{
				this.lastKnownPlayerMoveSpeed = _playersLastKnownSpeed;
				this.currentSpeedAtIce = _playersLastKnownSpeed;
				playerController.moveSpeed = currentSpeedAtIce / 2f;
			}

            this.iceMode = _icePointMode;
			this.iceLengthCounter = length;
		}

	}

	public void ActivateStarPoint(bool _starPointMode, float length)
	{

        powerUpStarActive = true;
		//add to current length when already active
        if (this.starMode)
		{
            this.starLengthCounter += length;
		}
		else
		{
            this.starMode = _starPointMode;
			this.starLengthCounter = length;
		}
	}

}
