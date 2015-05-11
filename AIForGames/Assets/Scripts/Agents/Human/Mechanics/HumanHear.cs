using UnityEngine;
using System.Collections;

public class HumanHear : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}

	public void HearMessage(int fromId, HumanSpeak.Message m){
		Debug.Log ("HEARD FROM " + fromId + " " + m.ToString ());
	}

	// Update is called once per frame
	void Update ()
	{
	
	}
}