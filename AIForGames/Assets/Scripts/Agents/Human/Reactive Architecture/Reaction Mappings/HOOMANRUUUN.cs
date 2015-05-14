using System;
using UnityEngine;



public class HOOMANRUUUN : ReactiveBehaviour
{
	public float DANGERDISTANCE = 1f;
	public float SAFEDISTANCE = 15f;
	public float GOTTARUNTIME = 2f;
	float timer;

	Human humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
		timer = GOTTARUNTIME + 4;
	}

	void Update() {
		timer += Time.deltaTime;
	}

	protected override bool IsInSituation ()
	{

		if (timer < GOTTARUNTIME) {
			return true;
		} else {

			if (humanState.IsSeeingZombie ()) {
				EnemyHealth enemyHealth = humanState.zombieSeen.GetComponent<EnemyHealth> ();
				if (enemyHealth.hasDied ()) {
					return false;
				}

				if (!humanState.IsGrabbed ()) {
					timer = 0f;
					return true;
				}
			}
		}
		return false;
	}

	protected override void Execute ()
	{
		GameObject THINGTHATWANTSTOEATMYBRAINS = humanState.zombieSeen;

		Vector3 RUNTHISWAY = - (THINGTHATWANTSTOEATMYBRAINS.transform.position - transform.position);

		humanState.Actuators.ChangeDestination (transform.position + RUNTHISWAY.normalized * SAFEDISTANCE);
		humanState.Actuators.Run ();

	}

}


