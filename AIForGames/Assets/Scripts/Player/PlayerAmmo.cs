using UnityEngine;
using System.Collections;

public class PlayerAmmo : HumanAmmo {


	protected HumanShooting shooter;


	void Start() {
		shooter = GetComponentInChildren<HumanShooting> ();
	}

	void OnCollisionEnter (Collision other){

		if (other.gameObject.tag == "Ammo") {
			Ammo ammo = other.gameObject.GetComponent<Ammo> ();
			
			shooter.GrabAmmo(ammo.GrabAmmo ());
		}
	}
}
