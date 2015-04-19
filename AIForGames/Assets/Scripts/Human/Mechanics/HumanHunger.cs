using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class HumanHunger : MonoBehaviour
{
		
	public float startingHunger = 80f;
	public float hungerLossSpeed = 1.0f;
	public Slider hungerSlider;

	
	private float hunger;

	private GameObject player;
	HumanHealth hoomanHealth;

	void Awake ()
	{
		hoomanHealth = GetComponent <HumanHealth> ();
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
			if (hunger <= 0){
				//hoomanHealth.Death();
			}
			else {
				this.hunger -= hungerLossSpeed * Time.deltaTime;

				//FIXME FIXME FIXME
				if(hungerSlider != null){
					hungerSlider.value = hunger;
				}
			}
		}
	}

	public float getHungerLevel() {
		return hunger;
	}

}


