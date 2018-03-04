using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChoiceManager : MonoBehaviour {

public GameObject prevBtn;
	public GameObject nextBtn;
	public GameObject instructionHolderObj;
	public Sprite[] spr = new Sprite[9];
	public Sprite initialPage;
	private Image currentSprite;
	public int x;

	// Use this for initialization
	void Start()
	{
		currentSprite = instructionHolderObj.GetComponentInChildren<Image>();
		prevBtn.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (x == 8)
		{
			nextBtn.SetActive(false);
		}
		else
		{
			nextBtn.SetActive(true);
		}
		if (x == -1)
		{
			currentSprite.sprite = initialPage;
			prevBtn.SetActive(false);
		}
		else
		{
			prevBtn.SetActive(true);
		}

	}

	public void nextpage()
	{
		turnpageplus(x);
	}
	public void prevpage()
	{
		turnpageminus(x);
	}

	public void turnpageplus(int currentpage)
	{

		currentpage = currentpage + 1;
		currentSprite.sprite = spr[currentpage];
		x = currentpage;

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
			x = currentpage;
		}

	}

}
