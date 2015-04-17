using System;
using UnityEngine;
using System.Reflection;

public class ReactiveBehaviourManager : MonoBehaviour
{
	public ReactiveBehaviour[] behaviours;

	public void Update(){
		foreach (ReactiveBehaviour r in behaviours) {
			r.UpdateSituation();
		}

		foreach (ReactiveBehaviour r in behaviours) {
			if (r.triggered){
				r.Action();
				return;
			}
		}
	}
}