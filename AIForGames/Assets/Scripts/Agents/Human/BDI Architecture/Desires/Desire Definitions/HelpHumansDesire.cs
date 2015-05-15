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
					if(desireLevel < 60)
						desireLevel = 60;
				}else if(hearing.AmmoNeededMessage()){
					if(desireLevel < 60)
						desireLevel = 60;
				}else if(hearing.RescueNeededMessage()){
					if(desireLevel < 60)
						desireLevel = 60;
				}else if(hearing.FoundExitMessage()){
					desireLevel = 70;
				}

			}

		}
    }

    public override System.Collections.Generic.IList<Intention> GenerateIntentions(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
    {
		IList<Intention> desiredIntentions = new List<Intention> ();

		int a;

		HearingBelief hearing = beliefs.GetHearingBelief ();
		foreach (HumanHear.MessageLogEntry entry in hearing.GetMessageLog()) {
			hearing.identififyBelief (entry.getMessage ());
			
			if (hearing.FoodNeededMessage ()) {
				IList<Food> foods = beliefs.GetInventoryBelief ().Foods ();
				if (foods.Count > 0)
					a = 2 + 2;//desiredIntentions.Add(new GiveFoodIntention(
			} else if (hearing.AmmoNeededMessage ()) {
				if (desireLevel < 60)
					desireLevel = 60;
			} else if (hearing.RescueNeededMessage ()) {
				if (desireLevel < 60)
					desireLevel = 60;
			} else if (hearing.FoundExitMessage ()) {
				desireLevel = 70;
			}
		}

		return desiredIntentions;
	}
}
