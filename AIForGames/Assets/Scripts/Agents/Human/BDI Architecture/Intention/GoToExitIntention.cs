using UnityEngine;
using System.Collections;

public class GoToExitIntention : Intention
{

	public void Awake(){
		humanState = GetComponent<HumanState>();
	}

	public override bool Succeeded (){
		
		//Always returns false because when the human reaches the exit, the human is destroyed
		return false;
	}

	public override bool IsImpossible(){


		return humanState.ExitRoute == null;
		
	}
}

