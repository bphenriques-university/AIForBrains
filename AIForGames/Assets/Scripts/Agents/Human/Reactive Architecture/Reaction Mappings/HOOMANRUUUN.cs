using System;
using UnityEngine;



public class HOOMANRUUUN : ReactiveBehaviour
{
	public float DANGERDISTANCE = 1f;
	public float SAFEDISTANCE = 15f;
	public float GOTTARUNTIME = 2f;
	float timer;

	Human human;
	
	void Awake(){
		human = transform.root.GetComponent <Human> ();
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

			if (human.Sensors.SawZombies()) {
				EnemyHealth enemyHealth = human.Sensors.GetClosestZombie().GetComponent<EnemyHealth> ();
				if (enemyHealth.hasDied ()) {
					return false;
				}

				if (!human.Sensors.IsGrabbed ()) {
					timer = 0f;
					return true;
				}
			}
		}
		return false;
	}

	protected override void Execute ()
	{
		GameObject THINGTHATWANTSTOEATMYBRAINS = human.Sensors.GetClosestZombie();

		Vector3 RUNTHISWAY = - (THINGTHATWANTSTOEATMYBRAINS.transform.position - transform.position);

		human.Actuators.ChangeDestination (transform.position + RUNTHISWAY.normalized * SAFEDISTANCE);
		human.Actuators.Run ();

	}

}


