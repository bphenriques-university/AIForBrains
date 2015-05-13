using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
                ! (WasASuccess(currentIntentions, beliefs) || IsImpossible(currentIntentions, beliefs))) {


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
				currentPlan = planner.GeneratePlan(beliefs, currentIntentions);
			}


        }
        else
        {
            beliefs.BeliefReviewFunction(humanState);
            currentDesires = desires.Options(beliefs, new List<Intention>());
            currentIntentions = intentions.Filter(beliefs, currentDesires, new List<Intention>());
            currentPlan = planner.GeneratePlan( beliefs, currentIntentions);
        }
		
		
	}

    public bool WasASuccess(IList<Intention> intentions, BeliefsManager beliefs)
    {

        bool result = true;

        //TODO: Rough Implementation, not correct
        foreach (Intention intention in intentions)
        {
            result = result && intention.Succeeded(beliefs);
        }

        return result;
    }

    bool IsImpossible(IList<Intention> intentions, BeliefsManager beliefs)
    {

        //TODO: Nao devia ter nada a ver com a intençao, iterar plano e ver se e possivel

        bool result = false;


        foreach (Intention intention in intentions)
        {

            result = result || intention.IsImpossible(beliefs);

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

}