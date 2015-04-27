using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class HumanHunger : MonoBehaviour
{
		
	public float startingHunger = 80f;
	public float hungerLossSpeed = 1.0f;
	public Slider hungerSlider;
	public Text playerName;
	public Text numberFood;
	
	protected float hunger;
	protected HumanState humanState;

	protected GameObject player;
	protected HumanHealth hoomanHealth;

	protected List<Food> foods = new List<Food>();



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
				hoomanHealth.Death();
			}
			else {
				this.hungerLossSpeed = humanState.getSpeed() / 2;
				this.hunger -= hungerLossSpeed * Time.deltaTime;

				//FIXME FIXME FIXME
				if(hungerSlider != null){
					hungerSlider.value = hunger;
				}
			}
		}
	}

	public float GetHungerLevel() {
		return hunger;
	}

	public void AddFood(Food food)
	{
		foods.Add (food);
		numberFood.text = "( " + foods.Count + " )";
	}

	public void EatFood()
	{
		if (!HasFood ())
			return;

		Food largestFood = foods[0];
		foreach (Food food in foods) {
			if(food.foodPoints > largestFood.foodPoints)
				largestFood = food;
		}

		hunger += largestFood.foodPoints;
		foods.Remove (largestFood);
	}

	public bool HasFood(){
		return foods.Count > 0;
	}

	public int GetFoodCarried(){
		return foods.Count;
	}

}


