using System;
using UnityEngine;
using System.Collections;

public class SenseExitRoute : ReactiveBehaviour
{
	HumanState humanState;
	
	void Awake ()
	{
		humanState = transform.root.GetComponent <HumanState> ();
	}
	
	
	protected override bool IsInSituation ()
	{
		return !humanState.IsGrabbed () && humanState.IsSeeingExitRoute();
	}
	
	protected override void Execute ()
	{
		GameObject gameObject = humanState.exitSeen;
		
		if (humanState.exitSeen == null) {
			humanState.sawExitDoor = false;
			return;
		}
		
		Vector3 exitPosition = gameObject.transform.position;
		humanState.actuator.ChangeDestination (exitPosition);
		humanState.actuator.Run ();
	}

}

