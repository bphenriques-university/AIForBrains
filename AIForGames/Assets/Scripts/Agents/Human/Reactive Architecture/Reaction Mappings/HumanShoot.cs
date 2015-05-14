using UnityEngine;
using System;

public class HumanShoot : ReactiveBehaviour
{

	public float minShootingDistance = 1f;

	Human humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
	}
	
	protected override bool IsInSituation ()
	{
		return humanState.IsAimingToZombie (humanState.Sensors.GetClosestZombie()) && 
				humanState.CanShoot() && 
				humanState.IsSeeingZombie() &&
                humanState.getDistanceToObject(humanState.Sensors.GetClosestZombie()) > minShootingDistance;
	}
	
	protected override void Execute ()
	{
		
		humanState.Actuators.FireWeapon ();
	}
}
