using System;
using UnityEngine;
using System.Collections;

public class EnemySmell : MonoBehaviour
{

	GameObject player;

	public HumanInRange zombieState;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			print("ENEMY SMELL");
			zombieState.smelledHuman = true;
			zombieState.smellingObject = other.gameObject;
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			print("ENEMY SMELL EXIT");
			zombieState.smelledHuman = false;
			zombieState.lastKnownPosition = other.gameObject.transform.position;
		}
	}
}