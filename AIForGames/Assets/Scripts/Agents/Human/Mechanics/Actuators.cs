using UnityEngine;
using System.Collections;

public class Actuators : MonoBehaviour
{
	HumanHunger hunger;
	HumanShooting shooting;
	HumanMovement movement;
	HumanShooting playerShooting;
	HumanSpeak speak;

	void Awake(){
		GameOverManager.humansAlive++;
		
		Transform gunBarrelEnd = transform.root.FindChild ("GunBarrelEnd");
		playerShooting = gunBarrelEnd.GetComponent<HumanShooting> ();
		hunger = GetComponentInChildren<HumanHunger> ();
		shooting = GetComponentInChildren<HumanShooting> ();
		movement = GetComponentInChildren<HumanMovement> ();
		speak = GetComponentInChildren<HumanSpeak> ();

	}		

	/* ------------------------------------------*/
	/* ---------------- Actuators  --------------*/
	/* ------------------------------------------*/
	
	public void EatFood() {
		hunger.EatFood ();
	}

    public void EatFood(Food foodToBeEaten)
    {
        hunger.EatFood(foodToBeEaten);
    }
	
	public void TurnTo (Vector3 position)
	{
		movement.LookToDirection (position);
	}
	
	public void CatchFood(Food food) {
		hunger.AddFood (food.catchFood());
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


	public void GrabAmmo (Ammo ammo)
	{
		//Due to non-deterministic environment
		if (ammo == null) {
			return;
		}
		
		playerShooting.GrabAmmo(ammo.GrabAmmo ());
		
	}
	
	public void ChangeDestination(Vector3 newDirection){
		movement.ChangeDestination (newDirection);
	}

	public void Stop(){
		movement.Stop ();
	}

	public void SendCryForHelp(){
		speak.SendMessageToHumansNearby (HumanSpeak.Message.IAmGrabbed);
	}
}

