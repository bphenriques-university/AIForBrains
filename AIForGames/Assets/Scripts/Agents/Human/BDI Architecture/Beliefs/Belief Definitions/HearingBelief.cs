using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HearingBelief : Belief
{

    private GameObject exitHeard;
	private List<HumanHear.MessageLogEntry> MessageLog = new List<HumanHear.MessageLogEntry> ();

	bool needsFood = false;
	bool needsAmmo = false;
	bool grabbed = false;
	bool exitFound = false;


	public void identififyBelief(HumanSpeak.Message m){
		if (m == HumanSpeak.Message.NeedFood) {
			needsFood = true;
		} else if (m == HumanSpeak.Message.NeedAmmo) {
			needsAmmo = true;
		} else if (m == HumanSpeak.Message.IAmGrabbed) {
			grabbed = true;
		} else if (m == HumanSpeak.Message.ExitIsOpen) {
			exitFound = true;
		}
	}

	public bool FoundExitMessage(){
		return exitFound;
	}
	public bool FoodNeededMessage(){
		return needsFood;
	}

	public bool RescueNeededMessage(){
		return grabbed;
	}

	public bool AmmoNeededMessage(){
		return needsAmmo;
	}

    public GameObject GetExit() {
        return exitHeard;
    }



	public IList<HumanHear.MessageLogEntry> GetMessageLog(){
		return MessageLog;
	}

    public override void ReviewBelief(BeliefsManager beliefs, Human human)
    {
		IList<HumanHear.MessageLogEntry> newMessages = human.Sensors.GetHumanMessages();

		while(MessageLog.Count > 5){
			MessageLog.RemoveAt(0);
		}

        exitHeard = human.Sensors.GetExitHeard();

		MessageLog.AddRange (newMessages);
		newMessages.Clear ();

    }
}
