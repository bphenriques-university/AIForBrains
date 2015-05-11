using UnityEngine;
using System.Collections;

public abstract class PlanComponent : MonoBehaviour
{
	public HumanState humanState;

	void Start(){
		humanState = this.transform.root.GetComponent<HumanState> ();
	}

	public abstract void ExecuteAction ();
}

