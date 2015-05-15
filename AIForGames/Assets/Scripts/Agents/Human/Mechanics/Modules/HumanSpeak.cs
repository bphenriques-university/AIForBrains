using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HumanSpeak : MonoBehaviour
{	
	private int myId;
	Dictionary<int, HumanHear> humansInRange = new Dictionary<int, HumanHear>();

    public bool SaidExit = false;

	public enum Message{
		NeedFood,
		NeedAmmo,
		IAmGrabbed,
		ExitIsOpen
	}

	void Start ()
	{
		myId = this.gameObject.GetInstanceID ();	
	}

	void OnTriggerEnter (Collider other){	

		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Human") {
			//Debug.Log("HEARING ON RANGE");
			HumanHear hearing = other.gameObject.GetComponentInChildren<HumanHear>();
			if(hearing != null){
				humansInRange.Add(other.gameObject.GetInstanceID (), hearing);
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Human")
		{
			//Debug.Log("HEARING OUT RANGE");
			humansInRange.Remove(other.gameObject.GetInstanceID());
		}
	}

	public void SendMessageToHumansNearby(Message m){

        foreach (Human recipient in Human.GetHumans()) {
            HumanHear hearing = recipient.GetComponentInChildren<HumanHear>();
			hearing.HearMessage(this.transform.root.gameObject, m);
		}
	}


    public void SendExitToAllHumans(GameObject exit)
    {
        foreach (KeyValuePair<int, HumanHear> pair in humansInRange)
        {
            //supposed to send a human game object
            pair.Value.HearExit(this.transform.root.gameObject, exit);
        }
    }
}