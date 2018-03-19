using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    public GameObject start;
    public GameObject end;
    private bool areWeActivated;

	// Use this for initialization
	void Start () {
        areWeActivated = false;
        start = GameObject.Find("endActivate");
        end = GameObject.Find("startActivate");
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x < end.transform.position.x ){
            if (gameObject.tag == "normal")
            {
                areWeActivated = true;
            }
        }

        //if(transform.position.x < end.transform.position.x && transform.position.x > start.transform.position.x){
        //    areWeActivated = false;
        //}
        //isActivated();
	}

   
}
