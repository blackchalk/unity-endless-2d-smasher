using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("normal"))
		{
            ScoreManager.MinusHeart(1);
			//deathSound.Play();
			//gameManager.RestartGame();
			//moveSpeed = moveSpeedOrigin;
			//speedMilestoneCounts = speedMilestoneCountsOrigin;
			//speedIncreaseMilestone = speedIncreaseMilestoneOrigin;
			Debug.Log("hit");
		}
	}
}
