using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HumanHealth : MonoBehaviour
{
	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public Slider healthSlider;                                 // Reference to the UI's health bar.
	public AudioSource hitSound;
	public AudioSource deadSound;


	Animator anim;                                              // Reference to the Animator component.
	NavMeshAgent agentMovement;                              // Reference to the player's movement.
	HumanShooting agentShooting;                              // Reference to the PlayerShooting script.
	bool isDead = false;                                                // Whether the player is dead.
	bool damaged;
	
	void Awake ()
	{
		anim = GetComponent <Animator> ();
		agentMovement = GetComponent <NavMeshAgent> ();
		agentShooting = GetComponentInChildren <HumanShooting> ();
		hitSound = GetComponent<AudioSource> ();
		currentHealth = startingHealth;
	}
	
	
	void Update ()
	{
		damaged = false;
	}
	
	
	public void TakeDamage (int amount)
	{
		if (isDead)
			return;


		damaged = true;
		currentHealth -= amount;

		hitSound.Play ();

		//FIXME FIXME FIXME
		if (healthSlider != null) {
			healthSlider.value = currentHealth;
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