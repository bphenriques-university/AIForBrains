using System;
using UnityEngine;
using System.Reflection;

public class EnemyBehaviourManager : MonoBehaviour
{
	public ReactiveBehaviour[] behaviours;

	public void Update(){


		foreach (ReactiveBehaviour r in behaviours) {
			r.UpdateSituation();
		}

		//print ("checking for trigger");
		foreach (ReactiveBehaviour r in behaviours) {

			//print(r.GetType().FullName + " : " + r.triggered);
			if (r.triggered){
				//print ("Triggered: " + r.GetType().FullName);
				r.Action();
				return;
			}
		}
	}
}