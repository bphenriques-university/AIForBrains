using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class HumanHunger : MonoBehaviour
{
		
	public float startingHunger = 80f;
	public float hungerLossSpeed = 1.0f;
	public Slider hungerSlider;
	public Text playerName;

	
	private float hunger;
	HumanState humanState;

	private GameObject player;
	HumanHealth hoomanHealth;


	void Awake ()
	{
		humanState = transform.root.GetComponent <HumanState> ();
		hoomanHealth = GetComponent <HumanHealth> ();
		hunger = startingHunger;
	}

	void OnCollisionEnter (Collision other){

		if (other.gameObject.tag == "Food") {
			humanState.onFood = true;
			humanState.foodSeen = other.gameObject;
		}
	}
	/*
	 * 
	 Food food = other.collider.GetComponent<Food> ();

		if (food != null) {
			hunger += food.eat ();
		}
	 */

	void Update()
	{
		if (!hoomanHealth.isHumanDead()){
			if (hunger <= 0){
				playerName.color = Color.green;	
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

	public void addFood(float foodIncrease)
	{
		hunger += foodIncrease;
	}

}


