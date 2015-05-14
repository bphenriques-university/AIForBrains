using UnityEngine;
using System.Collections;

public class EatFoodPlanComponent : PlanComponent
{
    private Food foodToBeEaten;

    public EatFoodPlanComponent(Human humanState, Food foodToBeEaten) : base(humanState)
    {
        this.foodToBeEaten = foodToBeEaten;
    }

    public override bool TryExecuteAction()
    {
        float oldFoodLevel = humanState.HungerLevel();
        humanState.Actuators.EatFood(foodToBeEaten);
        return humanState.HungerLevel() > oldFoodLevel;
    }
}
