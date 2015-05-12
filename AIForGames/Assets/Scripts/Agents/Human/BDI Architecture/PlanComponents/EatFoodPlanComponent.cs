using UnityEngine;
using System.Collections;

public class EatFoodPlanComponent : PlanComponent
{
    private Food foodToBeEaten;

    public EatFoodPlanComponent(HumanState humanState, Food foodToBeEaten) : base(humanState)
    {
        this.foodToBeEaten = foodToBeEaten;
    }

    public override bool TryExecuteAction()
    {
        float oldFoodLevel = humanState.HungerLevel();
        humanState.actuator.EatFood(foodToBeEaten);
        return humanState.HungerLevel() > oldFoodLevel;
    }
}
