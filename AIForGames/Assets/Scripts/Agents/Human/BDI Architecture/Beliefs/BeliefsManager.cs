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
	private SocialBelief socialBelief = new SocialBelief();
	private HearingBelief hearingBelief = new HearingBelief();
    private TouchBelief touchBelief = new TouchBelief();
    private NavigationBelief navigationBelief;
    private MemoryBelief memoryBelief;

    private Belief[] beliefs;



    public BeliefsManager(NavMap humanNavMap, Collider meshCollider)
    {
        navigationBelief = new NavigationBelief(humanNavMap);
        memoryBelief = new MemoryBelief(meshCollider);
        beliefs = new Belief[] { foodLevelBelief, inventoryBelief, healthLevelBelief, 
            sightBelief, navigationBelief, socialBelief, hearingBelief, memoryBelief, touchBelief };

    }


	public BeliefsManager BeliefReviewFunction(Human human) 
	{
        foreach (Belief belief in beliefs)
        {
            belief.ReviewBelief(this, human);
        }
        return this;
	}

    public bool CheckImportantBeliefs()
    {
        return GetSightBelief().SawAmmo() || GetSightBelief().SawFood() || 
            GetSightBelief().SawZombie() || GetSightBelief().SawHuman();
    }

    public HungerBelief GetHungerBelief()
    {
        return foodLevelBelief;
    }

    public InventoryBelief GetInventoryBelief()
    {
        return inventoryBelief;
    }

    public VitalsBelief GetVitalsBelief()
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

    public SocialBelief GetSocialBelief()
    {
		return socialBelief;
    }

	public HearingBelief GetHearingBelief ()
	{
		return hearingBelief;
	}

    public MemoryBelief GetMemoryBelief()
    {
        return memoryBelief;
    }

    public TouchBelief GetTouchBelief()
    {
        return touchBelief;
    }
}

