using UnityEngine;
using System.Collections;

public class VitalsBelief : Belief 
{
	private int maxHealthLevel;
    private int healthLevel;
    private bool isGrabbed;

    public override void ReviewBelief(BeliefsManager beliefs, Human human)
    {
        healthLevel = human.Sensors.HealthLevel();
        isGrabbed = human.Sensors.IsGrabbed();
		maxHealthLevel = human.Sensors.MaxHealthLevel ();
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

