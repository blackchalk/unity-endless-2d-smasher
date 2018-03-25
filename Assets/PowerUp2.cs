using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp2 : MonoBehaviour {

	public bool doublePointMode;
    public bool starMode;
    public bool iceMode;

	public float powerUpLength = 1;
    public float powerUpIceLength = 1;
    public float powerUpStarLength = 1;
    private EffectManager powerUpManager;
	private AudioSource powerUpSource;
    private PlayerController pc;
    private DataController dc;

    //public Sprite[] upgradablePowerups;
    public int powerUpSelector;

	private void Awake()
	{
		powerUpManager = FindObjectOfType<EffectManager>();
		powerUpSource = GameObject.Find("PowerUpSound").GetComponent<AudioSource>();
		pc = GameObject.Find("Player").GetComponent<PlayerController>();
        dc = GameObject.Find("DataController").GetComponent<DataController>();
		//int powerUpSelector = Random.Range(0, 3);
		//GetComponent<SpriteRenderer>().sprite = upgradablePowerups[powerUpSelector];


	}

	// Use this for initialization
	void Start()
    {
        powerUpSelector = setpowerUpType(gameObject.tag);

        switch (powerUpSelector)
        {
            case 0:
                powerUpLength += dc.GetPlayerDoublePoint();
                doublePointMode = true;
                break;
            case 1:
                iceMode = true;
                powerUpIceLength += dc.GetPlayerIcePoint();
                break;
            case 2:
                starMode = true;
                powerUpStarLength += dc.GetPlayerInvulnerablePoint();
                break;
            default: break;
        }
    }

    private int setpowerUpType(string _tag)
    {
        int x = -1;

        if (_tag.Equals("2x"))
        {
            x = 0;
        }
        else if (_tag.Equals("ice"))
        { 
            x = 1;
        }
		else if (_tag.Equals("star"))
		{ 
            x = 2;
        }

        return x;
    }


    //message
    public void DoublePointMessage(){
		powerUpSource.Play();
        powerUpManager.ActivateDoublePoint(doublePointMode, powerUpLength);

	}
    //message
	public void IcePointMessage()
	{
		powerUpSource.Play();
        powerUpManager.ActivateIcePoint(iceMode, pc.moveSpeed, powerUpIceLength);

	}

	public void StarPointMessage()
	{
		powerUpSource.Play();
        powerUpManager.ActivateStarPoint(starMode, powerUpStarLength);

	}
}
