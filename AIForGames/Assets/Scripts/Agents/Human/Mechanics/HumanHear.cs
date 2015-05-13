using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanHear : MonoBehaviour
{
	IList<MessageLogEntry> MessageLog;
	HumanState humanState;

	public struct MessageLogEntry{
		int humanID;
		float timeHeard;
		HumanSpeak.Message message;

		public HumanSpeak.Message getMessage(){
			return message;
		}

		public float getMessageTime(){
			return timeHeard;
		}

		public int getHumanID(){
			return humanID;
		}

		public MessageLogEntry(int humanID, float timeHeard, HumanSpeak.Message message){
			this.humanID = humanID;
			this.timeHeard = timeHeard;
			this.message = message;
		}
	}


	// Use this for initialization
	void Start ()
	{
		humanState = transform.root.GetComponent <HumanState> ();
		MessageLog = new List<MessageLogEntry> ();
	}


	public void HearMessage(int fromId, HumanSpeak.Message m){
		Debug.Log ("HEARD FROM " + fromId + " " + m.ToString ());
		 
		MessageLog.Add (new MessageLogEntry (fromId, humanState.getHumanTime(), m));

	}

	// Update is called once per frame
	void Update ()
	{
	
	}
}