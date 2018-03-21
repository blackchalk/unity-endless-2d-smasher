using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour {

    public int Health;
    public ScoreManager sm;
    //public EffectManager effectManager;
    public DataController dataController;
    public GameManager gameManager;
    private bool coinAdded;
    private void Awake()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        dataController = GameObject.Find("DataController").GetComponent<DataController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Use this for initialization
    void Start () {
        coinAdded = false;

        //Health = getMaxHealthByNumberOfScore(dataController.IncreaseHealthEvery);
        Health = dataController.potHealthLevel;
	}
	
	// Update is called once per frame
	void Update () {
        if(Health<=0){
            StartCoroutine("ie_AddScoreAndKill",1);
        }
	}

    //private int getMaxHealthByNumberOfScore(int modulo){
    //    float currentScore = sm.scoreCounts;

    //    int itemHealth = 1;
    //    int mod = (int)currentScore % modulo;
    //    if(mod==0){
    //        itemHealth = itemHealth + 1;
    //    }
    //    Debug.Log("modulo is e: " + mod);
    //    return itemHealth;
    //}

    public IEnumerator ie_AddScoreAndKill(int addToScore){

        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        Debug.Log("add1");
        sm.AddScore(addToScore);
        dataController.SubmitNewPlayerCoins(addToScore);
        Health = 0;

    }

    public void TakeDamage(int Damage){

            Health = Health - Damage;

    }
}
