using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D col)
	{
        //if (col.gameObject.CompareTag("normal"))
        //{
        //          ScoreManager.MinusHeart(1);
        //	//deathSound.Play();
        //	//gameManager.RestartGame();
        //	//moveSpeed = moveSpeedOrigin;
        //	//speedMilestoneCounts = speedMilestoneCountsOrigin;
        //	//speedIncreaseMilestone = speedIncreaseMilestoneOrigin;
        //	Debug.Log("hit");
        //}

        Debug.Log("hit"+col);
            //ScoreManager.MinusHeart(1);

	}
}