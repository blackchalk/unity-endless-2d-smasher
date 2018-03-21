using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour {

    public int Health;
    public ScoreManager sm;
    public EffectManager effectManager;
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

        Health = getMaxHealthByNumberOfScore(dataController.IncreaseHealthEvery);
	}
	
	// Update is called once per frame
	void Update () {
        if(Health<=0){
            //destroy this gameObject
            Destroy(gameObject);
        }
		
	}

    private int getMaxHealthByNumberOfScore(int modulo){
        float currentScore = sm.scoreCounts;

        int itemHealth = 1;
        int mod = (int)currentScore % modulo;
        if(mod==0){
            itemHealth += Health;
        }

        return itemHealth;


    }

    public void TakeDamage(int Damage){

        int curr_Health = Health;

        if(curr_Health<=0){
            sm.AddScore(1);
            dataController.SubmitNewPlayerCoins(1);
            gameObject.SendMessage("decreaseHealth", Damage, SendMessageOptions.DontRequireReceiver);
        }else{
            
            curr_Health = curr_Health - Damage;
            Health = curr_Health;
        }
    }
}
