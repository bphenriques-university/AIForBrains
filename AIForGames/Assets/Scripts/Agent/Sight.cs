using UnityEngine;
using System.Collections;

public class Sight : MonoBehaviour {


	void OnTriggerEnter (Collider other){
		
		EnemyHealth enemyHealth = other.GetComponent<EnemyHealth> ();
		
		if (enemyHealth != null) {
			
			Debug.Log("INIMIGO!");
			
		}
		
	}

}
