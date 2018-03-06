using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameSettings : MonoBehaviour {

    public Slider doublePointSlider;
    public Slider iceSlider;
    public Slider starSlider;

    private float doublePointValue;
    private float icePointValue;
    private float starPointValue;

    public int coinsAccumulated;
    public Text coinText;
    private DataController dataController;

	// Use this for initialization
	void Start () {
        
        dataController = FindObjectOfType<DataController>();
        if (PlayerPrefs.HasKey("PlayerCoins"))
        { 
            coinText.text = "Coins:"+dataController.GetPlayerCoins().ToString();
        }

        ////doublePoints
        //if (PlayerPrefs.HasKey("DoublePointDuration"))
        //{
        //    coinText.text = dataController.GetPlayerCoins().ToString();
        //}

        ////slow
        //if (PlayerPrefs.HasKey("IcePointDuration"))
        //{
        //    coinText.text = dataController.GetPlayerCoins().ToString();
        //}

        ////invulnerable
        //if (PlayerPrefs.HasKey("InvulnerablePointDuration"))
        //{
        //    coinText.text = dataController.GetPlayerCoins().ToString();
        //}

    }

    public void setUpViewsForCoins(){
        coinsAccumulated = dataController.GetPlayerCoins();
        coinText.text = coinsAccumulated.ToString();
    }


    //loads desired scene
    public void LoadScene(string sceneNameInBuildSettings){
        SceneManager.LoadScene(sceneNameInBuildSettings);
    }
    //hides gameobject
    public void showOrHideGO(GameObject go){
        if (go.activeSelf)
            go.SetActive(false);

        else
            go.SetActive(true);
    }

    public void increasePointDuration(float x){
        doublePointSlider.value += x;
    }

    //update prefs on button back pressed

}
