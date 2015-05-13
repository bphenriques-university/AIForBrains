using UnityEngine;
using System.Collections.Generic;

public class HumanState : MonoBehaviour
{
	HumanHunger hunger;
	HumanHealth health;
	HumanShooting shooting;
	HumanMovement movement;
    HumanSpeak speech;
	int shootableMask;

	public GameObject ExitRoute;

	public Actuator actuator;

	void Awake(){
		GameOverManager.humansAlive++;
		
		targetPosition = transform.position;

        speech = GetComponent<HumanSpeak>();
		hunger = GetComponent<HumanHunger> ();
		health = GetComponent<HumanHealth> ();
		shooting = GetComponentInChildren<HumanShooting> ();
		movement = GetComponentInChildren<HumanMovement> ();
		shootableMask = LayerMask.GetMask ("Shootable");
		actuator = GetComponent<Actuator> ();

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
	public GameObject targetObject;
	public GameObject foodSeen;
	public Ammo ammoSeen;
	public GameObject zombieSeen;
	public GameObject exitSeen;


	public float humanTimer = 0f;

	public bool sawFood = false;
	public bool onFood = false;
	public bool sawZombie = false;
	public bool sawHumanInDanger = false;
	public bool bitten = false;
	public bool sawAmmo = false;
	public bool onAmmo = false;
	public bool sawExitDoor = false;

	
	void Update(){
		humanTimer += Time.deltaTime;
		attackTimer += Time.deltaTime;
	}

	
	/* ------------------------------------------*/
	/* ----------------- Sensors  ---------------*/
	/* ------------------------------------------*/
	
	public bool IsSeeingFood(){
		return sawFood;
	}

	public bool IsOnFood(){
		return onFood;
	}

	public bool IsOnAmmo ()
	{
		return onAmmo;
	}

	public bool IsSeeingZombie(){
		return sawZombie && zombieSeen.GetComponent<EnemyHealth> ().currentHealth > 0;
	}

	public bool IsSeeingHumanInDanger(){
		return sawHumanInDanger;
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
		return sawAmmo;
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
		return sawExitDoor;
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

	public float getDistanceToZombie(){
		Vector3 distanceVector = zombieSeen.transform.position - transform.position;
		return distanceVector.magnitude;
	}

	public Vector3 getZombieLocation(){
		return zombieSeen.transform.position;
	}


	public bool IsAimingToZombie() {
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

    public Food FoodSeen()
    {
        if (foodSeen)
        {
            return foodSeen.GetComponent<Food>();
        }
        else
        {
            return null;
        }
    }

	public float getHumanTime(){
		return humanTimer;
	}
	
	public IList<HumanState> getFriendship()
	{
 	throw new System.NotImplementedException();
	}

}