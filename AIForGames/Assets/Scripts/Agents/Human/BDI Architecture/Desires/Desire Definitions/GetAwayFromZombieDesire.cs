using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetAwayFromZombieDesire  : Desire
{
	public static float safeDistanceToZombie = 3.5f;
	
	public override void Deliberate(BeliefsManager beliefs, IList<Intention> previousIntentions)
	{

		if(!beliefs.GetSightBelief().SawZombie()){
			desireLevel = 0;
		}
		desireLevel = (beliefs.GetSightBelief ().DistanceToZombie () - safeDistanceToZombie) * 100;
	}
	
	public override IList<Intention> GenerateIntentions(BeliefsManager beliefs, IList<Intention> previousIntentions)
	{
		IList<Intention> desiredIntentions = new List<Intention>();
		
		desiredIntentions.Add (new GetAwayFromZombieIntention(desireLevel, beliefs.GetSightBelief().GetZombieSeen()));
		
		return desiredIntentions;
	}
}

