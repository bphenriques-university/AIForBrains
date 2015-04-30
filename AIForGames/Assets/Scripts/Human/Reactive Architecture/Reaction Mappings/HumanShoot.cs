using UnityEngine;
using System;

public class HumanShoot : ReactiveBehaviour
{
	
	HumanState humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
	}
	
	protected override bool IsInSituation ()
	{
		return humanState.IsAimingToZombie () && humanState.CanShoot() && humanState.IsSeeingZombie();
	}
	
	protected override void Execute ()
	{
		
		humanState.FireWeapon ();
	}
}
