using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformGeneratorStartPoint;

    public PlayerController playerController;
    private Vector3 playerStartPoint;

    private ObjectDestroyer[] objectDestroyers;
    private ScoreManager scoreManager;
    public DeathMenu deathMenu;
    //private PowerUpManager powerUpManager;
    private EffectManager powerUpManager;
    //private DataController dataController;

    // Use this for initialization
    void Start () {
        platformGeneratorStartPoint = platformGenerator.position;
        playerStartPoint = playerController.transform.position;
        powerUpManager = FindObjectOfType<EffectManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        //dataController = FindObjectOfType<DataController>();
    }

    public void RestartGame() {

        scoreManager.scoreIncreasing = false;
        playerController.gameObject.SetActive(false);
        deathMenu.gameObject.SetActive(true);
    }

    public void ResetGame() {
        powerUpManager.InActivePowerUpMode();
        deathMenu.gameObject.SetActive(false);
        objectDestroyers = FindObjectsOfType<ObjectDestroyer>();
        for (int i = 0; i < objectDestroyers.Length; i++) {
            objectDestroyers[i].gameObject.SetActive(false);
        }

        playerController.transform.position = playerStartPoint;
        platformGenerator.position = platformGeneratorStartPoint;
        playerController.gameObject.SetActive(true);

        scoreManager.scoreCounts = 0;
        scoreManager.scoreIncreasing = true;
    }

    //private IEnumerator submit(){

    //    //submit collected coins
    //    int x = (int)scoreManager.scoreCounts;
    //    dataController.SubmitNewPlayerCoins(x);

    //    yield return new WaitForSeconds(0.1f);
    //}

}