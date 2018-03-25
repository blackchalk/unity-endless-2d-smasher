using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeScript : MonoBehaviour {

    public AnimationClip[] _clip;
    private Animation anim;
    private EffectManager em;
	// Use this for initialization
	void Start () {
        em = GameObject.Find("EffectManager").GetComponent<EffectManager>();
        anim = GetComponent<Animation>();

	}
	
	// Update is called once per frame
	void Update () {
        if(em.beeMode){
            StartCoroutine("startBeeAnim");
        }
		
	}

	IEnumerator startBeeAnim()
	{
		//gameObject.SetActive(true);
        anim.clip = _clip[0];
        anim.Play();
		yield return new WaitForSeconds(1f);
        anim.clip = _clip[2];
        anim.Play();
		StartCoroutine("endBeeAnim");
        em.beeMode = false;

	}

	IEnumerator endBeeAnim()
	{

		anim.clip = _clip[2];
		anim.Play();
		yield return new WaitForSeconds(5f);
		anim.clip = _clip[1];
		anim.Play();
        //anim.enabled = false;
        //gameObject.SetActive(false);
	}
}
