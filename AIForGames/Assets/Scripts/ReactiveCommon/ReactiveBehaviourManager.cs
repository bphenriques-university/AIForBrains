using System;
using UnityEngine;
using System.Reflection;

public class ReactiveBehaviourManager : MonoBehaviour
{
	public ReactiveBehaviour[] behaviours;
	public ReactiveBehaviour lastBehaviour;

	public void Update(){

		//check if this object was not destroyed
		if (transform.root.gameObject.activeInHierarchy) {
			foreach (ReactiveBehaviour r in behaviours) {
				r.UpdateSituation ();

				if (r.WasTriggered()) {
					r.Action ();
					lastBehaviour = r;
					break;
				}
			}
		}
	}
}