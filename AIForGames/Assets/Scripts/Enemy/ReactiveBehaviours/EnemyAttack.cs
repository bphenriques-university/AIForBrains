using UnityEngine;
using System.Collections;

public class EnemyAttack : ReactiveBehaviour
{
	public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
	public int attackDamage = 10;               // The amount of health taken away per attack.

	Animator anim;
	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	bool playerInRange = false;
	float timer = 0;
	GameObject parent;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();

		parent = this.transform.parent.gameObject;
		enemyHealth = transform.root.gameObject.GetComponent <EnemyHealth> ();
		anim = parent.GetComponent<Animator>();
	}
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}
	

	protected override bool IsInSituation ()
	{
		bool canAttack = timer >= timeBetweenAttacks;

		return playerInRange && canAttack && enemyHealth.currentHealth > 0;
	}

	protected override void Execute ()
	{
		Attack ();

		if(playerHealth.currentHealth <= 0)
		{
			anim.SetBool ("PlayerInRange", false);
		}
	}
	
	
	private void Attack ()
	{
		timer = 0;

		if(playerHealth.currentHealth > 0)
		{
			playerHealth.TakeDamage (attackDamage);
		}
	}
}