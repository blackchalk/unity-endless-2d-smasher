using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColorRandomizer : MonoBehaviour {

    public Sprite[] list_spr;
    private SpriteRenderer spr_renderer;

    private void Awake()
    {
        spr_renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start () {
        //create a random integer
        int rand = Random.Range(0,list_spr.Length-1);
        //set sprite of this GO
        gameObject.GetComponent<SpriteRenderer>().sprite = list_spr[rand];
	}

}
