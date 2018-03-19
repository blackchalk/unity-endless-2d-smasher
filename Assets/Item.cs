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
    public float weaponAnimationDelay;
    private ScoreManager scoreManager;
    private EffectManager effectManager;
    private DataController dataController;
    private GameManager gameManager;
    //private Explodable _exploadable;
    private Animator _anim;
    private AudioSource coinSound;
    private AudioSource lifeSound;
    private AudioSource deathSound;
    private AudioSource bombSound;
    public SpriteRenderer childspriteRenderer;
    private void Awake()
    {
        effectManager = GameObject.Find("EffectManager").GetComponent<EffectManager>();
        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
        lifeSound = GameObject.Find("LifeSound").GetComponent<AudioSource>();
        deathSound = GameObject.Find("DeathSound").GetComponent<AudioSource>();
        bombSound = GameObject.Find("BombSound").GetComponent<AudioSource>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        dataController = GameObject.Find("DataController").GetComponent<DataController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


        effectType = gameObject.tag;
    }
    // Use this for initialization
    void Start()
    {
        
        beenClicked = false;
   //     if (effectType == "normal")
   //     {
			////_exploadable = GetComponent<Explodable>();

			weapon = gameObject.transform.GetChild(0).gameObject;
			_anim = weapon.GetComponent<Animator>();
			childspriteRenderer = weapon.GetComponent<SpriteRenderer>();
            //setup weapon to use
            selectedWeapon = dataController.selectedWeapon;
            _anim.enabled = false;
            _anim.runtimeAnimatorController = dataController.animators[selectedWeapon];
            childspriteRenderer.sprite = dataController.spr[selectedWeapon];
            childspriteRenderer.enabled = false;
        //}

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

                //if (beenClicked)
                //{
                //    return;
                //}
                //else
                //{

                    //beenClicked = true;

                    if(gameObject.CompareTag("normal") && !gameManager.isPaused){
                        scoreManager.AddScore(score);
                        coinSound.Play();
                        StartCoroutine("doTransitionOfSprite1");
                        dataController.SubmitNewPlayerCoins(1);
                    }

                    if(gameObject.CompareTag("bomb")){
                        bombSound.Play();
                        StartCoroutine("doTransitionOfSprite1");
                        ScoreManager.MinusHeart(1);
                    }

        			if (gameObject.CompareTag("life"))
        			{
                        lifeSound.Play();
                        StartCoroutine("doTransitionOfSprite1");
        				ScoreManager.AddHeart(1);
        			}
                    if(gameObject.CompareTag("KillBox"))
                    {
                        deathSound.Play();
                        StartCoroutine("doTransitionOfSprite1");
                        gameManager.RestartGame();
                    }
                    if (gameObject.CompareTag("2x"))
                    {
                        //deathSound.Play();
                        StartCoroutine("doTransitionOfSprite1");
                        //gameManager.RestartGame();
                    }
                    if (gameObject.CompareTag("ice"))
                    {
                        //deathSound.Play();
                        StartCoroutine("doTransitionOfSprite1");
                        //gameManager.RestartGame();
                    }
                    if (gameObject.CompareTag("star"))
                    {
                        //deathSound.Play();
                        StartCoroutine("doTransitionOfSprite1");
                        //gameManager.RestartGame();
                    }
                if (gameObject.CompareTag("beehive"))
                {
                    //deathSound.Play();
                    StartCoroutine("doTransitionOfSprite1");
                    //gameManager.RestartGame();
                }

                //}
            }
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
		yield return new WaitForSeconds(weaponAnimationDelay);
        _anim.enabled = false;
        //_exploadable.explode();
		//ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
		//ef.doExplosion(transform.position);
		//Destroy(gameObject);
	}

}
