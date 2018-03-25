using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour {

    public GameObject[] weaponList;
    private DataController dc;
    private int ch;
    // Use this for initialization
	void Start () {
        dc = GameObject.Find("DataController").GetComponent<DataController>();
        ch = dc.GetPlayerEquippedWeapon();
        for (int de = 0; de < weaponList.Length;de++){
            if(ch == de){
                weaponList[de].SetActive(true);
            }else{
                weaponList[de].SetActive(false);
            }
        }
	}
	
}
