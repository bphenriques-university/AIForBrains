using UnityEngine;
using System.Collections;

public class HearingBelief : Belief
{

    private GameObject humanHeard;

	bool needsFood = false;
	bool needsAmmo = false;
	bool grabbed = false;
	bool exitFound = false;


	void identififyBelief(HumanSpeak.Message m){
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

    public override void ReviewBelief(BeliefsManager beliefs, Human human)
    {
        throw new System.NotImplementedException();
    }
}
