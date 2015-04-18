using System;
using UnityEngine;

public class ZombieState : MonoBehaviour
{
	public Vector3 targetPosition;
	

	//some sensors
	public bool hearing = false;
	public bool smelling = false;
	public bool sensingHuman {get {return hearing || smelling;}}

	public bool arrivedAtTargetPosition{
		get {
			return Vector3.Distance (transform.position, targetPosition) <= 1.0;
	}}

	void Awake(){
		targetPosition = transform.position;
	}
}