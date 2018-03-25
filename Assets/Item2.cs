using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour {

    public int Health;
    public ScoreManager sm;
    public EffectManager effectManager;
    public DataController dataController;
    public GameManager gameManager;

    private void Awake()
    {
        effectManager = GameObject.Find("EffectManager").GetComponent<EffectManager>();
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        dataController = GameObject.Find("DataController").GetComponent<DataController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Use this for initialization
    void Start () {
        Health = effectManager.potHealthLevel;
	}
	
	// Update is called once per frame
	void Update () {
        
        if(Health<=0){
            
            StartCoroutine("ie_AddScoreAndKill",1);

        }
	}


    public IEnumerator ie_AddScoreAndKill(int addToScore){

        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        //Randomize items with coins
        if (Random.Range(0, 50) > 30)
        {
            sm.AddScore(addToScore);
            dataController.SubmitNewPlayerCoins(addToScore);
        }
        Health = 0;

    }

    public void TakeDamage(int Damage){

            Health = Health - Damage;

    }
}
