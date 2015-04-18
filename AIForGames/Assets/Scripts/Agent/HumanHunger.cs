using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class HumanHunger : MonoBehaviour
{
		
	public float startingHunger = 80f;
	private float hunger;
	public float hungerLossSpeed = 1.0f;
	public Slider hungerSlider;

	private GameObject player;
	HumanHealth hoomanHealth;

	void Awake ()
	{
		// Setting up the references.
		hoomanHealth = GetComponent <HumanHealth> ();
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
		if (!hoomanHealth.isHumanDead()){
			if (hunger <= 0)
				hoomanHealth.Death();
			else {
				this.hunger -= hungerLossSpeed * Time.deltaTime;
				hungerSlider.value = hunger;
				//print (hunger);
			}
		}
	}

}


