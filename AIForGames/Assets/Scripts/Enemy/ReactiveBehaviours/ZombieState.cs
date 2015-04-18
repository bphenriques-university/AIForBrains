using UnityEngine;
using System.Collections;

public class ZombieState : MonoBehaviour
{
	GameObject player;
	PlayerHealth playerHealth;
	NavMeshAgent nav;

	void Awake(){
		print ("HREEEEEE");
		targetPosition = transform.position;
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		print ("@@@@@@@@@@@@@@@@@@@@@@@@@@----> " + gameObject.name);
		nav = GetComponent <NavMeshAgent> ();
	}

	/* ------------------------------------------*/
	/* ---------- PUBLIC PROPERTIES  ------------*/
	/* ------------------------------------------*/

	public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
	public int attackDamage = 10;               // The amount of health taken away per attack
	public float followNoiseSpeed = 1.5f;
	public float followHumanSpeed = 2.5f;
	public float randomWalkSpeed = 1.0f;

	public Transform[] randomPoints;


	/* ------------------------------------------*/
	/* ----------       STATE        ------------*/
	/* ------------------------------------------*/

	float attackTimer;
	bool willWalk = false;

	public bool targetObjectInRangeToAttack;
	public Vector3 targetPosition;
	public GameObject targetObject;
	public bool hearing = false;
	public bool smelling = false;

	void Update(){
		attackTimer += Time.deltaTime;
	}

	/* ------------------------------------------*/
	/* ----------------- Sensors  ---------------*/
	/* ------------------------------------------*/

	public bool IsSmellingHuman(){
		return smelling;
	}

	public bool DidHeardHuman(){
		return hearing;
	}

	public bool IsSensingHuman() {
		return hearing || smelling;
	}

	public bool DidArrivedAtTargetPosition(){
		return Vector3.Distance (transform.position, targetPosition) < 1.0;
	}

	public bool CanAttack(){
		return attackTimer >= timeBetweenAttacks && targetObjectInRangeToAttack;
	}

	/* ------------------------------------------*/
	/* ---------------- Actuators  --------------*/
	/* ------------------------------------------*/
	
	public void GoToHeardDirection(){
		GotoPosition(targetPosition, followNoiseSpeed);
	}

	public void FollowTargetObject(){
		GotoPosition(targetObject.transform.position, followHumanSpeed);
	}

	public void RandomWalk(){
		targetPosition = GenerateRandomPosition();
		GotoPosition(targetPosition, randomWalkSpeed);
	}

	public void Attack ()
	{
		attackTimer = 0;
		playerHealth.TakeDamage (attackDamage);	
	}

	/* ------------------------------------------*/
	/* ---------------- Utilitary  --------------*/
	/* ------------------------------------------*/

	private Vector3 GenerateRandomPosition(){
		int spawnPointIndex = Random.Range (0, randomPoints.Length - 1);
		Transform copy = randomPoints [spawnPointIndex];

		return copy.position;
	}

	private void GotoPosition(Vector3 pos, float speed){
		nav.speed = speed;
		nav.SetDestination (pos);
	}
}