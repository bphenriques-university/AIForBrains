using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DesiresManager{

    private GatherFoodDesire gatherFoodDesire = new GatherFoodDesire();
    private EatFoodDesire eatFoodDesire = new EatFoodDesire();
    private EscapeDesire escapeDesire = new EscapeDesire();
	private GatherAmmunitionDesire gatherAmmoDesire = new GatherAmmunitionDesire ();
	private KeepHealthyDesire keepHealthyDesire = new KeepHealthyDesire ();
    private Desire[] desires;


    public DesiresManager()
    {
        desires = new Desire[] { gatherFoodDesire, eatFoodDesire, escapeDesire, gatherAmmoDesire, keepHealthyDesire };
    }


    public IList<Desire> Options(BeliefsManager beliefs, IList<Intention> intentions)
    {
        IList<Desire> desired = new List<Desire>();
        foreach (Desire desire in desires)
        {
            desire.Deliberate(beliefs, intentions);
            desired.Add(desire);
        }   
        return desired;
    }

}