using UnityEngine;
using System;

public class HumanAttacked : ReactiveBehaviour
{
	
	Human humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
	}
	
	protected override bool IsInSituation ()
	{
		return humanState.WasAttacked ();
	}
	
	protected override void Execute ()
	{
		humanState.Actuators.Run ();
	}
}
