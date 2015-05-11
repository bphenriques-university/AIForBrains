using UnityEngine;
using System.Collections;

public class GoToExitIntention : Intention
{
	public override bool DidSucceded (){
		return true;
	}

	public override bool IsImpossible(){
		return false;
	}
}

