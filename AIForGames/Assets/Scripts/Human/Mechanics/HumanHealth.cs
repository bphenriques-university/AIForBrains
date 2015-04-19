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
		anim = GetComponent <Animator> ();
		agentMovement = GetComponent <NavMeshAgent> ();
		agentShooting = GetComponentInChildren <HumanShooting> ();
		
		currentHealth = startingHealth;
	}
	
	
	void Update ()
	{
		damaged = false;
	}
	
	
	public void TakeDamage (int amount)
	{
		damaged = true;
		
		currentHealth -= amount;
		healthSlider.value = currentHealth;


		print (currentHealth);

		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}
	
	
	public void Death ()
	{
		isDead = true;

		GameOverManager.humansAlive--;

		agentShooting.DisableEffects ();
		
		anim.SetTrigger ("Die");
		
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