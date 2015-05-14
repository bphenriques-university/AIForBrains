using UnityEngine;
using System.Collections.Generic;

public class Human : MonoBehaviour
{
	Collider sightCollider;

	HumanHunger hunger;
	HumanHealth health;
	HumanShooting shooting;
	HumanMovement movement;
    HumanSpeak speech;
    HumanSight sight;

    

    SightCollider sightColliderScript;

	int shootableMask;

    
	public GameObject ExitRoute;

    public HumanObjectMemory memory;
    public Actuators Actuators;
    public Sensors Sensors;

	void Awake(){
		GameOverManager.humansAlive++;


		targetPosition = transform.position;

        speech = GetComponent<HumanSpeak>();
		hunger = GetComponent<HumanHunger> ();
		health = GetComponent<HumanHealth> ();
		shooting = GetComponentInChildren<HumanShooting> ();
        movement = GetComponentInChildren<HumanMovement>();
        sight = GetComponentInChildren<HumanSight>();
		shootableMask = LayerMask.GetMask ("Shootable");
        Actuators = GetComponent<Actuators>();
        sightCollider = GetComponentInChildren<MeshCollider>();
        sightColliderScript = GetComponentInChildren<SightCollider>();
        memory = new HumanObjectMemory(sightCollider);

	}
	
	/* ------------------------------------------*/
	/* ---------- PUBLIC PROPERTIES  ------------*/
	/* ------------------------------------------*/
	
	public Transform[] randomPoints;
	public GameObject[] closeFriends;
	
	/* ------------------------------------------*/
	/* ----------       STATE        ------------*/
	/* ------------------------------------------*/

	float attackTimer;
	int lastSeenHealth;
	
	public bool targetObjectInRangeToAttack;
	public Vector3 targetPosition;
	public GameObject targetObject = null;


	public float humanTimer = 0f;

	public bool onFood = false;
	public bool bitten = false;
	public bool onAmmo = false;

	
	void Update(){
		humanTimer += Time.deltaTime;
		attackTimer += Time.deltaTime;
		memory.CleanWrongMemories ();

        sight.ProcessSight(sightColliderScript.SeenGameObjects);
	}

	

	/* ------------------------------------------*/
	/* ----------------- Sensors  ---------------*/
	/* ------------------------------------------*/
	
	public bool IsSeeingFood(){
		return sight.FoodsSeen.Count > 0;
	}

	public bool IsOnFood(){
		return onFood;
	}

	public bool IsOnAmmo ()
	{
		return onAmmo;
	}

	public bool IsSeeingZombie(){
		return sight.ZombiesSeen.Count > 0;
	}

	public bool IsSeeingHumanInDanger(){
		return sight.HumansSeen.Count > 0;
	}

	public bool IsGrabbed(){
		return movement.isBeingGrabbed();
	}
	
	public bool IsBitten() {
		return bitten;
	}

	public bool isMoving() {
		return movement.isMoving ();
	}

	public bool isRunning(){

		return isMoving () && movement.isRunning ();
	}

	public bool IsSeeingAmmo(){
		return sight.AmmoSeen.Count > 0;
	}

	public int FoodCarried () {
		return hunger.GetFoodCarried ();
	}

	public float HungerLevel() {
		return hunger.GetHungerLevel ();
	}

    public float AmmoLevel()
    {
        return shooting.currentAmmo;
    }

    public IList<Food> FoodsCarried()
    {
        return hunger.foods;
    }

	public bool IsSeeingExitRoute(){
		return sight.ExitSeen;
	}

	public int HealthLevel() {
		return health.getHealthLevel ();
	}
	
	public bool DidArrivedAtTargetPosition(){
		return Vector3.Distance (transform.position, targetPosition) < 1;
	}

	public bool WasAttacked(){
		if (lastSeenHealth > health.currentHealth) {
			lastSeenHealth = health.currentHealth;
			return true;
		} else {
			return false;
		}
	}

	public bool CanShoot() {
		return shooting.CanAttack ();
	}

	public float getSpeed(){
		return movement.getSpeed ();
	}



	public bool IsAimingToZombie(GameObject zombieSeen) {
		// TO REIMPLEMENTED IN NEAR FUTURE
		Ray shootRay = new Ray ();
		RaycastHit shootHit;
		float range = 100f;

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;


		
		// Perform the raycast against gameobjects on the shootable layer and if it hits something...
		if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
			if (shootHit.collider.gameObject == zombieSeen) {
				EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
				
				// If the EnemyHealth component exist...
				return enemyHealth != null;
			}
		}
		return  false;
	}

    public Transform CurrentPosition()
    {
        return transform.root;
    }


	public float getHumanTime(){
		return humanTimer;
	}
	
	public IList<Human> getFriendship()
	{
 	throw new System.NotImplementedException();
	}

}