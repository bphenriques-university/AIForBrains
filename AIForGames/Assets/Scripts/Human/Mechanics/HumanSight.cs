using UnityEngine;
using System.Collections;

public class HumanSight : MonoBehaviour {

	void OnTriggerEnter (Collider other){
		
		EnemyHealth enemyHealth = other.GetComponent<EnemyHealth> ();
		
		if (enemyHealth != null) {
			//Debug.Log("INIMIGO!");
		}
		
	}

}
