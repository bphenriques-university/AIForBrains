using UnityEngine;
using System.Collections;

public class CatchFoodPlanComponent : PlanComponent
{

    private Food foodToBeCaught;

    public CatchFoodPlanComponent(HumanState humanState, Food foodToBeCaught)
        : base(humanState)
    {
        this.foodToBeCaught = foodToBeCaught;
    }


    public override bool TryExecuteAction()
    {
        humanState.actuator.CatchFood(foodToBeCaught);
        return humanState.FoodsCarried().Contains(foodToBeCaught);
    }
}
