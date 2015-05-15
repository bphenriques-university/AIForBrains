using UnityEngine;
using System.Collections.Generic;

public partial class Sensors : MonoBehaviour{
	
	public IList<HumanHear.MessageLogEntry> GetHumanMessages(){
		return hearing.GetMessageLog();
	}
	

}