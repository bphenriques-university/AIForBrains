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
		timer = GOTTARUNTIME + 4;
	}

	protected override bool IsInSituation ()
	{




		if (timer < GOTTARUNTIME) {
			timer += Time.deltaTime;
			return true;
		} else {
			if(humanState.IsSeeingZombie())
				timer = 0f;
		}

		if (humanState.IsSeeingZombie ()) {
			EnemyHealth enemyHealth = humanState.zombieSeen.GetComponent<EnemyHealth> ();
			if (enemyHealth.hasDied ()) {
				return false;
			}
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


