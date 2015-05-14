using UnityEngine;
using System.Collections;

public class VitalsBelief : Belief 
{
	private int maxHealthLevel;
    private int healthLevel;
    private bool isGrabbed;

    public override void ReviewBelief(BeliefsManager beliefs, Human humanState)
    {
        healthLevel = humanState.HealthLevel();
        isGrabbed = humanState.IsGrabbed();
		maxHealthLevel = humanState.MaxHealthLevel ();
	}


    public int GetHealthLevel()
    {
        return healthLevel;
    }

	public int GetMaxHealthLevel(){
		return maxHealthLevel;
	}

    public bool IsGrabbed()
    {
        return isGrabbed;
    }
}

