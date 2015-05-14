using UnityEngine;
using System.Collections;

public class HumanCryForHelp : ReactiveBehaviour
{
	Human humanState;


	
	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
	}	
	
	
	
	protected override bool IsInSituation ()
	{
		return humanState.IsGrabbed ();
	}
	
	protected override void Execute ()
	{
		//Debug.Log ("PLEASE HELP HELP HELP HEP");
		humanState.Actuators.SendCryForHelp ();	
	}
	
}
