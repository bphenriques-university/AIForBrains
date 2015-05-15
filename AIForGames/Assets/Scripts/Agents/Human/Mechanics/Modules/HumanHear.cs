using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanHear : MonoBehaviour
{
	IList<MessageLogEntry> MessageLog = new List<MessageLogEntry> ();
    public GameObject exit;

	public struct MessageLogEntry{
		GameObject human;
		HumanSpeak.Message message;

		public HumanSpeak.Message getMessage(){
			return message;
		}
		
		public GameObject getHuman(){
			return human;
		}

		public MessageLogEntry(GameObject human, HumanSpeak.Message message){
			this.human = human;
			this.message = message;
		}
	}


	public IList<MessageLogEntry> GetMessageLog(){
		return MessageLog;
	}

	public void HearMessage(GameObject human, HumanSpeak.Message m){
        //Debug.Log ("HEARD FROM " + human + " " + m.ToString ());
        MessageLog.Add (new MessageLogEntry (human, m));

	}


    public void HearExit(GameObject human, GameObject exit)
    {

        Debug.Log("Heard Exit Location.");
        MessageLog.Add(new MessageLogEntry(human, HumanSpeak.Message.ExitIsOpen));
        this.exit = exit;
    }
}