using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanTrade : MonoBehaviour
{
	public List<Trade> tradeReceived = new List<Trade>();
	private HumanHunger humanHunger;
	private HumanAmmo humanAmmo;
	

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

