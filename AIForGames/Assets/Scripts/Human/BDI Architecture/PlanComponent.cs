using UnityEngine;
using System.Collections;

public abstract class PlanComponent : MonoBehaviour
{
	public HumanState humanState;
	public Actuator actuator;

	void Start(){
		humanState = this.transform.root.GetComponent<HumanState> ();
		actuator = humanState.actuator;
	}

	public abstract void ExecuteAction ();
}

