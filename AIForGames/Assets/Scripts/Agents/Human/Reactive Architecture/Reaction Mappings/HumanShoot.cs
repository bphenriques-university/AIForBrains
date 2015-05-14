using UnityEngine;
using System;

public class HumanShoot : ReactiveBehaviour
{

	public float minShootingDistance = 1f;

	Human human;
	
	void Awake(){
		human = transform.root.GetComponent <Human> ();
	}
	
	protected override bool IsInSituation ()
	{
		return human.Sensors.IsAimingToObject (human.Sensors.GetClosestZombie()) && 
				human.Sensors.CanShoot() && 
				human.Sensors.SawZombies() &&
                human.Sensors.GetDistanceToObject(human.Sensors.GetClosestZombie()) > minShootingDistance;
	}
	
	protected override void Execute ()
	{
		
		human.Actuators.FireWeapon ();
	}
}
