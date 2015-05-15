using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanTrade : MonoBehaviour
{
	public List<Trade> tradeReceived = new List<Trade>();
	private HumanHunger humanHunger;
	private HumanAmmo humanAmmo;

	public abstract class Trade{

		Human human;

		protected int points;
		public Trade(Human human, int points){
			this.human = human;
			this.points = points;
		}
		public virtual bool isFoodTrade(){
			return false;
		}
		public virtual bool isAmmoTrade(){
			return false;
		}
		public int getPoints(){
			return points;
		}
		public Human getBenefactor(){
			return human;
		}
	}

	public class FoodTrade : Trade{
		public FoodTrade(Human human, int points) : base(human, points){}
		public override bool isFoodTrade(){
			return true;
		}
	}

	public class AmmoTrade : Trade{
		public AmmoTrade(Human human, int points) : base(human, points){}
		public override bool isAmmoTrade(){
			return true;
		}
	}

	void Awake ()
	{
		humanHunger = GetComponent <HumanHunger> ();
		humanAmmo = GetComponent<HumanAmmo> ();
	}
	
	public void ReceiveFoodFrom(Human human, Food food){
		
		tradeReceived.Add(new FoodTrade(human, food.foodPoints));
		humanHunger.AddFood (food);
		
	}

	public void ReceiveAmmoFrom(Human human, int bullets){
		
		tradeReceived.Add(new AmmoTrade(human, bullets));
		humanAmmo.AddAmmo (bullets);
		
	}

	public IList<Trade> GetTrades(){
		return tradeReceived;
	}

}

