﻿using UnityEngine;
using System.Collections;

public class HumanState : MonoBehaviour
{
	HumanHunger hunger;
	HumanHealth health;
	HumanShooting shooting;
	HumanMovement movement;
	HumanShooting playerShooting;


	void Awake(){
		GameOverManager.humansAlive++;
		
		Transform gunBarrelEnd = transform.root.FindChild ("GunBarrelEnd");
		playerShooting = gunBarrelEnd.GetComponent<HumanShooting> ();
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
	
	public bool targetObjectInRangeToAttack;
	public Vector3 targetPosition;
	public GameObject targetObject;
	public GameObject foodSeen;
	public GameObject ammoSeen;
	public GameObject zombieSeen;

	public bool sawFood = false;
	public bool onFood = false;
	public bool sawZombie = false;
	public bool sawHumanInDanger = false;
	public bool grabbed = false;
	public bool bitten = false;
	public bool sawAmmo = false;
	public bool onAmmo = false;
	
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

	public bool IsSeeingAmmo(){
		return sawAmmo;
	}

	public int FoodCarried () {
		return hunger.GetFoodCarried ();
	}

	public float HungerLevel() {
		return hunger.GetHungerLevel ();
	}

	public int HealthLevel() {
		return health.getHealthLevel ();
	}
	
	public bool DidArrivedAtTargetPosition(){
		return Vector3.Distance (transform.position, targetPosition) < 1;
	}

	
	/* ------------------------------------------*/
	/* ---------------- Actuators  --------------*/
	/* ------------------------------------------*/

	public void EatFood() {
		hunger.EatFood ();
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