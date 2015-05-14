using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HumanAmmo : MonoBehaviour
{
	Human humanState;
	HumanShooting playerShooting;

	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
		Transform gunBarrelEnd = transform.root.FindChild ("GunBarrelEnd");
		playerShooting = gunBarrelEnd.GetComponent<HumanShooting> ();

	}

	void OnCollisionEnter (Collision other){

		if (other.gameObject.tag == "Ammo") {
			humanState.onAmmo = true;
			humanState.ammoSeen = other.gameObject.GetComponent<Ammo>();
		}
	}

	public void GrabAmmo ()
	{
		GameObject ammoObject = humanState.ammoSeen.gameObject;
		
		//Due to non-deterministic environment
		if (ammoObject == null) {
			humanState.onAmmo = false;
			humanState.sawAmmo = false;
			return;
		}
		
		
		Ammo ammo = ammoObject.GetComponent<Ammo> ();
		
		playerShooting.GrabAmmo(ammo.GrabAmmo ());
		
		humanState.onAmmo = false;
		humanState.sawAmmo = false;
	}
}


