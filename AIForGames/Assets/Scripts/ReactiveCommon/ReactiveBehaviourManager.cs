using System;
using UnityEngine;
using System.Reflection;

public class ReactiveBehaviourManager : MonoBehaviour
{
	public ReactiveBehaviour[] behaviours;

	public void Update(){
		foreach (ReactiveBehaviour r in behaviours) {
			r.UpdateSituation();

			if(r.triggered){
				r.Action();
				break;
			}
		}

	}
}