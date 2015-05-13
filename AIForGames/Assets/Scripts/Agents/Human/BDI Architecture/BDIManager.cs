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
            if (action.TryExecuteAction())
                currentPlan.Pop();

            beliefs.BeliefReviewFunction(humanState);

            if (ShouldReconsiderIntention(currentIntentions, beliefs))
            {
				Debug.Log ("Reconsider? Yes!");
                currentDesires = desires.Options(beliefs, currentIntentions);
				currentIntentions = intentions.Filter(beliefs, currentDesires, currentIntentions);
			}

			if (!currentPlan.MakesSense(humanState, currentIntentions)){
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

        foreach (Intention intention in intentions)
        {
            result = result && intention.Succeeded(beliefs);
        }

        return result;
    }

    bool IsImpossible(IList<Intention> intentions, BeliefsManager beliefs)
    {

        bool result = false;


        foreach (Intention intention in intentions)
        {

            result = result || intention.IsImpossible(beliefs);

            if (result == true)
                return result;

        }

        return result;
    }

    bool ShouldReconsiderIntention(IList<Intention> intentions, BeliefsManager beliefs)
    {
        float oldIntentionValue = 0f;
        float newIntentionValue = 0f;
        foreach (Intention intention in intentions)
        {
            oldIntentionValue += intention.IntentValue();
            if (!intention.Evaluate(beliefs, intentions))
                return true;        
            newIntentionValue += intention.IntentValue();
        }

        if (oldIntentionValue < newIntentionValue)
            return true;
        else
            return false;
    }

}