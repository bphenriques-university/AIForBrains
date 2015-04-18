using System;
using UnityEngine;

public class HumanInRange : ReactiveBehaviour
{
	public GameObject smellingObject;
	public Vector3 lastKnownPosition;
	public bool heardSound;
	public bool smelledHuman;



	PlayerHealth playerHealth;
	GameObject player;
	NavMeshAgent nav;
	
	void Awake ()
	{
		lastKnownPosition = this.transform.position;
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth.GetComponent<PlayerHealth> ();
		nav = this.transform.root.gameObject.GetComponent <NavMeshAgent> ();
	}


	protected override bool IsInSituation ()
	{
		return playerHealth != null && playerHealth.currentHealth > 0;
	}
	
	protected override void Execute ()
	{
		if (smelledHuman) {
			nav.SetDestination (smellingObject.transform.position);
		} else {
			nav.SetDestination (lastKnownPosition);
		}

		if (heardSound) {
			heardSound = false;
		}
	}
}