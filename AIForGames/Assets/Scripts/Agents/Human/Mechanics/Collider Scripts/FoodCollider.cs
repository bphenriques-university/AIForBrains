using UnityEngine;
using System.Collections;

public class FoodCollider : MonoBehaviour {


	private HumanState humanState;

	// Use this for initialization
	void Start () {
		humanState = transform.root.GetComponent <HumanState> ();
	}


	void OnCollisionEnter (Collision other){
		
		if (other.gameObject.tag == "Food") {
			humanState.onFood = true;
			humanState.foodSeen = other.gameObject;
		}
	}
}

