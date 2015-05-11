using UnityEngine;
using System.Collections;

public class Actuator : MonoBehaviour
{
	HumanState humanState;
	HumanHunger hunger;
	HumanShooting shooting;
	HumanMovement movement;
	HumanShooting playerShooting;

	void Awake(){
		GameOverManager.humansAlive++;
		
		Transform gunBarrelEnd = transform.root.FindChild ("GunBarrelEnd");
		playerShooting = gunBarrelEnd.GetComponent<HumanShooting> ();
		hunger = GetComponent<HumanHunger> ();
		shooting = GetComponentInChildren<HumanShooting> ();
		movement = GetComponentInChildren<HumanMovement> ();
		humanState = GetComponent<HumanState> ();
	}		

	/* ------------------------------------------*/
	/* ---------------- Actuators  --------------*/
	/* ------------------------------------------*/
	
	public void EatFood() {
		hunger.EatFood ();
	}
	
	public void turnTo (Vector3 position)
	{
		movement.LookToDirection (position);
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

	public void GoToExitRoute(){
		Debug.Log ("Going to exit");
		ChangeDestination (humanState.ExitRoute.transform.position);
		movement.Run ();
	}

	public void grabAmmo ()
	{
		GameObject ammoObject = humanState.ammoSeen;
		
		//Due to non-deterministic environment
		if (ammoObject == null) {
			humanState.onAmmo = false;
			humanState.sawAmmo = false;
			return;
		}
		
		
		Ammo ammo = ammoObject.GetComponent<Ammo> ();
		
		playerShooting.GrabAmmo(ammo.GrabAmmo ());
		
		humanState.onAmmo = false;
		humanState.sawAmmo = false;
	}
	
	public void ChangeDestination(Vector3 newDirection){
		movement.ChangeDestination (newDirection);
	}

	public void Stop(){
		movement.Stop ();
	}
}

