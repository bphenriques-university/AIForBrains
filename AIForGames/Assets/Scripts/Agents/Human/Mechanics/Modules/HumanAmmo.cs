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

	public void GrabAmmo (Ammo ammo)
	{
		
		//Due to non-deterministic environment
		if (!ammo.gameObject) {
			return;
		}
		
		
		playerShooting.GrabAmmo(ammo.GrabAmmo ());
		
	}
}


