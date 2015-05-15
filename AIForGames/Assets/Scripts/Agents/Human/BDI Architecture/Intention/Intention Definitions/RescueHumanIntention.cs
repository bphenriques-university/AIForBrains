using UnityEngine;
using System.Collections.Generic;

public class RescueHumanIntention : Intention
{


    Human human;
    EnemyHealth closestZombieHealth;

    public RescueHumanIntention(Human humanToHelp, float desiredIntention)
        : base(desiredIntention)
    {

		this.human = humanToHelp;
		
	}

    public override bool Evaluate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        SightBelief humanSight = beliefs.GetSightBelief();

        InventoryBelief inventory = beliefs.GetInventoryBelief();
        int nBullets = inventory.AmmoLevel();
        int wasShootingExtraMotivation = 0;

        float killZombieIntentionLevel = 50 / Mathf.Ceil(1 / (nBullets * 2 + wasShootingExtraMotivation));
        intentValue = killZombieIntentionLevel;

        SocialBelief socialBelief = beliefs.GetSocialBelief();

        intentValue += socialBelief.getRelationship(this.human) / 3f;
        return true;
    }

    public override IList<PlanComponent> GivePlanComponents(Human humanState, BeliefsManager beliefs)
    {

        IList<PlanComponent> plan = new List<PlanComponent>();

        Vector3 positionToAidFrom = (this.human.transform.position - human.transform.position).normalized;
        //FIXME: 3.5f should be fetched from beliefs
        plan.Add(new RunToPlanComponent(human, positionToAidFrom * 3.5f));
        SightBelief sightBelief = beliefs.GetSightBelief();

        GameObject closestZombie = sightBelief.GetClosestZombie();
        closestZombieHealth = closestZombie.GetComponent<EnemyHealth>();
        plan.Add(new AimPlanComponent(human, closestZombie));
        plan.Add(new ZombieShootPlanComponent(human, closestZombie));
        return plan;
    }

    public override bool Succeeded(BeliefsManager beliefs)
    {

        SightBelief sightBelief = beliefs.GetSightBelief();

        if (closestZombieHealth != null)
            return closestZombieHealth.hasDied();
        else
            return sightBelief.SawHuman();
            
    }

    public override bool IsImpossible(BeliefsManager beliefs)
    {
        throw new System.NotImplementedException();
    }
}
