using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public int score;
    public bool beenClicked;
    public string effectType; //given by a higher class
    private ScoreManager scoreManager;
    private EffectManager effectManager;

    private void Awake()
    {
        effectManager = GameObject.Find("EffectManager").GetComponent<EffectManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        effectType = gameObject.tag;
    }
    // Use this for initialization
    void Start () {
        beenClicked = false;
	}
	
	// Update is called once per frame
	void Update () {
        //if(gameObject.activeInHierarchy){
        //    StartCoroutine(restartStatus());
        //}
	}

    private void OnMouseDown()
    {
		effectManager.currentGameEffect = effectType;

        //if(beenClicked){
        //    return;
        //}else{
            
			if (gameObject.tag == "normal")
			{
				scoreManager.AddScore(score);
			} 
        //    beenClicked = true;
        //}
    }

    //IEnumerator restartStatus(){
    //    beenClicked = false;
    //    yield return new WaitForSeconds(0.5f);
    //}
}
