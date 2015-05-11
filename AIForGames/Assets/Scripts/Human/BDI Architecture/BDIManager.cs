using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/*
		 * while true
		 * 		get next percept p
		 * 		B = Brf (B, p)
		 * 		D = Options (B, I)
		 * 		I = filter (B, D, I)
		 * 		pi = plan(B,I)
		 * 		while not (empty(pi) or succeded(I, B) or impossible(I, B))
		 * 			action = head(pi)
		 * 			execute(action)
		 * 			pi = tail(pi)
		 * 			get next percept p
		 * 			B = Brf(B, p)
		 * 			if reconsider (I, B) then
		 * 				D = options (B, I)
		 * 				I = filter (B, D, I)
		 * 			end-if
		 * 
		 * 			if not sound (pi, I, B) then
		 * 				pi = plan (B, I)
		 * 			end-if
		 * 		end-while
		 * end-while
		 * 
		 */


public class BDIManager : MonoBehaviour {

	HumanState humanState;
	IList<PlanComponent> currentPlan = new List<PlanComponent> ();
	Intention currentIntention;
	bool justPlanned = false;

	void Start () {
		humanState = this.transform.root.GetComponent<HumanState>();
		if (humanState == null) {
			Debug.Log("SOME SHIT HAPPENED THAT WASN'T SUPPOSED TOO");
		}
	}


	//Beliefs are througout the humanStatae when perceiveing the environment
	enum Desire{
		GoToExit,
		Survive,
		HelpFriend,
		GetFood,
		GetAmmo
	}

	//pi = plan(B,I)
	void GeneratePlan(){
		currentPlan.Clear ();

		justPlanned = true;
		Debug.Log ("GENERATING PLAN");
		//currentPlan.Add (RunAwayPC.GetPlanComponent ());
	}

	//sound(plan, I, B)
	bool PlanMakesSense(){
		return true;
	}

	//succeded(I, B)
	bool PlanWasASuccess(){
		return currentIntention.DidSucceded ();
	}

	//impossible(I, B)
	bool PlanIsImpossible(){
		return currentIntention.IsImpossible();
	}

	//reconsider (I, B)
	bool ReconsiderPlan(){
		//if contains grab, the only plan can only 
		return false;
	}


	//D = options (B, I)
	//I = filter (B, D, I)
	void ReconsiderIntention(){
		IList<Desire> desires = new List<Desire> ();
		desires.Add(Desire.GoToExit);

		//currentIntention = GoToExitIntention.GetIntentionComponent ();
	}

	void Update () {
		//while believes it is possible and still hasn't accomplished the goal
		if (currentPlan.Count > 0) {
			if (! (PlanWasASuccess () || PlanIsImpossible ())) {
				
				//runned after started the previous plan
				if(!justPlanned){
					Debug.Log ("Reconsider?");
					if(ReconsiderPlan()){
						Debug.Log ("Reconsider? Yes!");
						ReconsiderIntention();
					}
					// if not sound (pi, I , B) then generate new plan
					Debug.Log ("PlanMakesSense?");
					if(! PlanMakesSense()){
						Debug.Log ("PlanMakesSense? No!");
						GeneratePlan();
					}
				}
				
				
				PlanComponent action = currentPlan[0];
				currentPlan.RemoveAt(0);
				action.ExecuteAction();
				justPlanned = false;
				
				return;
			}
		}

		ReconsiderIntention ();
		GeneratePlan ();
	}
}