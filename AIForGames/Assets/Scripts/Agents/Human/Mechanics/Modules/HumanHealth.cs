using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HumanHealth : MonoBehaviour
{
	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public AudioSource hitSound;
	public AudioSource deadSound;
	public Slider healthSlider;                                 // Reference to the UI's health bar.

	public Text playerName;

	Animator anim;                                              // Reference to the Animator component.
	NavMeshAgent agentMovement;                              // Reference to the player's movement.
	HumanShooting agentShooting;                              // Reference to the PlayerShooting script.
	Collider agentCollider;
	bool isDead = false;                                                // Whether the player is dead.
	bool damaged;

	Color previousColor;

	void Awake ()
	{
		anim = GetComponent <Animator> ();
		agentMovement = GetComponent <NavMeshAgent> ();
		agentShooting = GetComponentInChildren <HumanShooting> ();
		agentCollider = GetComponent<CapsuleCollider> ();
		currentHealth = startingHealth;
	}
	
	
	void Update ()
	{
		
		if(damaged)
			playerName.color = previousColor;	

		damaged = false;
	}
	
	public bool IsBeingAttacked(){
		return damaged;
	}

	public void TakeDamage (int amount)
	{
		if (isDead)
			return;

		previousColor = playerName.color;
		playerName.color = Color.red;


		damaged = true;

		currentHealth -= amount;

		hitSound.Play ();

		healthSlider.value = currentHealth;
		healthSlider.enabled = false;

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
		agentCollider.isTrigger = true;

		//Disable script

		agentMovement.enabled = false;
		agentShooting.enabled = false;
		
		PlayerMovement playerMovement = GetComponent<PlayerMovement> ();
		if (playerMovement != null) {
			playerMovement.enabled = false;
		}

		transform.FindChild ("AI").gameObject.SetActive(false);

		enabled = false;
	}
	
	public bool isHumanDead(){
		return isDead;
	}

	public int getHealthLevel() {
		return currentHealth;
	}

	public int getMaxHealthLevel ()
	{
		return startingHealth;
	}
}