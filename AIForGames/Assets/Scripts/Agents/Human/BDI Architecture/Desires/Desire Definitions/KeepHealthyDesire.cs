using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeepHealthyDesire : Desire
{

    public override void Deliberate(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
    {
		VitalsBelief belief = beliefs.GetVitalsBelief ();
		desireLevel = belief.GetMaxHealthLevel() - belief.GetHealthLevel();
    }

    public override System.Collections.Generic.IList<Intention> GenerateIntentions(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
    {
		IList<Intention> desiredIntentions = new List<Intention>();

		int nZombiesSeen = 0;//TODO:substituir por linha adequada dos beliefs
		int nBullets = 0;//TODO:substituir por beliefs decentes


		GameObject zombie = null;//beliefs.GetSightBelief ().getClosestZombie ();
		float distanceToZombie = 0f/*getDistance*/ /10;

		if (nBullets > 0) {
			float killZombieIntentionLevel = desireLevel + nBullets * 3;
			Intention zombieIntention = new KillZombieIntention (zombie, killZombieIntentionLevel);
			desiredIntentions.Add(zombieIntention);
		}


		float runIntentionLevel = desireLevel + nZombiesSeen * 10 + 1 / distanceToZombie;
		Intention runIntention = new GetAwayFromZombieIntention(runIntentionLevel,  zombie);
		desiredIntentions.Add (runIntention);


		return desiredIntentions;

    }
}
