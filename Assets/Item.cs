using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int score;
    public bool beenClicked;
    public string effectType; //given by a higher class
    public int selectedWeapon;
    public GameObject weapon;
    private ScoreManager scoreManager;
    private EffectManager effectManager;
    private DataController dataController;
    private GameManager gameManager;
    private Explodable _exploadable;
    private Animator _anim;
    public SpriteRenderer childspriteRenderer;
    private void Awake()
    {
        effectManager = GameObject.Find("EffectManager").GetComponent<EffectManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        dataController = GameObject.Find("DataController").GetComponent<DataController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _exploadable = GetComponent<Explodable>();

        weapon = this.gameObject.transform.GetChild(0).gameObject;
        _anim = weapon.GetComponent<Animator>();
        childspriteRenderer = weapon.GetComponent<SpriteRenderer>();
        effectType = gameObject.tag;
    }
    // Use this for initialization
    void Start()
    {
        
        beenClicked = false;
        //setup weapon to use
        selectedWeapon = dataController.selectedWeapon;
        _anim.enabled = false;
        _anim.runtimeAnimatorController = dataController.animators[selectedWeapon];
        childspriteRenderer.sprite = dataController.spr[selectedWeapon];
        childspriteRenderer.enabled = false;

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

                if(gameObject.CompareTag("normal")){
                    
                    StartCoroutine("doTransitionOfSprite1");
                    dataController.SubmitNewPlayerCoins(1);
                    //StopCoroutine("doTransitionOfSprite1");
                }

                if(gameObject.CompareTag("bomb")){
                    ScoreManager.MinusHeart(1);
                }

				if (gameObject.CompareTag("life"))
				{
					ScoreManager.AddHeart(1);
				}
                if(gameObject.CompareTag("KillBox"))
                {
                    //ScoreManager.MinusHeart(ScoreManager.HeartCount);
                    gameManager.RestartGame();
                }

                }
                //Destroy(this.gameObject);
            }
        }

        public IEnumerator restartStatus(){
            beenClicked = false;
        Debug.Log("falsified");
            yield return new WaitForSeconds(0.4f);
        }

	IEnumerator doTransitionOfSprite()
	{
		yield return new WaitForSeconds(0.4f);
		Destroy(gameObject);
	}

	IEnumerator doTransitionOfSprite1()
	{
        childspriteRenderer.enabled = true;
        _anim.enabled = true;
		yield return new WaitForSeconds(0.4f);
		_exploadable.explode();
		ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
		ef.doExplosion(transform.position);
		//Destroy(gameObject);
	}

}
