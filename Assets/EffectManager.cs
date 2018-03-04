using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    private ScoreManager scoreManager;
    public string currentGameEffect;
    public int duration = 0;
    public int itemScore = 0;
    public string itemType;
	//
	public Text scoreText;
	private bool doublePointMode;
	private bool spikeProffMode;

	private bool powerUpActive;
	public float powerUpLengthCounter;

	private PlatformGenerator platformGenerator;

	private float normalPointPerSecond;
	private float normalSpikeRate;

    private void Awake()
    {
        currentGameEffect = "normal";
        //scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
		scoreManager = FindObjectOfType<ScoreManager>();
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
				scoreText.GetComponent<Text>().color = new Color(1f, 0.9f, 0f);
			}

			if (spikeProffMode) {
			    platformGenerator.spikeGenerateThreshold = 0f;
			    scoreText.GetComponent<Text>().color = Color.white;
			}

            //TODO create invulnerable true

			if (powerUpLengthCounter < 0)
			{
				scoreText.GetComponent<Text>().color = Color.white;
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

	public void ActivePowerUpMode(bool doublePointMode, bool spikeProffMode, float length)
	{
		this.doublePointMode = doublePointMode;
		this.spikeProffMode = spikeProffMode;
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
	}

	public void InActivePowerUpMode()
	{
		powerUpLengthCounter = 0;
	}

}
