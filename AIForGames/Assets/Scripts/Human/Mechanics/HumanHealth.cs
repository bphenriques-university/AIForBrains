using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HumanHealth : MonoBehaviour
{
	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public AudioSource hitSound;
	public AudioSource deadSound;


	Animator anim;                                              // Reference to the Animator component.
	NavMeshAgent agentMovement;                              // Reference to the player's movement.
	HumanShooting agentShooting;                              // Reference to the PlayerShooting script.
	Slider healthSlider;                                 // Reference to the UI's health bar.
	bool isDead = false;                                                // Whether the player is dead.
	bool damaged;


	Text playerName;

	void Awake ()
	{
		anim = GetComponent <Animator> ();
		agentMovement = GetComponent <NavMeshAgent> ();
		agentShooting = GetComponentInChildren <HumanShooting> ();
		currentHealth = startingHealth;

		healthSlider = transform.Find("HUD/Sliders/HealthSlider").GetComponent < Slider> ();
		playerName = transform.Find ("HUD/PlayerName").GetComponent<Text> ();
	}
	
	
	void Update ()
	{
		playerName.color = Color.white;	

		damaged = false;
	}
	
	
	public void TakeDamage (int amount)
	{
		if (isDead)
			return;

		playerName.color = Color.red;	

		damaged = true;

		currentHealth -= amount;

		hitSound.Play ();

		//FIXME FIXME FIXME
		if (healthSlider != null) {
			healthSlider.value = currentHealth;
			healthSlider.enabled = false;
		}

		if(currentHealth <= 0)
		{
			Death ();
		}

	}
	
	
	public void Death ()
	{
		isDead = true;

		deadSound.Play ();

		GameOverManager.humansAlive--;

		agentShooting.DisableEffects ();
		
		anim.SetTrigger ("Die");


		//Disable scripts
		PlayerMovement playerMovement = GetComponent<PlayerMovement> ();
		if (playerMovement != null) {
			playerMovement.enabled = false;
		}

		agentMovement.enabled = false;
		agentShooting.enabled = false;

		transform.FindChild ("ReactiveBehaviourManager").GetComponent<ReactiveBehaviourManager> ().enabled = false;

		enabled = false;
	}
	
	public bool isHumanDead(){
		return isDead;
	}

	public int getHealthLevel() {
		return currentHealth;
	}
}