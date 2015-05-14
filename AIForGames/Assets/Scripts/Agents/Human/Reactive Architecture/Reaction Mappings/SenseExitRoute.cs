using System;
using UnityEngine;
using System.Collections;

public class SenseExitRoute : ReactiveBehaviour
{
	Human human;
	
	void Awake ()
	{
		human = transform.root.GetComponent <Human> ();
	}
	
	
	protected override bool IsInSituation ()
	{
		return !human.Sensors.IsGrabbed () && human.Sensors.SawExit();
	}
	
	protected override void Execute ()
	{
		GameObject gameObject = human.Sensors.ExitSeen();

        if (gameObject == null)
        {
			return;
		}
		
		Vector3 exitPosition = gameObject.transform.position;
		human.Actuators.ChangeDestination (exitPosition);
		human.Actuators.Run ();
	}

}

