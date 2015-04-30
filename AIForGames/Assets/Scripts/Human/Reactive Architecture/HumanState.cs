using UnityEngine;
using System.Collections;

public class HumanState : MonoBehaviour
{
	HumanHunger hunger;
	HumanHealth health;
	HumanShooting shooting;
	HumanMovement movement;
	HumanShooting playerShooting;
	Rigidbody rigidBody;	
	int shootableMask;

	void Awake(){
		GameOverManager.humansAlive++;
		
		Transform gunBarrelEnd = transform.root.FindChild ("GunBarrelEnd");
		playerShooting = gunBarrelEnd.GetComponent<HumanShooting> ();
		targetPosition = transform.position;
		hunger = GetComponent<HumanHunger> ();
		health = GetComponent<HumanHealth> ();
		shooting = GetComponentInChildren<HumanShooting> ();
		movement = GetComponentInChildren<HumanMovement> ();
		shootableMask = LayerMask.GetMask ("Shootable");
		rigidBody = GetComponent<Rigidbody> ();

	}
	
	/* ------------------------------------------*/
	/* ---------- PUBLIC PROPERTIES  ------------*/
	/* ------------------------------------------*/
	
	public Transform[] randomPoints;
	
	
	/* ------------------------------------------*/
	/* ----------       STATE        ------------*/
	/* ------------------------------------------*/
	
	float attackTimer;
	int lastSeenHealth;
	
	public bool targetObjectInRangeToAttack;
	public Vector3 targetPosition;
	public GameObject targetObject;
	public GameObject foodSeen;
	public GameObject ammoSeen;
	public GameObject zombieSeen;
	public GameObject exitSeen;

	public bool sawFood = false;
	public bool onFood = false;
	public bool sawZombie = false;
	public bool sawHumanInDanger = false;
	public bool grabbed = false;
	public bool bitten = false;
	public bool sawAmmo = false;
	public bool onAmmo = false;
	public bool sawExitDoor = false;

	
	void Update(){
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
		return sawZombie;
	}

	public bool IsSeeingHumanInDanger(){
		return sawHumanInDanger;
	}

	public bool IsGrabbed(){
		return grabbed;
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

	
	/* ------------------------------------------*/
	/* ---------------- Actuators  --------------*/
	/* ------------------------------------------*/

	public void EatFood() {
		hunger.EatFood ();
	}

	public void turnTo (Vector3 zombiePosition)
	{
		//TODO:Turn to Zombie


	}

	public void CatchFood(Food food) {
		hunger.AddFood (food);
	}
	
	public void FireWeapon(){
		shooting.Shoot ();
	}
	
	public void GiveFood(){
	}
	
	public void Walk(){
		movement.Walk ();
	}

	public void Run(){
		movement.Run ();
	}

	public void grabAmmo ()
	{
		GameObject ammoObject = ammoSeen;
		
		//Due to non-deterministic environment
		if (ammoObject == null) {
			onAmmo = false;
			sawAmmo = false;
			return;
		}
		
		
		Ammo ammo = ammoObject.GetComponent<Ammo> ();
		
		playerShooting.GrabAmmo(ammo.GrabAmmo ());
		
		onAmmo = false;
		sawAmmo = false;
	}

	public void ChangeDestination(Vector3 newDirection){
		movement.ChangeDestination (newDirection);
	}

	public void Stop(){
		movement.Stop ();
	}

	
	/* ------------------------------------------*/
	/* ---------------- Utilitary  --------------*/
	/* ------------------------------------------*/
	
	private Vector3 GenerateRandomPosition(){
		int spawnPointIndex = Random.Range (0, randomPoints.Length - 1);
		Transform copy = randomPoints [spawnPointIndex];
		
		return copy.position;
	}




}