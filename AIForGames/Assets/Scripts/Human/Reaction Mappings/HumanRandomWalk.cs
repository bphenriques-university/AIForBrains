using UnityEngine;
using System.Collections;

public class HumanRandomWalk : ReactiveBehaviour
{
	public float timeBetweenChanges = 1.5f;
	public float range = 6f;

	HumanState humanState;
	float timeSinceChange;
	
	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
	}

	void Update() {
		timeSinceChange += Time.deltaTime;
	}
	
	protected override bool IsInSituation ()
	{
		return true;
	}
	
	protected override void Execute ()
	{
		if (timeSinceChange < timeBetweenChanges)
			return;

		if (!humanState.isMoving ()) {

			changeDirection();
			humanState.Walk();
			timeSinceChange = 0f;
			return;
		}

		int randomNum = Random.Range (0, 100);
		if (randomNum < 70) {
			humanState.Walk ();
		} else if (randomNum < 99) {
			changeDirection ();
		} else {
			humanState.Stop();
		}

		timeSinceChange = 0f;
	}

	private void changeDirection() {
		int i =0;
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
				humanState.ChangeDestination(humanState.transform.position + randomDirection);
				return;
			}
		}
	}
	
	
}