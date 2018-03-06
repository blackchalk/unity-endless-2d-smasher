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
    public int levelPointsMultiplier = 100;//100

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadPlayerCoins();
    }

    private void LoadPlayerCoins()
    {

        playerProgress = new PlayerProgress();

        if (PlayerPrefs.HasKey("PlayerCoins"))
        {
            playerProgress.PlayerCoins = PlayerPrefs.GetInt("PlayerCoins");
        }

        //if (PlayerPrefs.HasKey("DoublePointDuration"))
        //{
        //    playerProgress.PlayerDoublePointPurchased = PlayerPrefs.GetInt("DoublePointDuration");
        //}

        //if (PlayerPrefs.HasKey("IcePointDuration"))
        //{
        //    playerProgress.PlayerIcePointPurchased = PlayerPrefs.GetInt("IcePointDuration");
        //}

        //if (PlayerPrefs.HasKey("InvulnerablePointDuration"))
        //{
        //    playerProgress.PlayerInvunerablePointPurchased = PlayerPrefs.GetInt("InvulnerablePointDuration");
        //}
    }

    private void SavePlayerCoins()
    {

        PlayerPrefs.SetInt("PlayerCoins",playerProgress.PlayerCoins);
        Debug.Log("Saved coins."+playerProgress.PlayerCoins);
    }

    private void SavePlayerDoublePoints()
    {

        PlayerPrefs.SetInt("DoublePointDuration", playerProgress.PlayerDoublePointPurchased);
        Debug.Log("Saved DoublePointDuration." + playerProgress.PlayerDoublePointPurchased);
    }

    private void SavePlayerIcePoints()
    {

        PlayerPrefs.SetInt("SavePlayerIcePoints", playerProgress.PlayerIcePointPurchased);
        Debug.Log("Saved SavePlayerIcePoints." + playerProgress.PlayerIcePointPurchased);
    }

    private void SavePlayerInvulnerablePoints()
    {

        PlayerPrefs.SetInt("SavePlayerInvulnerablePoints", playerProgress.PlayerInvunerablePointPurchased);
        Debug.Log("Saved SavePlayerInvulnerablePoints." + playerProgress.PlayerInvunerablePointPurchased);
    }
    //submit
    public void SubmitNewPlayerCoins(int newCoins){
        Debug.Log("add coins:" + newCoins);
        LoadPlayerCoins();
        playerProgress.PlayerCoins += newCoins;
        SavePlayerCoins();

    }

    public void SubmitNewPlayerDouble(int newPurchased)
    {
        Debug.Log("add coins:" + newPurchased);
        LoadPlayerCoins();
        playerProgress.PlayerDoublePointPurchased += newPurchased;
        SavePlayerDoublePoints();

    }

    public void SubmitNewPlayerIce(int newCoins)
    {
        Debug.Log("add coins:" + newCoins);
        LoadPlayerCoins();
        playerProgress.PlayerIcePointPurchased += newCoins;
        SavePlayerIcePoints();

    }

    public void SubmitNewPlayerInvulnerable(int newCoins)
    {
        Debug.Log("add coins:" + newCoins);
        LoadPlayerCoins();
        playerProgress.PlayerInvunerablePointPurchased += newCoins;
        SavePlayerInvulnerablePoints();

    }

    public void DeductFromPlayerCoins(int coinAmount)
    {
        Debug.Log("DeductFromPlayerCoins:" + coinAmount);
        LoadPlayerCoins();
        playerProgress.PlayerCoins -= coinAmount;
        SavePlayerCoins();

    }

    public int GetPlayerCoins(){
        LoadPlayerCoins();
        Debug.Log("GetPlayerCoins: " + playerProgress.PlayerCoins);
        return playerProgress.PlayerCoins;
    }

    public int GetPlayerDoublePoint()
    {
        LoadPlayerCoins();
        Debug.Log("GetPlayerDoublePoint: " + playerProgress.PlayerDoublePointPurchased);
        return playerProgress.PlayerDoublePointPurchased;
    }

    public int GetPlayerIcePoint()
    {
        LoadPlayerCoins();
        Debug.Log("GetPlayerDoublePoint: " + playerProgress.PlayerIcePointPurchased);
        return playerProgress.PlayerIcePointPurchased;
    }

    public int GetPlayerInvulnerablePoint()
    {
        LoadPlayerCoins();
        Debug.Log("GetPlayerInvulnerablePoint: " + playerProgress.PlayerInvunerablePointPurchased);
        return playerProgress.PlayerInvunerablePointPurchased;
    }
}
