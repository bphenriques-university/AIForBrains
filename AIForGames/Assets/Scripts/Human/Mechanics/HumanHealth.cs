using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HumanHealth : MonoBehaviour
{
	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public Slider healthSlider;                                 // Reference to the UI's health bar.
	
	Animator anim;                                              // Reference to the Animator component.
	NavMeshAgent agentMovement;                              // Reference to the player's movement.
	HumanShooting agentShooting;                              // Reference to the PlayerShooting script.
	bool isDead = false;                                                // Whether the player is dead.
	bool damaged;                                               // True when the player gets damaged.
	
	
	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent <Animator> ();
		agentMovement = GetComponent <NavMeshAgent> ();
		agentShooting = GetComponentInChildren <HumanShooting> ();
		
		// Set the initial health of the player.
		currentHealth = startingHealth;
	}
	
	
	void Update ()
	{
		
		// Reset the damaged flag.
		damaged = false;
	}
	
	
	public void TakeDamage (int amount)
	{
		// Set the damaged flag so the screen will flash.
		damaged = true;
		
		// Reduce the current health by the damage amount.
		currentHealth -= amount;
		
		// Set the health bar's value to the current health.
		healthSlider.value = currentHealth;

		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 0 && !isDead)
		{
			// ... it should die.
			Death ();
		}
	}
	
	
	public void Death ()
	{
		// Set the death flag so this function won't be called again.
		isDead = true;
		
		// Turn off any remaining shooting effects.
		agentShooting.DisableEffects ();
		
		// Tell the animator that the player is dead.
		anim.SetTrigger ("Die");
		
		// Turn off the movement and shooting scripts.
		agentMovement.enabled = false;
		agentShooting.enabled = false;
	}
	
	public bool isHumanDead(){
		return isDead;
	}

	public int getHealthLevel() {
		return currentHealth;
	}
}