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
				//Debug.Log("Saw Food!");
				if(humanState.sawFood == true && humanState.foodSeen != null){

					if(isCloser (other.gameObject, humanState.foodSeen))
					{
						humanState.foodSeen = other.gameObject;

					}

				}else{

					humanState.sawFood = true;

					humanState.foodSeen = other.gameObject;
				}
			}else{
				humanState.sawFood = false;
			}
		}

		if (other.gameObject.tag == "Enemy") {
			if(isVisible(other)){

				//TODO: Tells you to run

			}


		}

		if (other.gameObject.tag == "Ammo") 
		{

			if(isVisible(other)){
				//Debug.Log("Saw Ammo!");
				if(humanState.sawAmmo == true && humanState.ammoSeen != null){

					if(isCloser (other.gameObject, humanState.ammoSeen))
					{
						humanState.ammoSeen = other.gameObject;
					
					}

				}else{
					
					humanState.sawAmmo = true;
			
					humanState.ammoSeen = other.gameObject;
				}
			}else{
				humanState.sawAmmo = false;
			}
		}





	}

	void OnTriggerStay(Collider other)
	{
		OnTriggerEnter (other);
	}


	void OnTriggerExit(Collider other){

		if (other.gameObject.tag == "Food") {
			//Fixme should verify is list empty
			humanState.sawFood = false;
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

	bool isCloser(GameObject a, GameObject b){

		float distance;
		Vector3 distanceVector = a.transform.position - transform.position;
		distance = distanceVector.sqrMagnitude;
		
		float currentDistance;
		Vector3 currentDistanceVector = b.transform.position - transform.position;
		currentDistance = currentDistanceVector.sqrMagnitude;

		return distance < currentDistance;
		
	}
	
}
