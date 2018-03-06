using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{

    private PlayerProgress playerProgress;

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
    }

    private void SavePlayerCoins()
    {

        PlayerPrefs.SetInt("PlayerCoins",playerProgress.PlayerCoins);
        Debug.Log("Saved coins.");
    }

    public void SubmitNewPlayerCoins(int newCoins){
        Debug.Log("add coins:" + newCoins);
        LoadPlayerCoins();
        playerProgress.PlayerCoins += newCoins;
        SavePlayerCoins();

    }

    public void DeductFromPlayerCoins(int coinAmount)
    {
        Debug.Log("deduct coins:" + coinAmount);
        LoadPlayerCoins();
        playerProgress.PlayerCoins -= coinAmount;
        SavePlayerCoins();

    }

    public int GetPlayerCoins(){
        LoadPlayerCoins();
        Debug.Log("saved coins total : " + playerProgress.PlayerCoins);
        return playerProgress.PlayerCoins;
    }
}
