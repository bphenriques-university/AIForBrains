using UnityEngine;
using System.Collections;

public class HumanState : MonoBehaviour
{
	HumanHunger hunger;
	HumanHealth health;
	HumanShooting shooting;
	HumanMovement movement;
	
	void Awake(){
		targetPosition = transform.position;
		hunger = GetComponent<HumanHunger> ();
		health = GetComponent<HumanHealth> ();
		shooting = GetComponentInChildren<HumanShooting> ();
		movement = GetComponentInChildren<HumanMovement> ();
	}
	
	/* ------------------------------------------*/
	/* ---------- PUBLIC PROPERTIES  ------------*/
	/* ------------------------------------------*/
	
	public Transform[] randomPoints;
	
	
	/* ------------------------------------------*/
	/* ----------       STATE        ------------*/
	/* ------------------------------------------*/
	
	float attackTimer;
	bool willWalk = false;
	
	public bool targetObjectInRangeToAttack;
	public Vector3 targetPosition;
	public GameObject targetObject;

	public bool sawFood = false;
	public bool sawZombie = false;
	public bool sawHumanInDanger = false;
	public bool grabbed = false;
	public bool bitten = false;

	
	void Update(){
		attackTimer += Time.deltaTime;
	}
	
	/* ------------------------------------------*/
	/* ----------------- Sensors  ---------------*/
	/* ------------------------------------------*/
	
	public bool IsSeeingFood(){
		return sawFood;
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



	public float HungerLevel() {
		return hunger.getHungerLevel ();
	}

	public int HealthLevel() {
		return health.getHealthLevel ();
	}
	
	public bool DidArrivedAtTargetPosition(){
		return Vector3.Distance (transform.position, targetPosition) < 1.0;
	}

	
	/* ------------------------------------------*/
	/* ---------------- Actuators  --------------*/
	/* ------------------------------------------*/

	public void EatFood() {

	}

	public void CatchFood() {

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