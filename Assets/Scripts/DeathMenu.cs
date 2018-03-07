using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public string mainSceneName;

    public virtual void Retry() {
        SceneManager.LoadScene("pokpok");
    }

    public virtual void QuitToMainMenu() {
        SceneManager.LoadScene("MAINMENU");
    }

}
