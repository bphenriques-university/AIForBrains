using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeepHealthyDesire : Desire
{
	public static float safeDistanceToZombie = 3.5f;

    public override void Deliberate(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
    {
		VitalsBelief belief = beliefs.GetVitalsBelief ();
		desireLevel = belief.GetMaxHealthLevel() - belief.GetHealthLevel();
    }

    public override System.Collections.Generic.IList<Intention> GenerateIntentions(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
    {
		IList<Intention> desiredIntentions = new List<Intention>();

		int nZombiesSeen = beliefs.GetSightBelief ().ZombieSeen ().Count;
		int nBullets = beliefs.GetInventoryBelief ().AmmoLevel ();

        if (beliefs.GetVitalsBelief().IsGrabbed()) {

            desiredIntentions.Add(new CallForHelpIntention(HumanSpeak.Message.IAmGrabbed, desireLevel));
        }

		if (nZombiesSeen > 0) {
			GameObject zombie = beliefs.GetSightBelief ().GetClosestZombie ();

			if (nBullets > 0) {

				Intention zombieIntention = new KillZombieIntention (zombie, this.desireLevel);
				desiredIntentions.Add (zombieIntention);
			
			}


			Intention runIntention = new GetAwayFromZombieIntention (zombie, this.desireLevel);
			desiredIntentions.Add (runIntention);
		}

		return desiredIntentions;

    }
}
