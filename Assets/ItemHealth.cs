using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : MonoBehaviour {

    public float max_Health;
    public float current_Health;
    public GameObject healthBar;

	// Use this for initialization
	void Start () {
        max_Health = gameObject.GetComponent<Item2>().Health;
        current_Health = max_Health;
		
	}

    public void decreaseHealth(int weaponDamage)
    {
        current_Health -= weaponDamage;
        float calc_Health = current_Health / max_Health;
        setHealthBar(calc_Health);

    }

    public void setHealthBar(float mHealth){
        healthBar.transform.localScale = new Vector3(Mathf.Clamp(mHealth, 0f, 1f),
                                               healthBar.transform.localScale.y,
                                               healthBar.transform.localScale.z);
    }

}
