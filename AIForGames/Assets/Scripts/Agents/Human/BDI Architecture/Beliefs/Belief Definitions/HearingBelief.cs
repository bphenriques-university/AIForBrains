using UnityEngine;
using System.Collections;

public class HearingBelief : MonoBehaviour
{

    private GameObject humanHeard;

	bool needsFood = false;
	bool needsAmmo = false;
	bool grabbed = false;
	bool exitFound = false;

    // Use this for initialization
    void Start()
    {

    }

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

    // Update is called once per frame
    void Update()
    {

    }
}
