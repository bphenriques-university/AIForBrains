using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SocialBelief : Belief
{
	private struct Acquaintance{
		Human human;
		int friendshipValue;

		public Acquaintance(Human human, int friendship){
			this.human = human;
			this.friendshipValue = friendship;
		}


		public int addToFriendship(int value){
			if (this.friendshipValue + value > 100) {
				this.friendshipValue=100;
				return this.friendshipValue;
			}
			this.friendshipValue += value;
			return this.friendshipValue;
		}

		public Human getHuman ()
		{
			return this.human;
		}

		public int getFriendshipValue(){
			return this.friendshipValue;
		}

	}


	IList<Acquaintance> Acquaintances;
    

	public SocialBelief(){
		Acquaintances = new List<Acquaintance>();
		AddAcquaintances (Human.GetHumans ());
	}

	public void AddAcquaintances(IList<Human> acquaintances){
		foreach (Human human in acquaintances) {
			AddAcquaintance(new Acquaintance (human, 0));
		}
	}

	private void AddAcquaintance(Acquaintance relationship){
			this.Acquaintances.Add(relationship);
	}

	public void improveRelationShip(Human human, int value){
		Acquaintance friendship;
		foreach (Acquaintance friend in Acquaintances) {
			if(human.Equals(friend.getHuman())){
				friend.addToFriendship(value);
				return;
			}
		
		}

		AddAcquaintance(new Acquaintance(human, value));

	}


    public override void ReviewBelief(BeliefsManager beliefs, Human human)
    {
        IList<Trade> trades = human.Sensors.GetTrades();
        SocialBelief social = beliefs.GetSocialBelief();

        foreach (Trade trade in trades)
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
