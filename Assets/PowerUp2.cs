using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp2 : MonoBehaviour {

	public bool doublePointMode;
	public bool spikeProffMode;
    public bool invulnerableMode;

	public float powerUpLength;
    private EffectManager powerUpManager;
	private AudioSource powerUpSource;

    //public Sprite[] upgradablePowerups;
    public int powerUpSelector;

	// Use this for initialization
	void Start()
	{
		powerUpManager = FindObjectOfType<EffectManager>();
		powerUpSource = GameObject.Find("PowerUpSound").GetComponent<AudioSource>();

		switch (powerUpSelector)
		{
			case 0:
				doublePointMode = true;
				break;
			case 1:
				spikeProffMode = true;
				break;
			case 2:
				invulnerableMode = true;
				break;
		}
	}

	private void Awake()
	{
        //int powerUpSelector = Random.Range(0, 3);
        //GetComponent<SpriteRenderer>().sprite = upgradablePowerups[powerUpSelector];
        if(gameObject.CompareTag("2x")){
            powerUpSelector = 0;
        }else if(gameObject.CompareTag("ice")){
            powerUpSelector = 1;
		}else if (gameObject.CompareTag("star"))
		{
			powerUpSelector = 2;
        }else{
            powerUpSelector = 3;
        }

	}

	//private void OnTriggerEnter2D(Collider2D other)
	//{
	//	if (other.name.Equals("Player"))
	//	{
	//		powerUpSource.Play();
	//		powerUpManager.ActivePowerUpMode(doublePointMode, spikeProffMode, powerUpLength);
	//	}
	//	gameObject.SetActive(false);
	//}

	private void OnMouseDown()
	{
		powerUpSource.Play();
		powerUpManager.ActivePowerUpMode(doublePointMode, spikeProffMode, powerUpLength);
	}
}
