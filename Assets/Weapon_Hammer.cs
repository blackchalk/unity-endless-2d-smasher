using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Hammer : Weapon {
	//------------------------------------------------
	//Default Sprite to show for weapon when active and not attacking
	public SpriteRenderer DefaultSprite = null;

	//Sound to play on attack
	public AudioClip WeaponAudio = null;

	//Audio Source for sound playback
	private AudioSource SFX = null;
	private AudioSource coinSound;
	private GameManager gameManager;
	//Reference to all child sprite renderers for this weapon
	private SpriteRenderer[] WeaponSprites = null;

	//------------------------------------------------
	void Start()
	{
		//Find sound object in scene
		//GameObject SoundsObject = GameObject.FindGameObjectWithTag("sounds");
		coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		//If no sound object, then exit
		//if (SoundsObject == null) return;

		////Get audio source component for sfx
		//SFX = SoundsObject.GetComponent<AudioSource>();

		//Get all child sprite renderers for weapon
		WeaponSprites = gameObject.GetComponentsInChildren<SpriteRenderer>();

		//Register weapon for weapon change events
		//GameManager.Notifications.AddListener(this, "WeaponChange");
	}
	//--------------------------------------------------------------
	// Update is called once per frame
	void Update()
	{
		//If not equipped then exit
		if (!IsEquipped) return;

		//If cannot accept input, then exit
		//if (!GameManager.Instance.InputAllowed) return;

		//Get ray from screen center target
		//Ray R = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 1.7f, 0));

		//Check for fire button input
		if (Input.GetMouseButtonDown(0) && CanFire && !gameManager.isPaused)
			StartCoroutine(Fire());
	}
	//------------------------------------------------
	//Coroutine to fire weapon
	public IEnumerator Fire()
	{
		//If can fire
		if (!CanFire || !IsEquipped) yield break;

		//Set refire to false
		CanFire = false;

		//Play Fire Animation
		gameObject.SendMessage("PlaySpriteAnimation", 0, SendMessageOptions.DontRequireReceiver);

		//Calculate hit

		//Get ray from screen center target
		Ray R = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 1.7f, 0));
		//Test for ray collision
		RaycastHit2D hit = Physics2D.Raycast(R.origin, R.direction);

		//Debug.DrawRay(R.origin, R.direction * 12, Color.yellow);

		if (hit.collider != null)
		{
			if (hit.collider.gameObject.CompareTag("normal"))
			{
				//Play collection sound, if audio source is available
				//if (SFX) { SFX.PlayOneShot(WeaponAudio, 1.0f); }
				if (coinSound)
				{
					coinSound.Play();
				}

				//Send damage message (deal damage to enemy)
				hit.collider.gameObject.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
				hit.collider.gameObject.SendMessage("decreaseHealth", Damage, SendMessageOptions.DontRequireReceiver);
			}
			if (hit.collider.gameObject.CompareTag("KillBox"))
			{
				hit.collider.gameObject.GetComponent<Item>().kill();
				Destroy(hit.collider.gameObject);
			}
			if (hit.collider.gameObject.CompareTag("bomb"))
			{
				hit.collider.gameObject.GetComponent<Item>().Bomb();
				Destroy(hit.collider.gameObject);
			}
			if (hit.collider.gameObject.CompareTag("life"))
			{
				hit.collider.gameObject.GetComponent<Item>().life();
				Destroy(hit.collider.gameObject);
			}
			if (hit.collider.gameObject.CompareTag("beehive"))
			{
				hit.collider.gameObject.GetComponent<Item>().beehive();
				Destroy(hit.collider.gameObject);
			}
			if (hit.collider.gameObject.CompareTag("2x"))
			{
				//send message
				hit.collider.gameObject.SendMessage("DoublePointMessage", null, SendMessageOptions.DontRequireReceiver);
				Destroy(hit.collider.gameObject);
			}
			if (hit.collider.gameObject.CompareTag("ice"))
			{
				//send message
				hit.collider.gameObject.SendMessage("IcePointMessage", null, SendMessageOptions.DontRequireReceiver);
				Destroy(hit.collider.gameObject);
			}
			if (hit.collider.gameObject.CompareTag("star"))
			{
				//send message
				hit.collider.gameObject.SendMessage("StarPointMessage", null, SendMessageOptions.DontRequireReceiver);
				Destroy(hit.collider.gameObject);
			}

			//isHit = false;
			//Destroy(GameObject.Find(hit.collider.gameObject.name));
			//Debug.Log("hit"+hit.collider.gameObject.tag);
		}



		//Wait for recovery before re-enabling CanFire
		yield return new WaitForSeconds(RecoveryDelay);

		//Re-enable CanFire
		CanFire = true;
	}
	//------------------------------------------------
	//Called when animation has completed playback
	public void SpriteAnimationStopped()
	{
		//If not equipped then exit
		if (!IsEquipped) return;

		//Show default sprite
		DefaultSprite.enabled = true;
	}
	//------------------------------------------------
	//Equip weapon
	public bool Equip(WEAPON_TYPE WeaponType)
	{
		//If not this type, then exit and no equip
		if ((WeaponType != Type) || (!Collected) || (Ammo == 0) || (IsEquipped)) return false;

		//Is this weapon. So equip
		IsEquipped = true;

		//Show default sprite
		DefaultSprite.enabled = true;

		//Activate Can Fire
		CanFire = true;

		//Send weapon change event
		//GameManager.Notifications.PostNotification(this, "WeaponChange");

		//Weapon was equipped
		return true;
	}
	//------------------------------------------------
	//Weapon change event - called when player changes weapon
	public void WeaponChange(Component Sender)
	{
		//Has player changed to this weapon?
		if (Sender.GetInstanceID() == GetInstanceID()) return;

		//Has changed to other weapon. Hide this weapon
		StopAllCoroutines();
		gameObject.SendMessage("StopSpriteAnimation", 0, SendMessageOptions.DontRequireReceiver);

		//Deactivate equipped
		IsEquipped = false;

		foreach (SpriteRenderer SR in WeaponSprites)
			SR.enabled = false;
	}
	//------------------------------------------------
}
