using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PiecesDestroyer : MonoBehaviour {

    public GameObject PalayokPiecesDestructionPoint;

    // Use this for initialization
    void Start () {
        PalayokPiecesDestructionPoint = GameObject.Find("PalayokPiecesDestructionPoint");
    }
	
    // Update is called once per frame
    void Update () {
        if (transform.position.y < PalayokPiecesDestructionPoint.transform.position.y) {

            Destroy(gameObject);
        }
    }
}