using UnityEngine;
using UnityEngine.UI;
using System.Collections;


	public class HumanHunger : MonoBehaviour
	{
		
	public float startingHunger = 80f;
	private float hunger;
	public float hungerLossSpeed = 1.0f;

	private GameObject player;
	PlayerHealth playerHealth;

	void Awake ()
	{
		// Setting up the references.
		playerHealth = GetComponent <PlayerHealth> ();
		// Set the initial hunger of the player.
		hunger = startingHunger;
	}

	void OnCollisionEnter (Collision other){
	
		Food food = other.collider.GetComponent<Food> ();

		if (food != null) {

			hunger += food.eat ();

		}

	}

	void Update()
	{
		if (!playerHealth.isHumanDead()){
			if (hunger <= 0)
				playerHealth.Death();
			else {
				this.hunger -= hungerLossSpeed * Time.deltaTime;
			
				//print (hunger);
			}
		}
	}
	

		public HumanHunger ()
		{
		}
	}


