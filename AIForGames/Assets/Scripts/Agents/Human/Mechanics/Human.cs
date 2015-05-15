using UnityEngine;
using System.Collections.Generic;

public class Human : MonoBehaviour
{
    public HumanSight sight;
    HumanTouch touch;
    

    SightCollider sightColliderScript;     
    TouchCollider touchColliderScript;

    
	public GameObject ExitRoute;

    public Actuators Actuators;
    public Sensors Sensors;

	void Awake(){
		GameOverManager.humansAlive++;


		targetPosition = transform.position;

        sight = GetComponentInChildren<HumanSight>();
        touch = GetComponentInChildren<HumanTouch>();

        Sensors = GetComponent<Sensors>();
        Actuators = GetComponent<Actuators>();


        sightColliderScript = GetComponentInChildren<SightCollider>();
        touchColliderScript = GetComponentInChildren<TouchCollider>();


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
	
	public bool targetObjectInRangeToAttack;
	public Vector3 targetPosition;
	public GameObject targetObject = null;


	public float humanTimer = 0f;


	
	void Update(){
		humanTimer += Time.deltaTime;
		attackTimer += Time.deltaTime;

        sight.ProcessSight(sightColliderScript.SeenGameObjects);
        touch.ProcessTouch(touchColliderScript);
	}
	

	public float GetHumanTime(){
		return humanTimer;
	}
   
}