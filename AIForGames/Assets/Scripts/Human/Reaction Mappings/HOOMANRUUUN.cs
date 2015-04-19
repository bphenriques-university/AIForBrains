using System;
using UnityEngine;



public class HOOMANRUUUN : ReactiveBehaviour
{
	public float SAFEDISTANCE = 6f;

	HumanState humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
	}

	protected override bool IsInSituation ()
	{
		return !humanState.IsGrabbed () && humanState.IsSeeingZombie ();
	}

	protected override void Execute ()
	{
		GameObject THINGTHATWANTSTOEATMYBRAINS = humanState.zombieSeen;

		Vector3 RUNTHISWAY = - (THINGTHATWANTSTOEATMYBRAINS.transform.position - transform.position);

		humanState.ChangeDestination (RUNTHISWAY.normalized * SAFEDISTANCE);
		humanState.Run ();

	}

}


