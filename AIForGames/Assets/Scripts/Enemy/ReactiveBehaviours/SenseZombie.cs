using UnityEngine;

public class SenseZombie : ReactiveBehaviour
{
	ZombieState zombieState;
	
	void Awake ()
	{
		zombieState = transform.root.GetComponent <ZombieState> ();
	}
	
	
	protected override bool IsInSituation ()
	{
		return zombieState.IsSensingZombie();
	}
	
	protected override void Execute ()
	{
		print ("FOLLOWING ZOMBIE");
		zombieState.FollowNearestZombie ();
	}
	
	void OnTriggerEnter (Collider other)
	{
		print ("SENSING ZOMBIE");
		if(other.gameObject.tag == "Enemy")
		{
			zombieState.sensingZombie = true;
			zombieState.nearestZombie = other.gameObject;
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		print ("NOT SENSING ZOMBIE");
		if(other.gameObject.tag == "Enemy")
		{
			zombieState.sensingZombie = false;
			zombieState.nearestZombie = transform.root.gameObject;
		}
	}
}
