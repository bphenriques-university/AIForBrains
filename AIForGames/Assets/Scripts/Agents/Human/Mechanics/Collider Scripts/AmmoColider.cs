using UnityEngine;
using System.Collections;

public class AmmoColider : MonoBehaviour
{

	private HumanState humanState;
	
	// Use this for initialization
	void Start () {
		humanState = transform.root.GetComponent <HumanState> ();
	}
	
	void OnCollisionEnter (Collision other){
		
		if (other.gameObject.tag == "Ammo") {
			humanState.onAmmo = true;
			humanState.ammoSeen = other.gameObject.GetComponent<Ammo>();
		}
	}
}

