using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class HumanHunger : MonoBehaviour
{
		
	public float startingHunger = 80f;
	public float hungerLossSpeed = 1.0f;
	Slider hungerSlider;

	
	private float hunger;

	private GameObject player;
	HumanHealth hoomanHealth;

	Text playerName;

	void Awake ()
	{
		hoomanHealth = GetComponent <HumanHealth> ();
		hunger = startingHunger;
		playerName = transform.Find ("HUD/PlayerName").GetComponent<Text> ();
		hungerSlider = transform.Find("HUD/Sliders/HungerSlider").GetComponent < Slider> ();
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

}


