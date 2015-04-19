using System;
using UnityEngine;



public class HOOMANRUUUN : ReactiveBehaviour
{
	public float SAFEDISTANCE = 15f;
	public float GOTTARUNTIME = 2f;
	float timer;

	HumanState humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
		timer = GOTTARUNTIME + 1;
	}

	protected override bool IsInSituation ()
	{

		timer += Time.deltaTime;
		if (timer < GOTTARUNTIME) {
			return true;
		} else {
			if(humanState.IsSeeingZombie())
				timer = 0f;
		}

		return !humanState.IsGrabbed () && humanState.IsSeeingZombie ();
	}

	protected override void Execute ()
	{
		GameObject THINGTHATWANTSTOEATMYBRAINS = humanState.zombieSeen;

		Vector3 RUNTHISWAY = - (THINGTHATWANTSTOEATMYBRAINS.transform.position - transform.position);

		humanState.ChangeDestination (transform.position + RUNTHISWAY.normalized * SAFEDISTANCE);
		humanState.Run ();

	}

}


