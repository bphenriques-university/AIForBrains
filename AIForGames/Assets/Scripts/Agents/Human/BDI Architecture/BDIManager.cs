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

	private HumanState humanState;
    private BeliefsManager beliefs;
    private DesiresManager desires;
    private IntentionsManager intentions;
    private Planner planner;
    


	private Plan currentPlan;
    private IList<Desire> currentDesires;
    private IList<Intention> currentIntentions;
	//bool justPlanned = false;


	void Start () {
        humanState = this.transform.root.GetComponent<HumanState>();
        if (humanState == null)
            Debug.Log("SOME SHIT HAPPENED THAT WASN'T SUPPOSED TO");

        planner = new Planner(humanState);
        beliefs = new BeliefsManager();
        desires = new DesiresManager();
        intentions = new IntentionsManager();

        //starting BDI
        beliefs.BeliefReviewFunction(humanState);
		currentDesires = desires.Options(beliefs, new List<Intention> ());
        currentIntentions = intentions.Filter(beliefs, currentDesires, new List<Intention>());
        currentPlan = planner.GeneratePlan(beliefs, currentIntentions);



		
	}

	void Update () {

		if (currentPlan.Count() > 0 &&
                ! (PlanWasASuccess(humanState, currentIntentions) || PlanIsImpossible(currentIntentions, currentPlan))) {


            PlanComponent action = currentPlan.Head();
            if (!action.TryExecuteAction())
                return;
            currentPlan.Pop();

            beliefs.BeliefReviewFunction(humanState);

			//runned after started the previous plan
			//if(!justPlanned){
			Debug.Log ("Reconsider?");
			if(ShouldReconsiderPlan(currentIntentions, humanState)){
					
				Debug.Log ("Reconsider? Yes!");
                currentDesires = desires.Options(beliefs, currentIntentions);
				currentIntentions = intentions.Filter(beliefs, currentDesires, currentIntentions);
					
			}
			// if not sound (pi, I , B) then generate new plan
			Debug.Log ("PlanMakesSense?");
			if(currentPlan.MakesSense(humanState, currentIntentions) == false){
				Debug.Log ("PlanMakesSense? No!");
				//justPlanned = 
				currentPlan = planner.GeneratePlan(beliefs, currentIntentions);
			}
			//}
				
				
			
			//justPlanned = false;


        }
        else
        {
            beliefs.BeliefReviewFunction(humanState);
            currentDesires = desires.Options(beliefs, new List<Intention>());
            currentIntentions = intentions.Filter(beliefs, currentDesires, new List<Intention>());
            currentPlan = planner.GeneratePlan( beliefs, currentIntentions);
        }
		
		
	}

    public bool PlanWasASuccess(HumanState beliefs, IList<Intention> intentions)
    {

        bool result = true;

        //TODO: Rough Implementation, not correct
        foreach (Intention intention in intentions)
        {
            result = result && intention.Succeeded();
        }

        return result;
    }

    bool PlanIsImpossible(IList<Intention> intentions, Plan plan)
    {

        //TODO: Nao devia ter nada a ver com a intençao, iterar plano e ver se e possivel

        bool result = false;


        foreach (Intention intention in intentions)
        {

            result = result || intention.IsImpossible();

            if (result == true)
                return result;

        }

        return result;
    }

    bool ShouldReconsiderPlan(IList<Intention> intentions, HumanState beliefs)
    {
        //if contains grab, the only plan can only 
        return false;
    }


	//Beliefs are througout the humanStatae when perceiveing the environment
	/*enum Desire{
		GoToExit,
		RunFromZombie,
		HelpFriend,
		GetFood,
		GetAmmo
	}
    */
	//pi = plan(B,I)
	

	//sound(plan, I, B)
	

	//impossible(I, B)
	


}