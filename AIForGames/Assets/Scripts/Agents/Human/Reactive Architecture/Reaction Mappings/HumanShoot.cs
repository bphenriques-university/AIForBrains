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
		return humanState.IsAimingToZombie () && 
				humanState.CanShoot() && 
				humanState.IsSeeingZombie() &&
				humanState.getDistanceToZombie() > minShootingDistance;
	}
	
	protected override void Execute ()
	{
		
		humanState.Actuators.FireWeapon ();
	}
}
