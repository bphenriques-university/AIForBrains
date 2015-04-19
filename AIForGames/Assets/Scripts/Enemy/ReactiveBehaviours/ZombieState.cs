using UnityEngine;
using System.Collections;

public class ZombieState : MonoBehaviour
{
	NavMeshAgent nav;

	void Awake(){
		GameOverManager.zombiesAlive++;

		targetPosition = transform.position;
		nav = GetComponent <NavMeshAgent> ();
	}

	/* ------------------------------------------*/
	/* ---------- PUBLIC PROPERTIES  ------------*/
	/* ------------------------------------------*/

	public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
	public float timeUntilAttack = 1.0f;

	public int attackDamage = 10;               // The amount of health taken away per attack
	public float followNoiseSpeed = 1.5f;
	public float followHumanSpeed = 2.5f;
	public float randomWalkSpeed = 1.0f;

	public Transform[] randomPoints;


	/* ------------------------------------------*/
	/* ----------       STATE        ------------*/
	/* ------------------------------------------*/

	float attackTimer;
	float timerFromGrabUntilAttack = 0;
	bool willWalk = false;

	public bool targetInRangeToGrab;
	bool targetGrabbed;
	public Vector3 targetPosition;
	public GameObject targetObject;
	public GameObject nearestZombie;
	public bool hearing = false;
	public bool smelling = false;
	public bool isAttacking;
	public bool sensingZombie;
	
	void Update(){
		attackTimer += Time.deltaTime;

		//print (timerFromGrabUntilAttack);
		if(targetGrabbed)
			timerFromGrabUntilAttack += Time.deltaTime;
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

	public bool CanGrab(){
		return targetInRangeToGrab;
	}

	public bool CanStartToAttack(){
		return targetGrabbed && timerFromGrabUntilAttack >= timeUntilAttack;
	}


	public bool IsSensingZombie(){
		return sensingZombie;
	}

	public bool CanAttack(){
		return  isAttacking && attackTimer >= timeBetweenAttacks && targetGrabbed;
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
		HumanHealth humanHealth = targetObject.GetComponent<HumanHealth> ();

		if (humanHealth != null) {
			humanHealth.TakeDamage(attackDamage);
			isAttacking = true;

			if (humanHealth.isHumanDead()) {
				Leave();
				isAttacking = false;
			}
		}
	}

	public void Grab(){
		HumanMovement m = targetObject.GetComponent<HumanMovement>();

		if(m != null){
			m.SetGrab(true);
			targetGrabbed = true;
			return;
		}

		PlayerMovement p = targetObject.GetComponent<PlayerMovement> ();
		if (p != null) {
			p.SetMove (true);
			targetGrabbed = true;
			return;
		}

	}

	public void Leave(){
		HumanMovement m = targetObject.GetComponent<HumanMovement>();
		
		if(m != null){
			m.SetGrab(false);
			targetGrabbed = false;
			timerFromGrabUntilAttack = 0;
		}

		PlayerMovement p = targetObject.GetComponent<PlayerMovement> ();
		if (p != null) {
			p.SetMove (true);
			targetGrabbed = false;
			timerFromGrabUntilAttack = 0;
			return;
		}
	}

	public void FollowNearestZombie (){
		NavMeshAgent nav = nearestZombie.GetComponent<NavMeshAgent> ();
		if (nav != null) {
			Vector3 dest = nav.destination + Random.insideUnitSphere * 5;
			dest.y = 0;
			GotoPosition (dest, randomWalkSpeed);
		}
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