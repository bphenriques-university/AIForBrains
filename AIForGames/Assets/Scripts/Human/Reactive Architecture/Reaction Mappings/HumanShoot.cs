using UnityEngine;
using System;

public class HumanShoot : ReactiveBehaviour
{

	public float minShootingDistance = 1f;

	HumanState humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
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
		
		humanState.FireWeapon ();
	}
}
