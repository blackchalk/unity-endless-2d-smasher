using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChoiceManager : MonoBehaviour {

public GameObject prevBtn;
	public GameObject nextBtn;
	public GameObject instructionHolderObj;
	public Sprite[] spr = new Sprite[5];
    public string[] txtDescription = new string[6];
    public GameObject[] go_weaponBuyButtons;
    public Text txt_DescriptionObject;
	public Sprite initialPage;
	private Image currentSprite;
    private DataController dc;
	public int x;

	// Use this for initialization
	void Start()
	{
		currentSprite = instructionHolderObj.GetComponentInChildren<Image>();
        dc = GameObject.Find("DataController").GetComponent<DataController>();
		prevBtn.SetActive(false);

        //if (PlayerPrefs.HasKey("PlayerWeaponChosen"))
        //{
        //    x = PlayerPrefs.GetInt("PlayerWeaponChosen");
        //    setPage(x);
        //}else
        //{
        //    x = 0;
        //}

        txtDescription[0] = "Name: Wood\nDamage:1\nCost:0";
        txtDescription[1] = "Name: Baseball Bat\nDamage:4\nCost:400";
        txtDescription[2] = "Name: Wood Hammer\nDamage:8\nCost:800";
        txtDescription[3] = "Name: Hammer\nDamage:16\nCost:1600";
		txtDescription[4] = "Name: Police Bat\nDamage:32\nCost:3200";
        txtDescription[5] = "Name: Thor's Hammer\nDamage:64\nCost:6400";

        //txt_DescriptionObject.text = txtDescription[0];
        foreach(GameObject g in go_weaponBuyButtons){
            g.SetActive(false);
        }

        go_weaponBuyButtons[0].SetActive(true);

	}

	// Update is called once per frame
	void Update()
	{
        if (x == spr.Length-1)
		{
			nextBtn.SetActive(false);
		}
		else
		{
			nextBtn.SetActive(true);
		}
		if (x == 0)
		{
			currentSprite.sprite = initialPage;
            txt_DescriptionObject.text = txtDescription[0];
			prevBtn.SetActive(false);
		}
		else
		{
			prevBtn.SetActive(true);
		}

        //if(x!=-1 && x!=txtDescription.Length){
        //    txt_DescriptionObject.text = txtDescription[x];
        //}

	}

	public void nextpage()
	{
		turnpageplus(x);
	}
	public void prevpage()
	{
		turnpageminus(x);
	}

	public void setPage(int currentpage)
	{
		currentSprite.sprite = spr[currentpage];
	}

	public void turnpageplus(int currentpage)
	{
		
		currentpage = currentpage + 1;
		currentSprite.sprite = spr[currentpage];
		txt_DescriptionObject.text = txtDescription[currentpage];
		x = currentpage;
		//loop all buttons
		for (int b = 0; b < go_weaponBuyButtons.Length; b++)
		{
			if (b == x)
			{
				go_weaponBuyButtons[b].SetActive(true);
				go_weaponBuyButtons[b].SendMessage("refreshData", null, SendMessageOptions.DontRequireReceiver);
			}
			else
				go_weaponBuyButtons[b].SetActive(false);
		}

	}
	public void turnpageminus(int currentpage)
	{

		if (currentpage == 0)
		{
			x = -1;
		}
		else
		{
			
			currentpage = currentpage - 1;
			currentSprite.sprite = spr[currentpage];
			txt_DescriptionObject.text = txtDescription[currentpage];
			x = currentpage;
            //loop all buttons
            for (int b = 0; b < go_weaponBuyButtons.Length; b++){
                if(b==x){
                    go_weaponBuyButtons[b].SetActive(true);
                    go_weaponBuyButtons[b].SendMessage("refreshData", null, SendMessageOptions.DontRequireReceiver);
                }else
                go_weaponBuyButtons[b].SetActive(false);
            }
		}

	}

    public void getWeaponOnBackPressed(){
        //dc.selectedWeapon = x;
        //save it locally
        dc.SavePlayerWeapon(x);
    }

    public void act_BuyButton(){
        
    }

}
