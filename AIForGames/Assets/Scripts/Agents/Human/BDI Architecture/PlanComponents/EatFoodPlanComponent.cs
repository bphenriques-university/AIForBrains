using UnityEngine;
using System.Collections;

public class EatFoodPlanComponent : PlanComponent
{
    private Food foodToBeEaten;

    public EatFoodPlanComponent(Human human, Food foodToBeEaten) : base(human)
    {
        this.foodToBeEaten = foodToBeEaten;
    }

    public override bool TryExecuteAction()
    {
        float oldFoodLevel = human.Sensors.HungerLevel();
        human.Actuators.EatFood(foodToBeEaten);
        return human.Sensors.HungerLevel() > oldFoodLevel;
    }
}
