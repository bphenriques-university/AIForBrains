using UnityEngine;
using System.Collections.Generic;

public class Human : MonoBehaviour
{
	static IList<Human> existingHumans = new List<Human> ();
    HumanSight sight;
    HumanTouch touch;
    

    SightCollider sightColliderScript;     
    TouchCollider touchColliderScript;


    

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
	
	/* ------------------------------------------*/
	/* ----------       STATE        ------------*/
	/* ------------------------------------------*/

	float attackTimer;
	
	public bool targetObjectInRangeToAttack;
	public Vector3 targetPosition;
	public GameObject targetObject = null;

	public Human(){
		existingHumans.Add (this);
	}
	
	void Update(){
		attackTimer += Time.deltaTime;

        sight.ProcessSight(sightColliderScript.SeenGameObjects);
        touch.ProcessTouch(touchColliderScript);
	}


	public static IList<Human> GetHumans(){
		return existingHumans;
	}
   
}