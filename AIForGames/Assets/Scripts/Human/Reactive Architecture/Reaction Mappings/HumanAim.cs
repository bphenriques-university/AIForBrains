using System;
using UnityEngine;

public class HumanAim : ReactiveBehaviour
{
	HumanState humanState;
	public float distanceToAim = 1f;


	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
	}	


	
	protected override bool IsInSituation ()
	{

		return humanState.IsSeeingZombie() && 
				!humanState.IsAimingToZombie() && 
				(humanState.getDistanceToZombie () > distanceToAim) &&
				humanState.CanShoot();

	}

	protected override void Execute ()
	{
		Vector3 zombiePosition = humanState.getZombieLocation ();
		humanState.Stop ();
		humanState.turnTo (zombiePosition);

	}

}


