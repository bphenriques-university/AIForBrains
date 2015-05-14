using UnityEngine;
using System.Collections.Generic;

public partial class Sensors : MonoBehaviour
{

    public int FoodCarried()
    {
        return hunger.GetFoodCarried();
    }


    public IList<Food> FoodsCarried()
    {
        return hunger.foods;
    }

    public int AmmoLevel()
    {
        return shooting.currentAmmo;
    }

	public IList<HumanTrade.Trade> GetTrades(){
		return trade.GetTrades ();
	}

}
