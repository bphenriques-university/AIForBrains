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

		public Acquaintance(Human human, int friendshipValue): 
			this(human.name, friendshipValue, human.Sensors.CurrentPosition().position){}


		public int addToFriendship(int value){
			if (this.friendshipValue + value > 100) {
				this.friendshipValue=100;
				return this.friendshipValue;
			}
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
    
	public SocialBelief(IList<Human> friends) {

		AddAcquaintances (friends);

	}

	public SocialBelief() : this(Human.GetHumans ()){
		Acquaintances = new Dictionary<string, Acquaintance>();
	}

	public void AddAcquaintances(IList<Human> acquaintances){
		foreach (Human human in acquaintances) {
			AddAcquaintance(new Acquaintance (human, 0));
		}
	}

	private void AddAcquaintance(Acquaintance relationship){
			this.Acquaintances.Add(relationship.getName(),relationship);
	}

	public void improveRelationShip(Human human, int value){
		Acquaintance friendship;
		if (Acquaintances.TryGetValue (human.name, out friendship)) {
			friendship.addToFriendship(value);
		}else{
			AddAcquaintance(new Acquaintance(human, value));
		}
	}


    public override void ReviewBelief(BeliefsManager beliefs, Human human)
    {
        IList<HumanTrade.Trade> trades = human.Sensors.GetTrades();
        SocialBelief social = beliefs.GetSocialBelief();

        foreach (HumanTrade.Trade trade in trades)
        {
            if (trade.isAmmoTrade())
            {
                //2 points for each ammo given
                social.improveRelationShip(trade.getBenefactor(), trade.getPoints() * 2);
            }
            else if (trade.isFoodTrade())
            {
                social.improveRelationShip(trade.getBenefactor(), trade.getPoints());
            }
        }

        trades.Clear();
	

		
    }
}
