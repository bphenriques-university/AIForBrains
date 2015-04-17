using System;
using UnityEngine;

public class HumanInRange : ReactiveBehaviour
{
	public GameObject smellingObject;
	public Vector3 lastKnownPosition;
	public bool heardSound;
	public bool smelledHuman;
	
	GameObject player;
	NavMeshAgent nav;
	
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		nav = this.transform.root.gameObject.GetComponent <NavMeshAgent> ();
	}


	protected override bool IsInSituation ()
	{
		return true;
	}
	
	protected override void Execute ()
	{
		if (smelledHuman) {
			nav.SetDestination (smellingObject.transform.position);
		} else {
			if(lastKnownPosition != null)
				nav.SetDestination (lastKnownPosition);
		}

		if (heardSound) {
			heardSound = false;
		}
	}
}