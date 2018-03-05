using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    public GameObject platformDescructionPoint;

    // Use this for initialization
    void Start () {
        platformDescructionPoint = GameObject.Find("PlatformDescructionPoint");
    }
	
    // Update is called once per frame
    void Update () {
        if (transform.position.x < platformDescructionPoint.transform.position.x) {
            //if this is normal pot minus heart
            if(gameObject.tag == "normal"){
                ScoreManager.MinusHeart(1);
            }
            //StartCoroutine(gameObject.GetComponent<Item>().restartStatus());
			//gameObject.SetActive(false);
            Destroy(gameObject);// will get null reference. seems game is reusing this over and over
        }
    }
}