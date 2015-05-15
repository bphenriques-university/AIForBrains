using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HybridManager : MonoBehaviour
{

    public ReactiveBehaviour[] behaviours;
    public ReactiveBehaviour lastBehaviour;



    private const float PLAN_TIME_LIMIT = 2f;

    private Human human;
    private BeliefsManager beliefs;
    private DesiresManager desires;
    private IntentionsManager intentions;
    private Planner planner;



    private Plan currentPlan;
    private IList<Desire> currentDesires;
    private IList<Intention> currentIntentions;
    //bool justPlanned = false;

    private float time = 0f;


    void Start()
    {
        human = this.transform.root.GetComponent<Human>();
        if (human == null)
            Debug.Log("SOME SHIT HAPPENED THAT WASN'T SUPPOSED TO");

        NavMap navMap = GameObject.FindGameObjectWithTag("NavMap").GetComponent<NavMap>();

        planner = new Planner(human);
        beliefs = new BeliefsManager(navMap);
        desires = new DesiresManager();
        intentions = new IntentionsManager();

        //starting BDI
        beliefs.BeliefReviewFunction(human);
        currentDesires = desires.Options(beliefs, new List<Intention>());
        currentIntentions = intentions.Filter(beliefs, currentDesires, new List<Intention>());
        currentPlan = planner.GeneratePlan(beliefs, currentIntentions);
        time = 0f;

    }

    void Update()
    {

        time += Time.deltaTime;

        if (transform.root.gameObject.activeInHierarchy)
        {
            foreach (ReactiveBehaviour r in behaviours)
            {
                r.UpdateSituation();

                if (r.WasTriggered())
                {
                    r.Action();
                    lastBehaviour = r;
                    return;
                }
            }
        }



        if (currentPlan.Count() > 0 &&
                !(WasASuccess(currentIntentions, beliefs) || IsImpossible(currentIntentions, beliefs)))
        {


            PlanComponent action = currentPlan.Head();
            if (action.TryExecuteAction())
                currentPlan.Pop();

            beliefs.BeliefReviewFunction(human);

            if (ShouldReconsiderIntention(currentIntentions, beliefs))
            {
                Debug.Log("Reconsider? Yes!");
                currentDesires = desires.Options(beliefs, currentIntentions);
                currentIntentions = intentions.Filter(beliefs, currentDesires, currentIntentions);

                //Also reconsiders plan
                currentPlan = planner.GeneratePlan(beliefs, currentIntentions);
                time = 0f;
            }

            if (!currentPlan.MakesSense(currentIntentions, beliefs))
            {
                Debug.Log("PlanMakesSense? No!");
                currentPlan = planner.GeneratePlan(beliefs, currentIntentions);
                time = 0f;
            }


        }
        else
        {
            beliefs.BeliefReviewFunction(human);
            currentDesires = desires.Options(beliefs, new List<Intention>());
            currentIntentions = intentions.Filter(beliefs, currentDesires, new List<Intention>());
            currentPlan = planner.GeneratePlan(beliefs, currentIntentions);
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
            if (oldIntentionValue == newIntentionValue && time > PLAN_TIME_LIMIT)
                return true;
            else
                return false;



    }

}