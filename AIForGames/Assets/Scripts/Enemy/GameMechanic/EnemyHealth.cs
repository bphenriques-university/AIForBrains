using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;            // The amount of health the enemy starts the game with.
	public int currentHealth;                   // The current health the enemy has.
	public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
	public AudioClip deathClip;                 // The sound to play when the enemy dies.
	
	
	Animator anim;                              // Reference to the animator.
	AudioSource enemyAudio;                     // Reference to the audio source.
	ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
	bool isDead;                                // Whether the enemy is dead.
	bool isSinking;                             // Whether the enemy has started sinking through the floor.
	
	
	void Awake ()
	{
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
		hitParticles = GetComponentInChildren <ParticleSystem> ();
		
		currentHealth = startingHealth;
	}
	
	
	public void TakeDamage (int amount, Vector3 hitPoint)
	{
		if(isDead)
			return;
		
		enemyAudio.Play ();
		
		currentHealth -= amount;
		
		hitParticles.transform.position = hitPoint;
		
		hitParticles.Play();
		
		if(currentHealth <= 0)
		{
			Death ();
		}
	}
	
	
	void Death ()
	{

		GameOverManager.zombiesAlive--;

		GetComponent <NavMeshAgent> ().enabled = false;

		GetComponent<ZombieState> ().Leave ();


		foreach( Transform child in transform )
		{
			if(child.gameObject.name == "ReactiveBehaviourManager")
				child.gameObject.SetActive( false );
		}

		isDead = true;
		
		anim.SetTrigger ("Dead");
		
		enemyAudio.clip = deathClip;
		enemyAudio.Play ();
	}
}