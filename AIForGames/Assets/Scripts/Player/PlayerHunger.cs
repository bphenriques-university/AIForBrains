using UnityEngine;
using System.Collections;

public class PlayerHunger : HumanHunger {


	
	void OnCollisionEnter (Collision other){
		
		if (other.gameObject.tag == "Food") {
			Food food = other.gameObject.GetComponent<Food>();
			food = food.catchFood();
			hunger+= food.foodPoints;
		}
	}
}
