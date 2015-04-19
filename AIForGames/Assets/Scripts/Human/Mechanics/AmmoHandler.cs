using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoHandler : MonoBehaviour
{
	HumanState humanState;

	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();

	}

	void OnCollisionEnter (Collision other){

		if (other.gameObject.tag == "Ammo") {
			humanState.onAmmo = true;
			humanState.ammoSeen = other.gameObject;
		}
	}
}


