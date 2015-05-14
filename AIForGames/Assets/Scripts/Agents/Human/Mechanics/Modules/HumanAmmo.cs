using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HumanAmmo : MonoBehaviour
{
	HumanShooting playerShooting;

	void Awake(){
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


