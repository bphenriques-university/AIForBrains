using System;
using UnityEngine;
using System.Collections;

public class SenseExitRoute : ReactiveBehaviour
{
	ZombieState zombieState;
	
	void Awake ()
	{
		zombieState = transform.root.GetComponent <ZombieState> ();
	}
	
	
	protected override bool IsInSituation ()
	{
		return true; //zombieState.Is();
	}
	
	protected override void Execute ()
	{

		//zombieState.GoToExitPosition ();
	}

}

