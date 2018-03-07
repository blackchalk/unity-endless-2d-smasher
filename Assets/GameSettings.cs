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
    private int currentDoublePointCoinValue;
    private float icePointValue;
    private float starPointValue;

    public int coinsAccumulated;
    public Text coinText;
    public Text coinAnimateText;
    public Animator coinInsufficientFundsAnimation;
    private DataController dataController;

    private AudioSource audioSource;
    private AudioSource btnClick;

	// Use this for initialization
	void Start () {
        audioSource = GameObject.Find("Music").GetComponent<AudioSource>();
        btnClick = GameObject.Find("ButtonClick").GetComponent<AudioSource>();
        audioSource.Play();
        dataController = FindObjectOfType<DataController>();
        if (PlayerPrefs.HasKey("PlayerCoins"))
        {
            setUpViewsForCoins();
        }

        ////doublePoints
        if (PlayerPrefs.HasKey("DoublePointDuration"))
        {
            doublePointSlider.value = dataController.GetPlayerDoublePoint();
            setupDoublePointValue();
        }


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
        coinAnimateText.enabled = false;
        coinInsufficientFundsAnimation.enabled = false;

    }

    public void setUpViewsForCoins(){
		coinsAccumulated = dataController.GetPlayerCoins();
		coinText.text = "Coins:" + coinsAccumulated;
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
    //pass the value to a accessible variable
    private int getSliderValue(){
        doublePointValue = doublePointSlider.value;
        return (int)doublePointValue;
    }

    public void playClickSound(){
        btnClick.Play();
    }

    public void increasePointDuration(float x)
    {

        int nextLevelCoinValue = 0;

        setupDoublePointValue();

        nextLevelCoinValue = currentDoublePointCoinValue + 200;

        if (coinsAccumulated > nextLevelCoinValue)
        {
            //do the thing
            doublePointSlider.value += x;
            //math on coins
            dataController.DeductFromPlayerCoins(nextLevelCoinValue);
            dataController.SubmitNewPlayerDouble((int)doublePointSlider.value);
            setupDoublePointValue();
            setUpViewsForCoins();

        }else{
            StartCoroutine("doTransitionOfSprite1",nextLevelCoinValue);
            Debug.Log("insufficient funds.");
        }
        //if(coinInsufficientFundsAnimation.)
        //coinInsufficientFundsAnimation.enabled = false;


    }

    private void setupDoublePointValue()
    {
        switch (getSliderValue())
        {
            case 0: currentDoublePointCoinValue = 0; break;
            case 1: currentDoublePointCoinValue = 200; break;
            case 2: currentDoublePointCoinValue = 400; break;
            case 3: currentDoublePointCoinValue = 600; break;
            case 4: currentDoublePointCoinValue = 800; break;
            case 5: currentDoublePointCoinValue = 1000; break;
            case 6: currentDoublePointCoinValue = 1200; break;
            case 7: currentDoublePointCoinValue = 1400; break;
            case 8: currentDoublePointCoinValue = 1600; break;
            case 9: currentDoublePointCoinValue = 1800; break;
            case 10: currentDoublePointCoinValue = 2000; break;
        }
    }

    public void increaseIcePointDuration(float x)
    {
        iceSlider.value += x;
    }

    public void increaseStarPointDuration(float x)
    {
        starSlider.value += x;
    }

	//update prefs on button back pressed

	IEnumerator doTransitionOfSprite1(int next)
	{

		coinAnimateText.enabled = true;
		coinAnimateText.text = ("-" + next);
		coinInsufficientFundsAnimation.enabled = true;
		yield return new WaitForSeconds(0.5f);
		coinAnimateText.text = ("" + next);
		coinAnimateText.enabled = false;
        coinInsufficientFundsAnimation.enabled = false;
        StopCoroutine("doTransitionOfSprite1");
		//Destroy(gameObject);
	}

}
