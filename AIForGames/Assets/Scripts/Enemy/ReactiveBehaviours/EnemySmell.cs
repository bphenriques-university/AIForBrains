using System;
using UnityEngine;
using System.Collections;

public class EnemySmell : ReactiveBehaviour
{
	public ZombieState zombieState;
	public float smellSpeed = 2.5f;

	GameObject player;
	GameObject parent;

	GameObject targetSmell;
	PlayerHealth playerHealth;
	NavMeshAgent nav;

	Vector3 smellingPoint;

	void Awake ()
	{
		parent = this.transform.root.gameObject;
		player = GameObject.FindGameObjectWithTag ("Player");
		nav = transform.root.gameObject.GetComponent <NavMeshAgent> ();
	}

	protected override bool IsInSituation ()
	{
		return zombieState.smelling;
	}
	
	protected override void Execute ()
	{
		nav.speed = smellSpeed;
		nav.SetDestination (smellingPoint);
	}

	public void Update(){

		if (targetSmell != null) {
			smellingPoint = targetSmell.transform.position;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		//will change this to collider
		if(other.gameObject == player)
		{
			print ("Smelled delicious human");
			zombieState.smelling = true;
			targetSmell = other.gameObject;
			smellingPoint = other.gameObject.transform.position;
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			print ("Not smelling delicious human");
			zombieState.smelling = false;
			zombieState.targetPosition = other.gameObject.transform.position;
		}
	}
}