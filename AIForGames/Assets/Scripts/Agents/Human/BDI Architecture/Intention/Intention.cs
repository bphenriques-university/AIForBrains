using UnityEngine;
using System.Collections;
using System.Collections.Generic;



/*enum Intention{
	Aim,
	Attack,
	CatchAmmo,
	CatchFood,
	HeardCryForHelp,
	EatFood,
	FetchFood,
	PickupAmmo,
	WalkAround,
	Shoot,
	GoToExit,
	GiveAmmo,
	GiveFood // ????
} */


public abstract class Intention {

    protected float intentValue = 0f;
    protected float desiredIntentValue = 0f;
    protected int desiredIntentionNumber = 1;

	public abstract bool Succeeded ();
	public abstract bool IsImpossible();

    public Intention(float desiredIntentValue)
    {
        this.desiredIntentValue = desiredIntentValue;
    }

    public float IntentValue()
    {
        return intentValue + desiredIntentValue;
    }

    public void IncreaseIntentionNumber(float intentionValue)
    {
        desiredIntentionNumber++;
        desiredIntentValue += desiredIntentValue / desiredIntentionNumber;
    }

    /**
     *  Evaluate
     *  Returns a boolean stating if the intent is still possible and
     *  calculates intentValue.
     **/
    public abstract bool Evaluate(BeliefsManager beliefs, IList<Intention> previousIntentions);
}