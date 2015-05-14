using UnityEngine;
using System.Collections;

public class HumanRandomWalk : ReactiveBehaviour
{
	public float timeBetweenChanges = 1.5f;
	public float range = 6f;

	Human humanState;
	float timeSinceChange;
	
	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
	}

	void Update() {
		timeSinceChange += Time.deltaTime;
	}
	
	protected override bool IsInSituation ()
	{
		return !humanState.IsGrabbed();
	}
	
	protected override void Execute ()
	{
		if (timeSinceChange < timeBetweenChanges)
			return;

		if (!humanState.isMoving ()) {

			changeDirection();
			humanState.Actuators.Walk();
			timeSinceChange = 0f;
			return;
		}

		int randomNum = Random.Range (0, 100);
		if (randomNum < 70) {
			humanState.Actuators.Walk ();
		} else if (randomNum < 99) {
			changeDirection ();
		} else {
			humanState.Actuators.Stop();
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

			shootRay.origin = humanState.transform.position;
			shootRay.direction = randomDirection;


			if (Physics.Raycast (shootRay, out shootHit, 0.5f)) {
				continue;
			} else {
				randomDirection *= range;
				humanState.Actuators.ChangeDestination(humanState.transform.position + randomDirection);
				return;
			}
		}
	}
	
	
}