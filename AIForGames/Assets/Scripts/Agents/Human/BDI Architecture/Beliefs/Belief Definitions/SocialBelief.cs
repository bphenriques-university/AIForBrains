using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SocialBelief : Belief
{
	private struct Acquaintance{
		string name;
		int friendshipValue;
		Vector3 lastKnownPosition;

		public Acquaintance(string name, int friendship, Vector3 lastKnownPosition){
			this.name = name;
			this.friendshipValue = friendship;
			this.lastKnownPosition = lastKnownPosition;
		}

		public Acquaintance(HumanState human, int friendshipValue): 
			this(human.name, friendshipValue, human.CurrentPosition().position){}


		public int addToFriendship(int value){
			this.friendshipValue += value;
			return this.friendshipValue;
		}

		public string getName ()
		{
			return this.name;
		}

		public int getFriendshipValue(){
			return this.friendshipValue;
		}

		public Vector3 getLastKnownPosition(){
			return lastKnownPosition;
		}

	}


	Dictionary<string, Acquaintance> Acquaintances;
    
	public SocialBelief(IList<HumanState> friends) : this(){

		AddAcquaintances (friends);

	}

	public SocialBelief(){
		Acquaintances = new Dictionary<string, Acquaintance>();
	}

	public void AddAcquaintances(IList<HumanState> acquaintances){
		foreach (HumanState human in acquaintances) {
			AddAcquaintance(new Acquaintance (human, 0));
		}
	}

	private void AddAcquaintance(Acquaintance relationship){
			this.Acquaintances.Add(relationship.getName(),relationship);
	}

	public void improveRelationShip(HumanState human, int value){
		Acquaintance friendship;
		if (Acquaintances.TryGetValue (human.name, out friendship)) {
			friendship.addToFriendship(value);
		}else{
			AddAcquaintance(new Acquaintance(human, value));
		}
	}


    public override void ReviewBelief(BeliefsManager beliefs, HumanState humanState)
    {
        //TODO:Actualizar Amizades 


        throw new System.NotImplementedException();
    }
}
