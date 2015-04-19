using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LifeHungerBarHandler : MonoBehaviour
{
	private static string HUNGER_TEXT = "(S)";
	private static string DEATH_TEXT = "(D)";

	Slider lifeSlideR;
	Slider hungerSlideR;
	Text name;

	void Awake(){
		name = transform.Find ("PlayerName").GetComponent<Text> ();
		lifeSlideR = transform.Find("Sliders").Find ("HealthSlider").GetComponent<Slider> ();
		hungerSlideR = transform.Find("Sliders").Find ("HungerSlider").GetComponent<Slider> ();
	}

	void Update(){
		if (lifeSlideR.value <= 0) {
			name.text += " " + DEATH_TEXT;
			enabled = false;
		}

		if (hungerSlideR.value <= 0) {
			name.text += " " + HUNGER_TEXT;
		}else{
			if(name.text.Contains(HUNGER_TEXT))
				name.text.Remove(name.text.IndexOf('('));
		}
	}
}