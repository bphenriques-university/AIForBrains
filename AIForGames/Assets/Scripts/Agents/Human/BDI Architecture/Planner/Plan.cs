using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Plan
{
    private IList<PlanComponent> planComponents;

    public Plan(IList<PlanComponent> planComponents)
    {
        this.planComponents = planComponents;
    }

    public bool MakesSense(HumanState beliefs, IList<Intention> intentions)
    {
        //TODO
        return true;
    }

    public int Count()
    {
        return planComponents.Count;
    }

    public PlanComponent Head()
    {
        PlanComponent component = planComponents[0];
        return component;
    }

    public void Pop()
    {
        planComponents.Remove(planComponents[0]);
    }

    //succeded(I, B)
   

    //reconsider (I, B)
    
}
