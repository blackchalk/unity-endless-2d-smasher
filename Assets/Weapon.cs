using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    //Custom enum for weapon types
    public enum WEAPON_TYPE {
        Wood = 0,
        Baseball=1,
        hammer = 2,
	    hammer2 = 3,
	    police_bat = 4,
        thor_hammer = 5,
	};
    //Weapon type
    public WEAPON_TYPE Type = WEAPON_TYPE.Wood;
    //Damage this weapon causes
    public float Damage = 0.0f;
    //Range of weapon(linear distance outwards from camera) measeured in world units
    public float Range = 1.0f;
    //Amount of ammo remaining(-1 = inifinite)
    public int Ammo = -1;
    //Recovery delay
    //Amount of time in sec before weapon can be used again
    public float RecoveryDelay = 0.0f;
    //has this weapon been collected?
    public bool Collected = false;
    //Is this weapon currently equipped on player
    public bool IsEquipped = false;
    //Can this weapon be fired
    public bool CanFire = true;
    //Next weapon in cycle
    public Weapon NextWeapon = null;
}
