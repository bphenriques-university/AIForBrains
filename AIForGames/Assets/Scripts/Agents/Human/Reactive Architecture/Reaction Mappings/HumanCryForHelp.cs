using UnityEngine;
using System.Collections;

public class HumanCryForHelp : ReactiveBehaviour
{
	Human human;


	
	void Awake(){
		human = transform.root.GetComponent <Human> ();
	}	
	
	
	
	protected override bool IsInSituation ()
	{
		return human.Sensors.IsGrabbed ();
	}
	
	protected override void Execute ()
	{
		//Debug.Log ("PLEASE HELP HELP HELP HEP");
		human.Actuators.SendCryForHelp ();	
	}
	
}
