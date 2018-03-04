using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp2 : MonoBehaviour {

	public bool doublePointMode;
	public bool spikeProffMode;
    public bool invulnerableMode;
    public bool iceMode;

	public float powerUpLength;
    private EffectManager powerUpManager;
	private AudioSource powerUpSource;
    private PlayerController pc;
    public bool beenClicked = false;

    //public Sprite[] upgradablePowerups;
    public int powerUpSelector;

	private void Awake()
	{
		//int powerUpSelector = Random.Range(0, 3);
		//GetComponent<SpriteRenderer>().sprite = upgradablePowerups[powerUpSelector];
		if (gameObject.CompareTag("2x"))
		{
			powerUpSelector = 0;
		}
		else if (gameObject.CompareTag("ice"))
		{
			powerUpSelector = 1;
		}
		else if (gameObject.CompareTag("star"))
		{
			powerUpSelector = 2;
		}
		else
		{
			powerUpSelector = 3;
		}

	}

	// Use this for initialization
	void Start()
	{
		powerUpManager = FindObjectOfType<EffectManager>();
		powerUpSource = GameObject.Find("PowerUpSound").GetComponent<AudioSource>();
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
		switch (powerUpSelector)
		{
			case 0:
				doublePointMode = true;
				break;
			case 1:
				iceMode = true;
                break;
			case 2:
				spikeProffMode = true;
				break;
			case 3:
				invulnerableMode = true;
				break;
		}
	}



	public void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{

			if (beenClicked)
			{
				return;
			}
			else
			{

				if (gameObject.tag == "2x")
				{
					powerUpSource.Play();
					powerUpManager.ActivePowerUpMode(doublePointMode, iceMode, spikeProffMode, pc.moveSpeed, powerUpLength);
				}
				else if (gameObject.tag == "ice")
				{
					powerUpSource.Play();
					powerUpManager.ActivePowerUpMode(doublePointMode, iceMode, spikeProffMode, pc.moveSpeed, powerUpLength);
				}
				beenClicked = true;
			}

		}
	}

}
