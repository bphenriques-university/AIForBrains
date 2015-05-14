using System;
using UnityEngine;

public class HumanAim : ReactiveBehaviour
{
	Human humanState;
	public float distanceToAim = 1f;


	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
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
		humanState.Actuators.Stop ();
		humanState.Actuators.turnTo (zombiePosition);
	}

}


