using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalayokGenerator : MonoBehaviour {
    
    public Transform platformGenerationPoint;
    private float platformWidth;

    public float distanceBetweenPlatform;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;

    public float maxHeightChange;
    private float heightChange;

    public GameObject[] PalayokObjects;
	public float[] palayokWidths;
    private int palayokSelector;

	// Use this for initialization
	void Start() {

        palayokWidths = new float[PalayokObjects.Length];
		for (int i = 0; i < PalayokObjects.Length; i++) {
		    palayokWidths[i] = PalayokObjects[i].GetComponent<BoxCollider2D>().size.x;
		}

		minHeight = transform.position.y; // same as PlatformGenerator's Height
        maxHeight = maxHeightPoint.position.y;

    }

    // Update is called once per frame
    void Update() {
        if (transform.position.x < platformGenerationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + distanceBetweenPlatform,
                                             transform.position.y,
                                             transform.position.z);

            heightChange = transform.position.y + Random.Range(-maxHeightChange, maxHeightChange);
            if (heightChange > maxHeight) {
                heightChange = maxHeight;
            } else if (heightChange < minHeight) {
                heightChange = minHeight;
            }

            GameObject newPowerUp = GeneratePalayok();
            //newPowerUp.transform.position = transform.position + new Vector3((palayokWidths[palayokSelector] /2) + (distanceBetweenPlatform / 2),
            //transform.position.y + 2f, 0f);
            newPowerUp.transform.position = transform.position;
            newPowerUp.transform.rotation = transform.rotation;
            newPowerUp.SetActive(true);

            // Adjust the gap's size. move the platform generator to end of platform.
            transform.position = new Vector3(transform.position.x + (palayokWidths[palayokSelector] / 1.8f), heightChange, transform.position.z);
        }
    }

    GameObject GeneratePalayok(){
        int i = Random.Range(0, PalayokObjects.Length);
        this.palayokSelector = i;
        GameObject gameObject = (GameObject)Instantiate(PalayokObjects[i]);
		gameObject.SetActive(true);
        //pooledObjects.Add(gameObject);
        return gameObject;
    }
}
