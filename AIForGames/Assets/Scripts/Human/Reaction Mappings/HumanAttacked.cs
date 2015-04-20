using UnityEngine;
using System;

public class HumanAttacked : ReactiveBehaviour
{
	
	HumanState humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
	}
	
	protected override bool IsInSituation ()
	{
		return humanState.WasAttacked ();
	}
	
	protected override void Execute ()
	{
		humanState.Run ();
	}
}
