using UnityEngine;
using System.Collections;

public class AmmoHandler : MonoBehaviour
{
	PlayerShooting playerShotting;

	void Awake(){
		playerShotting = this.transform.FindChild("GunBarrelEnd").GetComponent<PlayerShooting> ();
	}

	void OnCollisionEnter (Collision other){
		
		Ammo ammo = other.collider.GetComponent<Ammo> ();
		
		if (ammo != null) {
			print ("@@ " + playerShotting.currentAmmo);
			print("Adding " + ammo.GrabAmmo() + " ammo.");
			playerShotting.currentAmmo += ammo.GrabAmmo ();
			print ("@@ " + playerShotting.currentAmmo);
		}
	}
}


