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
            int i = Random.Range(0,6);

            switch(i){
                case 0 : go.gameObject.tag = "object";
                    break;
				case 1:
					go.gameObject.tag = "KillBox";
					break;
				case 2:
					go.gameObject.tag = "star";
					break;
				case 3:
					go.gameObject.tag = "ice";
					break;
                default : //do nothing
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
