using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    private ScoreManager scoreManager;
    private PlayerController playerController;
    public string currentGameEffect;
    public float lastKnownPlayerMoveSpeed;
    public float currentSpeedAtIce;
    public int duration = 0;
    public int itemScore = 0;
    public string itemType;
	//
	public Text scoreText;
	private bool doublePointMode;
	private bool spikeProffMode;
    private bool iceMode;

	private bool powerUpActive;
	public float powerUpLengthCounter;
	public float iceLengthCounter;

	private PlatformGenerator platformGenerator;

	private float normalPointPerSecond;
	private float normalSpikeRate;

    private void Awake()
    {
        currentGameEffect = "normal";
        //scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
		scoreManager = FindObjectOfType<ScoreManager>();
        playerController = FindObjectOfType<PlayerController>();
		//platformGenerator = FindObjectOfType<PlatformGenerator>();

		normalPointPerSecond = scoreManager.pointPerSecond;
		//normalSpikeRate = platformGenerator.spikeGenerateThreshold;
	}

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if (powerUpActive)
		{
			powerUpLengthCounter -= Time.deltaTime;

			if (doublePointMode)
			{
				scoreManager.coinDoublePoints = true;
				scoreText.GetComponent<Text>().color = Color.yellow;
			}

			//if (spikeProffMode) {
			//    platformGenerator.spikeGenerateThreshold = 0f;
			//    scoreText.GetComponent<Text>().color = Color.white;
			//}

            if(iceMode){
                scoreText.GetComponent<Text>().color = ScoreManager.hexColor(0, 234, 255, 255);
                iceLengthCounter -= Time.deltaTime;
                if (iceLengthCounter < 0)
				{
                    playerController.moveSpeed = lastKnownPlayerMoveSpeed;
                    this.iceMode = false;
                    powerUpActive = false;
				}
            }

            //TODO create invulnerable true

			if (powerUpLengthCounter < 0)
			{
                scoreText.GetComponent<Text>().color = ScoreManager.hexColor(169,117,69,255);
                //platformGenerator.spikeGenerateThreshold = normalSpikeRate;//null
				scoreManager.coinDoublePoints = false;
				doublePointMode = false;
				spikeProffMode = false;
				powerUpActive = false;
			}
		}
	}

    public void setItemType(string type){
        this.itemType = type;
    }

    public string getItemType(){
        return this.itemType;
    }

	public void ActivePowerUpMode(bool doublePointMode, bool iceMode, bool spikeProffMode,float lastKnownPlayerMoveSpeed, float length)
	{
        this.lastKnownPlayerMoveSpeed = lastKnownPlayerMoveSpeed;
        this.currentSpeedAtIce = lastKnownPlayerMoveSpeed;
		this.doublePointMode = doublePointMode;
		this.spikeProffMode = spikeProffMode;
        if(!this.iceMode){
            this.iceMode = iceMode;
        }else{
            iceMode = false;
        }

        this.iceLengthCounter = length;
		this.powerUpLengthCounter = length;
		powerUpActive = true;

		if (spikeProffMode)
		{
			GameObject[] killboxes = GameObject.FindGameObjectsWithTag("KillBox");
			foreach (GameObject killbox in killboxes)
			{
				if (killbox.name.StartsWith("Spike"))
				{
					killbox.SetActive(false);
				}
			}
		}

		if (iceMode)
		{
            playerController.moveSpeed = currentSpeedAtIce / 2f;
		}
	}

	public void InActivePowerUpMode()
	{
		powerUpLengthCounter = 0;
	}

}
