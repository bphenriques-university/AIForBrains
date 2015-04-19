using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HumanShooting : MonoBehaviour
{
	public int damagePerShot = 20;                  // The damage inflicted by each bullet.
	public float timeBetweenBullets = 0.15f;        // The time between each shot.
	public float range = 100f;                      // The distance the gun can fire.
	public float rangeShootingSound = 10;
	public int currentAmmo = 10;

	float timer;                                    // A timer to determine when to fire.
	Ray shootRay;                                   // A ray from the gun end forwards.
	RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
	int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
	ParticleSystem gunParticles;                    // Reference to the particle system.
	LineRenderer gunLine;                           // Reference to the line renderer.
	AudioSource gunAudio;                           // Reference to the audio source.
	Light gunLight;                                 // Reference to the light component.
	float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.
	Text ammoText;
	int AbleToHearLayer = 10;
	List<EnemyHearing> enemysAbleToHear = new List<EnemyHearing> ();
	
	public void addEnemyAbleToHear(EnemyHearing enemyScript) {
		enemysAbleToHear.Add (enemyScript);
	}
	
	public void removeEnemyAbleToHear(EnemyHearing enemyScript) {
		enemysAbleToHear.Remove (enemyScript);
	}
	
	void Awake ()
	{
		// Create a layer mask for the Shootable layer.
		shootableMask = LayerMask.GetMask ("Shootable");
		// Set up the references.
		gunParticles = GetComponent<ParticleSystem> ();
		gunLine = GetComponent <LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		gunLight = GetComponent<Light> ();

		foreach (Text c in GetComponentsInChildren<Text>()) {
			if(c.name == "AmmoText"){
				ammoText = c;
				break;
			}
		}

	}
	
	void Update ()
	{
		timer += Time.deltaTime;


		if(this.transform.root.gameObject.tag == "Player" && Input.GetButton ("Fire1") && timer >= timeBetweenBullets)
		{
			if(currentAmmo > 0)
				Shoot ();
		}

		if(timer >= timeBetweenBullets * effectsDisplayTime)
		{
			DisableEffects ();
		}

	}

	public void DisableEffects ()
	{
		// Disable the line renderer and the light.
		gunLine.enabled = false;
		gunLight.enabled = false;
	}

	
	public bool CanAttack(){
		return currentAmmo > 0 && timer >= timeBetweenBullets;
	}
	
	public void Shoot ()
	{
		// Reset the timer.
		timer = 0f;

		currentAmmo--;
		transform.root.Find ("HUD/AmmoText").GetComponent<Text> ().text = currentAmmo + " Bullets";

		// Play the gun shot audioclip.
		gunAudio.Play ();
		
		// Enable the light.
		gunLight.enabled = true;
		
		// Stop the particles from playing if they were, then start the particles.
		gunParticles.Stop ();
		gunParticles.Play ();
		
		
		
		foreach (EnemyHearing enemy in enemysAbleToHear )
		{
			enemy.HeardShot(transform);
		}
		
		// Enable the line renderer and set it's first position to be the end of the gun.
		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);
		
		// Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;
		
		// Perform the raycast against gameobjects on the shootable layer and if it hits something...
		if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
		{
			// Try and find an EnemyHealth script on the gameobject hit.
			EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
			
			// If the EnemyHealth component exist...
			if(enemyHealth != null)
			{
				// ... the enemy should take damage.
				enemyHealth.TakeDamage (damagePerShot, shootHit.point);
			}
			
			// Set the second position of the line renderer to the point the raycast hit.
			gunLine.SetPosition (1, shootHit.point);
		}
		// If the raycast didn't hit anything on the shootable layer...
		else
		{
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}
	}
}