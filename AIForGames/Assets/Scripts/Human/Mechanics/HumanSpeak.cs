using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HumanSpeak : MonoBehaviour
{	
	private int myId;
	Dictionary<int, HumanHear> humansInRange = new Dictionary<int, HumanHear>();

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
		foreach (KeyValuePair<int, HumanHear> pair in humansInRange) {
			pair.Value.HearMessage(myId, m);
		}
	}

	// Use this for initialization


	
	// Update is called once per frame
	void Update ()
	{
	
	}
}