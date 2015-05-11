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

	HumanState currentBeliefs;
	IList<PlanComponent> currentPlan = new List<PlanComponent> ();
	IList<Desire> currentDesires;
	IList<Intention> currentIntentions;
	//bool justPlanned = false;

	void Start () {
		currentBeliefs = this.transform.root.GetComponent<HumanState>();
		if (currentBeliefs == null) {
			Debug.Log("SOME SHIT HAPPENED THAT WASN'T SUPPOSED TO");

			//starting BDI
			currentDesires = Options(currentBeliefs);
			currentIntentions = Filter(currentBeliefs, currentDesires);
			currentPlan = GeneratePlan(currentIntentions);



		}
	}

	void Update () {
		//while believes it is possible and still hasn't accomplished the goal
		
		
		if (currentPlan.Count > 0) {
			if (! (PlanWasASuccess(currentBeliefs, currentIntentions) || PlanIsImpossible(currentIntentions, currentPlan))) {
				
				//runned after started the previous plan
				//if(!justPlanned){
				Debug.Log ("Reconsider?");
				if(ShouldReconsiderPlan(currentIntentions, currentBeliefs)){
					
					Debug.Log ("Reconsider? Yes!");
					currentDesires = Options(currentBeliefs, currentIntentions);
					currentIntentions = Filter(currentBeliefs, currentDesires, currentIntentions);
					
				}
				// if not sound (pi, I , B) then generate new plan
				Debug.Log ("PlanMakesSense?");
				if(PlanMakesSense(currentPlan, currentBeliefs, currentIntentions) == false){
					Debug.Log ("PlanMakesSense? No!");
					//justPlanned = 
					currentPlan = GeneratePlan(currentPlan, currentIntentions);
				}
				//}
				
				
				PlanComponent action = currentPlan[0];
				currentPlan.RemoveAt(0);
				action.ExecuteAction();
				//justPlanned = false;
				
				return;
			}
		}
		
		
	}


	//Beliefs are througout the humanStatae when perceiveing the environment
	enum Desire{
		GoToExit,
		RunFromZombie,
		HelpFriend,
		GetFood,
		GetAmmo
	}

	//pi = plan(B,I)
	IList<PlanComponent> GeneratePlan(IList<PlanComponent> plan, IList<Intention> intentions){
		currentPlan.Clear ();

		IList<PlanComponent> newPlan = new List<PlanComponent> ();

		//TODO: Dont be a foo, call Xu

		Debug.Log ("GENERATING PLAN");
		//justPlanned = true;
		//currentPlan.Add (RunAwayPC.GetPlanComponent ());
		return newPlan;
	}

	IList<PlanComponent> GeneratePlan(IList<Intention> intentions){
		currentPlan.Clear ();
		
		IList<PlanComponent> newPlan = new List<PlanComponent> ();
		
		//TODO: Dont be a foo, call Xu
		
		Debug.Log ("GENERATING PLAN");
		//justPlanned = true;
		//currentPlan.Add (RunAwayPC.GetPlanComponent ());
		return newPlan;
	}

	//sound(plan, I, B)
	bool PlanMakesSense(IList<PlanComponent> plan, HumanState beliefs, IList<Intention> intentions){
		return true;
	}

	//succeded(I, B)
	bool PlanWasASuccess(HumanState beliefs, IList<Intention> intentions){

		bool result = true;

		//TODO: Rough Implementation, not correct
		foreach (Intention intention in intentions) {
			result = result && intention.Succeeded();
		}
		
		return result;
	}

	//impossible(I, B)
	bool PlanIsImpossible(IList<Intention> intentions, IList<PlanComponent> plan){

		//TODO: Nao devia ter nada a ver com a intençao, iterar plano e ver se e possivel

		bool result = false;


		foreach(Intention intention in intentions){

			result = result || intention.IsImpossible();

			if(result == true)
				return result;

		}

		return result;
	}

	//reconsider (I, B)
	bool ShouldReconsiderPlan(IList<Intention> intentions, HumanState beliefs){
		//if contains grab, the only plan can only 
		return false;
	}



	//D = options (B, I)
	IList<Desire> Options(HumanState beliefs, IList<Intention> intentions){
		IList<Desire> desires = new List<Desire> ();

		//TODO: TIAGO SANTOS TRABALHA MANDRIAO, by: Tiago Santos
		return desires;	
	}

	
	IList<Desire> Options(HumanState beliefs){
		IList<Desire> desires = new List<Desire> ();
		
		//TODO: TIAGO SANTOS TRABALHA MANDRIAO, by: Tiago Santos
		return desires;	
	}

	//I = filter (B, D, I)
	IList<Intention> Filter(HumanState beliefs, IList<Desire> desires, IList<Intention> currentIntentions){
		IList<Intention> intentions = new List<Intention> ();
		//TODO: TIAGO SANTOS TRABALHA MANDRIAO, by: Tiago Santos
		return intentions;
	}

	IList<Intention> Filter(HumanState beliefs, IList<Desire> desires){
		IList<Intention> intentions = new List<Intention> ();
		//TODO: TIAGO SANTOS TRABALHA MANDRIAO, by: Tiago Santos
		return intentions;
	}





}