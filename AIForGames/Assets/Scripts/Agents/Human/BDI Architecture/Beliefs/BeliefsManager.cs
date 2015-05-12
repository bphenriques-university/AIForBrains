using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BeliefsManager
{

    /* List of possible beliefs */
    private HungerBelief foodLevelBelief = new HungerBelief();
    private InventoryBelief inventoryBelief = new InventoryBelief();
    private VitalsBelief healthLevelBelief = new VitalsBelief();
    private SightBelief sightBelief = new SightBelief();
    private NavigationBelief navigationBelief = new NavigationBelief();

    private Belief[] beliefs;



    public BeliefsManager()
    {
        beliefs = new Belief[] { foodLevelBelief, inventoryBelief, healthLevelBelief, sightBelief, navigationBelief };
    }


	public BeliefsManager BeliefReviewFunction(HumanState humanState) 
	{
        foreach (Belief belief in beliefs)
        {
            belief.ReviewBelief(this, humanState);
        }
        return this;
	}

    public HungerBelief GetFoodLevelBelief()
    {
        return foodLevelBelief;
    }

    public InventoryBelief GetInventoryBelief()
    {
        return inventoryBelief;
    }

    public VitalsBelief GetHealthLevelBelief()
    {
        return healthLevelBelief;
    }

    public SightBelief GetSightBelief()
    {
        return sightBelief;
    }

    public NavigationBelief GetNavigationBelief()
    {
        return navigationBelief;
    }
}

