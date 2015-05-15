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

	public void AddAmmo(int number){
		playerShooting.GrabAmmo (number);
	}

	public bool TakeAmmo(int number){
		if (playerShooting.currentAmmo >= number) {

			playerShooting.DecrementBullets (number);
			return true;
		}
		return false;
	}
}


