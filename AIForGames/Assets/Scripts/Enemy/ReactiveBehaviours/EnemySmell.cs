using System;
using UnityEngine;
using System.Collections;

public class EnemySmell : ReactiveBehaviour
{

	GameObject player;               // Reference to the player's position.
	PlayerHealth playerHealth;      // Reference to the player's health.
	EnemyHealth enemyHealth;        // Reference to this enemy's health.
	NavMeshAgent nav;               // Reference to the nav mesh agent.
	bool playerInRange;
	GameObject parent;
	Animator anim;
	void Awake ()
	{
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();

		parent = this.transform.parent.gameObject;
		enemyHealth = parent.GetComponent <EnemyHealth> ();
		nav = parent.GetComponent <NavMeshAgent> ();
		anim = parent.GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter (Collider other)
	{
		//print ("********************************* IN RANGE FOR SMELL");
		if(other.gameObject == player)
		{
			//print ("***Updating playerInRange to true");
			playerInRange = true;
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		//print ("********************************* OUT OF RANGE FOR SMELL");
		if(other.gameObject == player)
		{
			//print ("***Updating playerInRange to false");
			playerInRange = false;
		}
	}

	protected override void Execute(){
		//print ("EXECUTING SMELL ACTION");
		if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		{
			nav.SetDestination (player.transform.position);
			anim.SetBool ("PlayerInRange", true);
		}
		else
		{
			nav.enabled = false;
		}
	}

	protected override bool IsInSituation(){
		return playerInRange;
	}
}