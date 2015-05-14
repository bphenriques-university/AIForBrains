using UnityEngine;
using System.Collections;

public class FoodCollider : MonoBehaviour {


	private Human humanState;

	// Use this for initialization
	void Start () {
		humanState = transform.root.GetComponent <Human> ();
	}


	void OnCollisionEnter (Collision other){
		
		if (other.gameObject.tag == "Food") {
			humanState.onFood = true;
		}
	}
}

