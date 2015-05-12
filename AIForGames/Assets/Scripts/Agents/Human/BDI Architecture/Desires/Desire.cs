using UnityEngine;
using System.Collections.Generic;

public abstract class Desire
{
    protected float desireLevel = 0f;

    /**
     * Deliberates if this desire is desired or not, dependent on beliefs and previous intentions.
     **/
    public abstract void Deliberate(BeliefsManager beliefs, IList<Intention> previousIntentions);
    public abstract IList<Intention> GenerateIntentions(BeliefsManager beliefs, IList<Intention> previousIntentions);

    public float getDesireLevel()
    {
        return desireLevel;
    }

}
