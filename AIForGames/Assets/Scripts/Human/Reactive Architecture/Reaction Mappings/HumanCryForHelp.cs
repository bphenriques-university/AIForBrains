using UnityEngine;
using System.Collections;

public class HumanCryForHelp : ReactiveBehaviour
{
	HumanState humanState;


	
	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
	}	
	
	
	
	protected override bool IsInSituation ()
	{
		return humanState.IsGrabbed ();
	}
	
	protected override void Execute ()
	{
		//Debug.Log ("PLEASE HELP HELP HELP HEP");
		humanState.actuator.SendCryForHelp ();	
	}
	
}
