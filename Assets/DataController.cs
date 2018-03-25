using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{

    private PlayerProgress playerProgress;
    //weapons
    public Sprite[] spr;
    public RuntimeAnimatorController[] animators;
    public int selectedWeapon;
    //upgrades
    public int doublePointLevel;
    public int icePointLevel;
    public int invulnerablePointLevel;
	//public int levelPointsMultiplier = 100;//100

	private static DataController _instance;

	public static DataController instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<DataController>();

				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}

			return _instance;
		}
	}

	void Awake()
	{
		if (_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if (this != _instance)
				Destroy(this.gameObject);
		}
	}

    void Start()
    {
        //SubmitNewPlayerCoins(10000);
        //selectedWeapon = GetPlayerEquippedWeapon();
            if (PlayerPrefs.HasKey("isWoodUnlocked"))
            {

            }
            else
            {
                PlayerPrefs.SetInt("isWoodUnlocked", 1);
                SavePlayerWeapon(0);

            }

    }
    //get
    public int GetPlayerEquippedWeapon(){
        
        //playerProgress.PlayerWeaponChosen = 0;//default

		if (PlayerPrefs.HasKey("PlayerWeaponChosen"))
		{
			//playerProgress.PlayerWeaponChosen = PlayerPrefs.GetInt("PlayerWeaponChosen");
            return PlayerPrefs.GetInt("PlayerWeaponChosen");

        }

        //return playerProgress.PlayerWeaponChosen;
		return PlayerPrefs.GetInt("PlayerWeaponChosen");

	}
    //set
	public void SavePlayerWeapon(int _weapon)
	{
		PlayerPrefs.SetInt("PlayerWeaponChosen", _weapon);
		Debug.Log("Saved PlayerWeaponChosen." + _weapon);
        selectedWeapon = GetPlayerEquippedWeapon();
	}

    private void setupupPrefs()
    {

        playerProgress = new PlayerProgress();

		playerProgress.PlayerWeaponChosen = 0;//default

		if (PlayerPrefs.HasKey("PlayerWeaponChosen"))
		{
			playerProgress.PlayerWeaponChosen = PlayerPrefs.GetInt("PlayerWeaponChosen");

		}

		selectedWeapon = playerProgress.PlayerWeaponChosen;

		if (PlayerPrefs.HasKey("PlayerCoins"))
        {
            playerProgress.PlayerCoins = PlayerPrefs.GetInt("PlayerCoins");
        }

        if (PlayerPrefs.HasKey("DoublePointDuration"))
        {
            playerProgress.PlayerDoublePointPurchased = PlayerPrefs.GetInt("DoublePointDuration");
            doublePointLevel = playerProgress.PlayerDoublePointPurchased;
        }

        if (PlayerPrefs.HasKey("IcePointDuration"))
        {
            playerProgress.PlayerIcePointPurchased = PlayerPrefs.GetInt("IcePointDuration");
            icePointLevel = playerProgress.PlayerIcePointPurchased;
        }

        if (PlayerPrefs.HasKey("InvulnerablePointDuration"))
        {
            playerProgress.PlayerInvunerablePointPurchased = PlayerPrefs.GetInt("InvulnerablePointDuration");
            invulnerablePointLevel = playerProgress.PlayerInvunerablePointPurchased;
        }
    }

    private void SavePlayerCoins()
    {

        PlayerPrefs.SetInt("PlayerCoins",playerProgress.PlayerCoins);
        //Debug.Log("Saved coins."+playerProgress.PlayerCoins);
    }

    private void SavePlayerDoublePoints()
    {

        PlayerPrefs.SetInt("DoublePointDuration", playerProgress.PlayerDoublePointPurchased);
        //Debug.Log("Saved DoublePointDuration." + playerProgress.PlayerDoublePointPurchased);
    }

    private void SavePlayerIcePoints()
    {

        PlayerPrefs.SetInt("IcePointDuration", playerProgress.PlayerIcePointPurchased);
        Debug.Log("Saved IcePointDuration." + playerProgress.PlayerIcePointPurchased);
    }

    private void SavePlayerInvulnerablePoints()
    {

        PlayerPrefs.SetInt("InvulnerablePointDuration", playerProgress.PlayerInvunerablePointPurchased);
        Debug.Log("Saved InvulnerablePointDuration." + playerProgress.PlayerInvunerablePointPurchased);
    }
    //submit
    public void SubmitNewPlayerCoins(int newCoins){
        //Debug.Log("add coins:" + newCoins);
        setupupPrefs();
        playerProgress.PlayerCoins += newCoins;
        SavePlayerCoins();

    }

    public void SubmitNewPlayerDouble(int newPurchased)
    {
        //Debug.Log("add coins:" + newPurchased);
        setupupPrefs();
        playerProgress.PlayerDoublePointPurchased += newPurchased;
        SavePlayerDoublePoints();

    }

    public void SubmitNewPlayerIce(int newCoins)
    {
        //Debug.Log("add coins:" + newCoins);
        setupupPrefs();
        playerProgress.PlayerIcePointPurchased += newCoins;
        SavePlayerIcePoints();

    }

    public void SubmitNewPlayerInvulnerable(int newCoins)
    {
        //Debug.Log("add coins:" + newCoins);
        setupupPrefs();
        playerProgress.PlayerInvunerablePointPurchased += newCoins;
        SavePlayerInvulnerablePoints();

    }

    public void DeductFromPlayerCoins(int coinAmount)
    {
        //Debug.Log("DeductFromPlayerCoins:" + coinAmount);
        setupupPrefs();
        playerProgress.PlayerCoins -= coinAmount;
        SavePlayerCoins();

    }

    public int GetPlayerCoins(){
        setupupPrefs();
        //Debug.Log("GetPlayerCoins: " + playerProgress.PlayerCoins);
        return playerProgress.PlayerCoins;
    }

    public int GetPlayerDoublePoint()
    {
        setupupPrefs();
        //Debug.Log("GetPlayerDoublePoint: " + playerProgress.PlayerDoublePointPurchased);
        return playerProgress.PlayerDoublePointPurchased;
    }

    public int GetPlayerIcePoint()
    {
        setupupPrefs();
        //Debug.Log("GetPlayerDoublePoint: " + playerProgress.PlayerIcePointPurchased);
        return playerProgress.PlayerIcePointPurchased;
    }

    public int GetPlayerInvulnerablePoint()
    {
        setupupPrefs();
        //Debug.Log("GetPlayerInvulnerablePoint: " + playerProgress.PlayerInvunerablePointPurchased);
        return playerProgress.PlayerInvunerablePointPurchased;
    }

}
