using UnityEngine;
using System;
using System.Collections;

public class EnemyHearing : MonoBehaviour 
{
	public HumanInRange zombieState;

	void HeardShot(GameObject from){
		print ("HeardShot!");
		zombieState.heardSound = true;
		zombieState.lastKnownPosition = from.transform.position;

	}

}