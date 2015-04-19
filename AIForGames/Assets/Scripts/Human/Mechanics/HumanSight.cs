using UnityEngine;
using System.Collections;

public class HumanSight : MonoBehaviour {

	Ray shootRay;
	RaycastHit shootHit;
	float range = 20f;
	int shootableMask;

	HumanState humanState;
	
	void Awake(){
		shootableMask = LayerMask.GetMask ("Shootable");
		humanState = transform.root.GetComponent <HumanState> ();
	}



	void OnTriggerEnter (Collider other){



		if (other.gameObject.tag == "Food") {

			if(isVisible (other)){
				humanState.sawFood = true;
				//Fixme shoul add to list
				humanState.foodSeen = other.gameObject;

			}





		}

		if (other.gameObject.tag == "Enemy") {
			if(isVisible(other)){

				//TODO: Tells you to run

			}
		}





	}

	bool isVisible (Collider other)
	{
		Vector3 direction = other.transform.position - transform.position;
		if (Physics.Raycast (transform.position, direction.normalized, out shootHit, range, shootableMask)) {
			//Debug.Log ("VI: Daqui: " + shootRay.origin + "para ali: " + other.transform.position + "vendo um " + shootHit.collider.gameObject);
			if (shootHit.collider.gameObject.Equals (other.gameObject)) {
				//Debug.Log ("VI MESMO um " + shootHit.collider.gameObject);
				return true;
			}
		}

		return false;
	}

	//TODO: OnStay, se ficar mas a comida nao for visivel ele esquece-se

	void OnTriggerExit(Collider other){

		if (other.gameObject.tag == "Food") {
			//Fixme should verify is list empty
			humanState.sawFood = false;
		}


	
	}

}
