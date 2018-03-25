using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weapon_Profile : MonoBehaviour {

	public int weapon_id;
    public int cost;
	public int totalCoins;
    public bool isselected;
    public int isunlocked;
    public GameObject t_toggleObj;
    public Button t_buttonObj;
    public Text t_textObj;

	public int coinsAccumulated;
    public Toggle m_Toggle;
	public Text coinText;
	public Text coinAnimateText;
	public Animator coinInsufficientFundsAnimation;
    public GameSettings gm;

    private DataController dc;

    private void Awake()
    {
        
        gm = GameObject.Find("Manager").GetComponent<GameSettings>();
        dc = GameObject.Find("DataController").GetComponent<DataController>();
    }

    private void Start()
    {
        if(t_toggleObj.activeSelf){
			m_Toggle = GetComponentInChildren<Toggle>();
			//Add listener for when the state of the Toggle changes, to take action
			m_Toggle.onValueChanged.AddListener(delegate {
				ToggleValueChanged(m_Toggle);
			});
        }


        setUpViewsForCoins();

        refreshData();

    }


	//Output the new state of the Toggle into Text
	void ToggleValueChanged(Toggle change)
	{
        //m_Text.text = "New Value : " + m_Toggle.isOn;
        if(m_Toggle.isOn){
            dc.SavePlayerWeapon(weapon_id);
            //refreshData();
        }
	}

    public void refreshData()
    {
        coinAnimateText.enabled = false;
        coinInsufficientFundsAnimation.enabled = false;

        switch (weapon_id)
        {
            case 0:

                if (PlayerPrefs.HasKey("isWoodUnlocked"))
                {
                    isunlocked = PlayerPrefs.GetInt("isWoodUnlocked");

                }

                break;
            case 1:

                if (PlayerPrefs.HasKey("isBaseballUnlocked"))
                {
                    isunlocked = PlayerPrefs.GetInt("isBaseballUnlocked");

                }

                break;
            case 2:

                if (PlayerPrefs.HasKey("isWoodHUnlocked"))
                {
                    isunlocked = PlayerPrefs.GetInt("isWoodHUnlocked");

                }

                break;
            case 3:

                if (PlayerPrefs.HasKey("isWoodH2Unlocked"))
                {
                    isunlocked = PlayerPrefs.GetInt("isWoodH2Unlocked");

                }
                break;
            case 4:

                if (PlayerPrefs.HasKey("isPoliceUnlocked"))
                {
                    isunlocked = PlayerPrefs.GetInt("isPoliceUnlocked");

                }

                break;
            case 5:

                if (PlayerPrefs.HasKey("isThorUnlocked"))
                {
                    isunlocked = PlayerPrefs.GetInt("isThorUnlocked");

                }

                break;
            default: break;
        }

        //get coins
        if (PlayerPrefs.HasKey("PlayerCoins"))
        {
            totalCoins = PlayerPrefs.GetInt("PlayerCoins");
        }
        //check what is the selected weapon
        if (PlayerPrefs.HasKey("PlayerWeaponChosen"))
        {
            if (weapon_id == PlayerPrefs.GetInt("PlayerWeaponChosen"))
            {
                t_toggleObj.GetComponent<Toggle>().isOn = true;
            }
            else
            {
                t_toggleObj.GetComponent<Toggle>().isOn = false;
            }

        }
        //set ui
        if (isunlocked == 1)
        {
            t_textObj.text = "Owned";
            t_buttonObj.enabled = false;
            t_toggleObj.SetActive(true);
        }
        else
        {
            //check if you owned this otherwise disable use checkbox
            t_toggleObj.GetComponent<Toggle>().isOn = false;
            t_toggleObj.SetActive(false);
        }
    }

    public void setUpViewsForCoins()
	{
		coinsAccumulated = dc.GetPlayerCoins();
		coinText.text = "Coins:" + coinsAccumulated;
	}

    public void BuyItem(){
        
        int coins = totalCoins;
        if(coins > cost){
            
            coins -= cost;
            dc.DeductFromPlayerCoins(cost);
			switch (weapon_id)
			{
				case 0:

					//if (PlayerPrefs.HasKey("isWoodUnlocked"))
					//{
						PlayerPrefs.SetInt("isWoodUnlocked",1);

					//}

					break;
				case 1:

					//if (PlayerPrefs.HasKey("isBaseballUnlocked"))
					//{
						PlayerPrefs.SetInt("isBaseballUnlocked",1);

					//}

					break;
				case 2:

					//if (PlayerPrefs.HasKey("isWoodHUnlocked"))
					//{
						PlayerPrefs.SetInt("isWoodHUnlocked",1);

					//}

					break;
				case 3:

					//if (PlayerPrefs.HasKey("isWoodH2Unlocked"))
					//{
						PlayerPrefs.SetInt("isWoodH2Unlocked",1);

					//}
					break;
				case 4:

					//if (PlayerPrefs.HasKey("isPoliceUnlocked"))
					//{
						PlayerPrefs.SetInt("isPoliceUnlocked",1);

					//}

					break;
				case 5:

					//if (PlayerPrefs.HasKey("isThorUnlocked"))
					//{
						PlayerPrefs.SetInt("isThorUnlocked",1);

					//}

					break;
				default: break;
			}
            setUpViewsForCoins();
            refreshData();
        
        }else{
            Debug.Log("insufficient coins!");
        }
		StartCoroutine("doTransitionOfSprite1", cost);
    }

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

