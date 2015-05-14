using UnityEngine;
using System.Collections;

public class HumanRandomWalk : ReactiveBehaviour
{
	public float timeBetweenChanges = 1.5f;
	public float range = 6f;

	Human human;
	float timeSinceChange;
	
	void Awake(){
		human = transform.root.GetComponent <Human> ();
	}

	void Update() {
		timeSinceChange += Time.deltaTime;
	}
	
	protected override bool IsInSituation ()
	{
		return !human.Sensors.IsGrabbed();
	}
	
	protected override void Execute ()
	{
		if (timeSinceChange < timeBetweenChanges)
			return;

		if (!human.Sensors.IsMoving ()) {

			changeDirection();
			human.Actuators.Walk();
			timeSinceChange = 0f;
			return;
		}

		int randomNum = Random.Range (0, 100);
		if (randomNum < 70) {
			human.Actuators.Walk ();
		} else if (randomNum < 99) {
			changeDirection ();
		} else {
			human.Actuators.Stop();
		}

		timeSinceChange = 0f;
	}

	private void changeDirection() {
		while (true) {
			Vector3 randomDirection = Random.onUnitSphere;
			randomDirection.y = 0;
			randomDirection.Normalize ();
			
			Ray shootRay = new Ray();
			RaycastHit shootHit;

			shootRay.origin = human.transform.position;
			shootRay.direction = randomDirection;


			if (Physics.Raycast (shootRay, out shootHit, 0.5f)) {
				continue;
			} else {
				randomDirection *= range;
				human.Actuators.ChangeDestination(human.transform.position + randomDirection);
				return;
			}
		}
	}
	
	
}