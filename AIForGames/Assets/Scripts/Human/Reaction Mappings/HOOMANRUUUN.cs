using System;
using UnityEngine;


public class HOOMANRUUUN : ReactiveBehaviour
{

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
		Vector3 FLYYOUFOOL = transform.position + RUNTHISWAY;

		humanState.ChangeDestination (FLYYOUFOOL);
		humanState.Run ();

	}

}


