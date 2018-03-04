using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

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
    void Start()
    {
        beenClicked = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            effectManager.currentGameEffect = effectType;
            Debug.Log("" + gameObject.tag + " clicked.");

                if (beenClicked)
                {
                    return;
                }
                else
                {

                        scoreManager.AddScore(score);
                        beenClicked = true;

                if(gameObject.CompareTag("bomb")){
                    ScoreManager.MinusHeart(1);
                }

				if (gameObject.CompareTag("life"))
				{
					ScoreManager.AddHeart(1);
				}
                if(gameObject.CompareTag("KillBox")){
                    
                    ScoreManager.MinusHeart(ScoreManager.HeartCount);
                }
                }
            }
        }

        public IEnumerator restartStatus(){
            beenClicked = false;
        Debug.Log("falsified");
            yield return new WaitForSeconds(0.5f);
        }

}
