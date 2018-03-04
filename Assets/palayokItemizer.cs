using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palayokItemizer : MonoBehaviour {

    public List<GameObject> listOfChildGO;
    public List<Sprite> spr = new List<Sprite>();

    private void Awake()
    {
        //Transform[] allChildren = game();
        foreach (Transform child in gameObject.transform)
		{
            listOfChildGO.Add(child.gameObject);
		}

        foreach(GameObject go in listOfChildGO){
            int i = Random.Range(0,listOfChildGO.Count);

            switch(i){
                case 0 : go.gameObject.tag = "normal";
                         go.gameObject.GetComponent<Item>().score = 1;
                
                    break;
				case 1:
					go.gameObject.tag = "bomb";
					break;
				case 2:
					go.gameObject.tag = "star";
					break;
				case 3:
					go.gameObject.tag = "ice";
					break;
				case 4:
					go.gameObject.tag = "life";
					break;
				case 5:
					go.gameObject.tag = "beehive";
					break;
				case 6:
					go.gameObject.tag = "2x";
                    go.AddComponent<PowerUp2>();
                    PowerUp2 pu = go.GetComponent<PowerUp2>();
                    pu.powerUpLength = 10;
					break;
				case 7:
					go.gameObject.tag = "2x";
					go.AddComponent<PowerUp2>();
					PowerUp2 pu2 = go.GetComponent<PowerUp2>();
					pu2.powerUpLength = 10;
					break;
                default : //do nothing
                    go.gameObject.tag = "skull";
                    break;
            }

            go.GetComponent<SpriteRenderer>().sprite = spr[i];

        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
