using UnityEngine;
using System.Collections.Generic;

public class Human : MonoBehaviour
{
	Collider sightCollider;

	HumanHunger hunger;
	HumanHealth health;
	HumanShooting shooting;
	HumanMovement movement;
    HumanSpeak speech;
    HumanSight sight;
    HumanTouch touch;

    SightCollider sightColliderScript;     
    TouchCollider touchColliderScript;

	int shootableMask;

    
	public GameObject ExitRoute;

    public HumanObjectMemory memory;
    public Actuators Actuators;
    public Sensors Sensors;

	void Awake(){
		GameOverManager.humansAlive++;


		targetPosition = transform.position;

        speech = GetComponentInChildren<HumanSpeak>();
        hunger = GetComponentInChildren<HumanHunger>();
        health = GetComponentInChildren<HumanHealth>();
		shooting = GetComponentInChildren<HumanShooting> ();
        movement = GetComponentInChildren<HumanMovement>();
        sight = GetComponentInChildren<HumanSight>();
        touch = GetComponentInChildren<HumanTouch>();

        Sensors = GetComponent<Sensors>();


		shootableMask = LayerMask.GetMask ("Shootable");
        Actuators = GetComponent<Actuators>();
        sightCollider = GetComponentInChildren<MeshCollider>();


        sightColliderScript = GetComponentInChildren<SightCollider>();
        touchColliderScript = GetComponentInChildren<TouchCollider>();

        memory = new HumanObjectMemory(sightCollider);

	}
	
	/* ------------------------------------------*/
	/* ---------- PUBLIC PROPERTIES  ------------*/
	/* ------------------------------------------*/
	
	public Transform[] randomPoints;
	public GameObject[] closeFriends;
	
	/* ------------------------------------------*/
	/* ----------       STATE        ------------*/
	/* ------------------------------------------*/

	float attackTimer;
	int lastSeenHealth;
	
	public bool targetObjectInRangeToAttack;
	public Vector3 targetPosition;
	public GameObject targetObject = null;


	public float humanTimer = 0f;


	
	void Update(){
		humanTimer += Time.deltaTime;
		attackTimer += Time.deltaTime;
		memory.CleanWrongMemories ();

        sight.ProcessSight(sightColliderScript.SeenGameObjects);
        touch.ProcessTouch(touchColliderScript);
	}
	

	public float GetHumanTime(){
		return humanTimer;
	}
   
}