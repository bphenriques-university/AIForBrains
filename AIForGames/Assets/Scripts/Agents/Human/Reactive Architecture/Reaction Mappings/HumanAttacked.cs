using UnityEngine;
using System;

public class HumanAttacked : ReactiveBehaviour
{
	
	Human human;
	
	void Awake(){
		human = transform.root.GetComponent <Human> ();
	}
	
	protected override bool IsInSituation ()
	{
		return human.Sensors.WasAttacked ();
	}
	
	protected override void Execute ()
	{
		human.Actuators.Run ();
	}
}
