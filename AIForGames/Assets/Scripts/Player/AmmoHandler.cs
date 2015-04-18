using UnityEngine;
using System.Collections;

public class AmmoHandler : MonoBehaviour
{
	PlayerShooting playerShotting;

	void Awake(){
		playerShotting = GetComponent<PlayerShooting> ();
	}

	void OnCollisionEnter (Collision other){
		
		Ammo ammo = other.collider.GetComponent<Ammo> ();
		
		if (ammo != null) {
			print("Adding " + ammo.GrabAmmo());
			playerShotting.currentAmmo += ammo.GrabAmmo ();
		}
	}
}


