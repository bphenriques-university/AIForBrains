using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HelpHumansDesire : Desire
{

    public override void Deliberate(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
    {
		HearingBelief hearing = beliefs.GetHearingBelief ();
		if (hearing.GetMessageLog ().Count > 0) {

			foreach(HumanHear.MessageLogEntry entry in hearing.GetMessageLog()){
				hearing.identififyBelief(entry.getMessage());

				if(hearing.FoodNeededMessage()){
					if(desireLevel < 40)
						desireLevel = 40;
				}else if(hearing.AmmoNeededMessage()){
					if(desireLevel < 40)
						desireLevel = 40;
				}else if(hearing.RescueNeededMessage()){
					if(desireLevel < 40)
						desireLevel = 40;
				}

			}

		}
    }

    public override System.Collections.Generic.IList<Intention> GenerateIntentions(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
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
				desiredIntentions.Add(new KillZombieIntention(entry.getHuman().GetComponent<Human>(), desireLevel));
			}
		}

		return desiredIntentions;
	}
}
