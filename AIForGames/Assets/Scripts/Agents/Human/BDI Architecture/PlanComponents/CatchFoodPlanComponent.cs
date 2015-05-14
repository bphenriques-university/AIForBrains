using UnityEngine;
using System.Collections;

public class CatchFoodPlanComponent : PlanComponent
{

    private Food foodToBeCaught;

    public CatchFoodPlanComponent(Human human, Food foodToBeCaught)
        : base(human)
    {
        this.foodToBeCaught = foodToBeCaught;
    }


    public override bool TryExecuteAction()
    {
        human.Actuators.CatchFood(foodToBeCaught);
        return human.Sensors.FoodsCarried().Contains(foodToBeCaught);
    }
}
