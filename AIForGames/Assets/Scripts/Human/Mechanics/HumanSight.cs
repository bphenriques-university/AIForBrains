using UnityEngine;
using System.Collections;

public class HumanSight : MonoBehaviour {



	HumanState humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
	}



	void OnTriggerEnter (Collider other){
		

		if (other.gameObject.tag == "Enemy") {
			//adicionar a uma lista de inimigos?
			//humanState.addEnemy(other.gameObject);
		}
		
		if (other.gameObject.tag == "Food") {
			Debug.Log("SeeingFOOD!");
			humanState.sawFood = true;
			//Fixme shoul add to list
			humanState.foodSeen = other.gameObject;
		}

	}

	void OnTriggerExit(Collider other){

		if (other.gameObject.tag == "Food") {
			//Fixme should verify is list empty
			humanState.sawFood = false;
		}

	
	}

}
