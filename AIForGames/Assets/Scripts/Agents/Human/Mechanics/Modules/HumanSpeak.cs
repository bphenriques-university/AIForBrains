using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HumanSpeak : MonoBehaviour
{
    Human human;
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
        human = GetComponentInParent<Human>();
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

	public void SendMessageToAllHumans(Message m){

        foreach (Human recipient in Human.GetHumans()) {
            if (recipient.Equals(human))
                continue;
            HumanHear hearing = recipient.GetComponentInChildren<HumanHear>();
			hearing.HearMessage(this.transform.root.gameObject, m);
		}
	}


    public void SendExitToAllHumans(GameObject exit)
    {
        foreach (Human recipient in Human.GetHumans())
        {
            if (recipient.Equals(human))
                continue;
            //supposed to send a human game object
            if (recipient != null)
            {
                HumanHear hear = recipient.GetComponentInChildren<HumanHear>();
                if (hear != null)
                    hear.HearExit(transform.root.gameObject, exit);
            }
        }
    }
}