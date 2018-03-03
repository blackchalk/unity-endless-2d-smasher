using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSettings : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //loads desired scene
    public void LoadScene(string sceneNameInBuildSettings){
        SceneManager.LoadScene(sceneNameInBuildSettings);
    }
    //hides gameobject
    public void showOrHideGO(GameObject go){
        if (go.activeSelf)
            go.SetActive(false);

        else
            go.SetActive(true);
    }
}
