using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    public bool isPaused = false;
    private Vector3 platformGeneratorStartPoint;
    public GameObject pauseButton;

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
        isPaused = true;
        //scoreManager.scoreIncreasing = false;
        playerController.gameObject.SetActive(false);
        deathMenu.gameObject.SetActive(true);

        pauseButton.SetActive(false);
    }

    public void ResetGame() {
        isPaused = false;
        pauseButton.SetActive(true);
        powerUpManager.InActivePowerUpMode();
        deathMenu.gameObject.SetActive(false);
        objectDestroyers = FindObjectsOfType<ObjectDestroyer>();
        for (int i = 0; i < objectDestroyers.Length; i++) {
            objectDestroyers[i].gameObject.SetActive(false);
        }

        playerController.transform.position = playerStartPoint;
        platformGenerator.position = platformGeneratorStartPoint;
        playerController.gameObject.SetActive(true);
        isPaused = false;
        scoreManager.scoreCounts = 0;
        //scoreManager.scoreIncreasing = true;
    }

}