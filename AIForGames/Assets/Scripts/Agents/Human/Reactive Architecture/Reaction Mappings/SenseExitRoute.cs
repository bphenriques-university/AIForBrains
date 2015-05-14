using System;
using UnityEngine;
using System.Collections;

public class SenseExitRoute : ReactiveBehaviour
{
	Human humanState;
	
	void Awake ()
	{
		humanState = transform.root.GetComponent <Human> ();
	}
	
	
	protected override bool IsInSituation ()
	{
		return !humanState.IsGrabbed () && humanState.IsSeeingExitRoute();
	}
	
	protected override void Execute ()
	{
		GameObject gameObject = humanState.Sensors.ExitSeen();

        if (gameObject == null)
        {
			return;
		}
		
		Vector3 exitPosition = gameObject.transform.position;
		humanState.Actuators.ChangeDestination (exitPosition);
		humanState.Actuators.Run ();
	}

}

