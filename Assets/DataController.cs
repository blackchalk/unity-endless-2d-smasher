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
        Debug.Log("Saving coins.");
        PlayerPrefs.SetInt("PlayerCoins",playerProgress.PlayerCoins);
    }

    public void SubmitNewPlayerCoins(int newCoins){
        Debug.Log("additional coins:" + newCoins);
        LoadPlayerCoins();
        playerProgress.PlayerCoins += newCoins;
        SavePlayerCoins();
        Debug.Log("new Coin total : "+playerProgress.PlayerCoins);
    }

    public int GetPlayerCoins(){
        
        return playerProgress.PlayerCoins;
    }
}
