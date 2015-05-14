using UnityEngine;
using System.Collections;

public class VitalsBelief : Belief 
{
    private float healthLevel;
    private bool isGrabbed;

    public override void ReviewBelief(BeliefsManager beliefs, Human humanState)
    {
        healthLevel = humanState.HealthLevel();
        isGrabbed = humanState.IsGrabbed();
    }


    public float GetHealthLevel()
    {
        return healthLevel;
    }

    public bool IsGrabbed()
    {
        return isGrabbed;
    }
}

