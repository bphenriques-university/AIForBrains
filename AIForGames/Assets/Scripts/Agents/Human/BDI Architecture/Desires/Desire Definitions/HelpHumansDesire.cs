using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HelpHumansDesire : Desire
{

    public override void Deliberate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        desireLevel = 0f;

		HearingBelief hearing = beliefs.GetHearingBelief ();
		if (hearing.GetMessageLog ().Count > 0) {
            desireLevel = 40f;
		}

        SightBelief sight = beliefs.GetSightBelief();
        MemoryBelief memory = beliefs.GetMemoryBelief();
        if (sight.SawExit() && !memory.SaidExit())
        {
            desireLevel = 100f;
        }
    }

    public override IList<Intention> GenerateIntentions(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
		IList<Intention> desiredIntentions = new List<Intention> ();
		HearingBelief hearing = beliefs.GetHearingBelief ();

		foreach (HumanHear.MessageLogEntry entry in hearing.GetMessageLog()) {
			hearing.identififyBelief (entry.getMessage ());
			InventoryBelief inventoryBelief = beliefs.GetInventoryBelief ();
			if (hearing.FoodNeededMessage ()) {
			IList<Food> foods = inventoryBelief.Foods ();
				if (foods.Count > 0){


					desiredIntentions.Add(new GiveFoodIntention(entry.getHuman().GetComponent<Human>(), desireLevel));

				}
			} else if (hearing.AmmoNeededMessage ()) {
				if (inventoryBelief.AmmoLevel() > 0)
					desiredIntentions.Add(new GiveAmmoIntention(entry.getHuman().GetComponent<Human>(), desireLevel));
			} else if (hearing.RescueNeededMessage ()) {
				desiredIntentions.Add(new RescueHumanIntention(entry.getHuman().GetComponent<Human>(), desireLevel));
			}
		}

        SightBelief sight = beliefs.GetSightBelief();
        MemoryBelief memory = beliefs.GetMemoryBelief();
        if (sight.SawExit() && !memory.SaidExit())
            desiredIntentions.Add(new NotifyExitIntention(desireLevel));

		return desiredIntentions;
	}
}
