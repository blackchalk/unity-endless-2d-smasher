using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;
     
public class LittleHack : MonoBehaviour
{
    DataController dc;

    private void Start()
    {
        dc = GameObject.Find("DataController").GetComponent<DataController>();
    }

    public void my_Hack()
	{

			Debug.Log("my_Hack");
			dc.SubmitNewPlayerCoins(1000);
            SceneManager.LoadScene(0);
	}
}
