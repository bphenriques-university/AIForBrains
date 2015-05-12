using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BeliefsManager : MonoBehaviour 
{

    /* List of possible beliefs */
    private FoodLevelBelief foodLevelBelief = new FoodLevelBelief();



    public void Start()
    {
    }


	public IList<Belief> BeliefReviewFunction(IList<Belief> beliefs) 
	{
		//TODO
		return null;
	}

    public FoodLevelBelief GetFoodLevelBelief()
    {
        return foodLevelBelief;
    }
}

