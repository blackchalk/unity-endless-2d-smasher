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

    private int currentDoublePointCoinValue;
    private int currentIceValue;
    private int currentStarValue;

    public int coinsAccumulated;

    public Text coinText;
    public Text coinAnimateText;
    public Text hsText;
    private float hScore;
    public Animator coinInsufficientFundsAnimation;
    private DataController dataController;

    private AudioSource audioSource;
    private AudioSource btnClick;

    void Awake()
    {

		audioSource = GameObject.Find("Music").GetComponent<AudioSource>();
		btnClick = GameObject.Find("ButtonClick").GetComponent<AudioSource>();
		audioSource.Play();
		dataController = FindObjectOfType<DataController>();
    }
    // Use this for initialization
    void Start () {

		if (PlayerPrefs.HasKey("HighScores"))
		{
            hScore = PlayerPrefs.GetFloat("HighScores");
            hsText.text = "Highscore: " + Mathf.Round(hScore); 
		}

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
        if (PlayerPrefs.HasKey("IcePointDuration"))
        {
            iceSlider.value = dataController.GetPlayerIcePoint();
            setupIceValue();
        }

        ////invulnerable
        if (PlayerPrefs.HasKey("InvulnerablePointDuration"))
        {
            starSlider.value = dataController.GetPlayerInvulnerablePoint();
            setupStarValue();
        }

        coinAnimateText.enabled = false;
        coinInsufficientFundsAnimation.enabled = false;

    }

    public void setUpViewsForCoins(){
		coinsAccumulated = dataController.GetPlayerCoins();
		coinText.text = "Coins:" + coinsAccumulated;
    }

    //pass the value to a accessible variable
    private int getIceSliderValue()
    {
        icePointValue = iceSlider.value;
        return (int)icePointValue;
    }

    private int getStarSliderValue()
    {
        starPointValue = starSlider.value;
        return (int)starPointValue;
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
            //Debug.Log("insufficient funds.");
        }

    }


    public void increaseIceDuration(float x)
    {

        int nextLevelCoinValue = 0;

        setupIceValue();

        nextLevelCoinValue = currentIceValue + 200;

        if (coinsAccumulated > nextLevelCoinValue)
        {
            //do the thing
            iceSlider.value += x;
            //math
            dataController.DeductFromPlayerCoins(nextLevelCoinValue);
            dataController.SubmitNewPlayerIce((int)iceSlider.value);
            setupIceValue();
            setUpViewsForCoins();

        }
        else
        {
            StartCoroutine("doTransitionOfSprite1", nextLevelCoinValue);
            Debug.Log("insufficient funds.");
        }

    }

    public void increaseStarDuration(float x)
    {

        int nextLevelCoinValue = 0;

        setupStarValue();

        nextLevelCoinValue = currentStarValue + 200;

        if (coinsAccumulated > nextLevelCoinValue)
        {
            //do the thing
            starSlider.value += x;
            //math
            dataController.DeductFromPlayerCoins(nextLevelCoinValue);
            dataController.SubmitNewPlayerInvulnerable((int)starSlider.value);
            setupStarValue();
            setUpViewsForCoins();

        }
        else
        {
            StartCoroutine("doTransitionOfSprite1", nextLevelCoinValue);
            Debug.Log("insufficient funds.");
        }

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

    private void setupIceValue()
    {
        switch (getIceSliderValue())
        {
            case 0: currentIceValue = 0; break;
            case 1: currentIceValue = 200; break;
            case 2: currentIceValue = 400; break;
            case 3: currentIceValue = 600; break;
            case 4: currentIceValue = 800; break;
            case 5: currentIceValue = 1000; break;
            case 6: currentIceValue = 1200; break;
            case 7: currentIceValue = 1400; break;
            case 8: currentIceValue = 1600; break;
            case 9: currentIceValue = 1800; break;
            case 10: currentIceValue = 2000; break;
        }
    }

    private void setupStarValue()
    {
        switch (getStarSliderValue())
        {
            case 0: currentStarValue = 0; break;
            case 1: currentStarValue = 200; break;
            case 2: currentStarValue = 400; break;
            case 3: currentStarValue = 600; break;
            case 4: currentStarValue = 800; break;
            case 5: currentStarValue = 1000; break;
            case 6: currentStarValue = 1200; break;
            case 7: currentStarValue = 1400; break;
            case 8: currentStarValue = 1600; break;
            case 9: currentStarValue = 1800; break;
            case 10: currentStarValue = 2000; break;
        }
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


	//loads desired scene
	public void LoadScene(string sceneNameInBuildSettings)
	{
		SceneManager.LoadScene(sceneNameInBuildSettings);
	}
	//hides gameobject
	public void showOrHideGO(GameObject go)
	{
		if (go.activeSelf)
			go.SetActive(false);

		else
			go.SetActive(true);
	}
	//pass the value to a accessible variable
	private int getSliderValue()
	{
		doublePointValue = doublePointSlider.value;
		return (int)doublePointValue;
	}

}
