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

    public float AmmoLevel()
    {
        return shooting.currentAmmo;
    }
}
