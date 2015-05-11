using UnityEngine;
using System.Collections.Generic;

public abstract class Belief
{

	private bool isInBelief;
	private Object beliefValue;

	public abstract bool EvaluateBelief (IList<Belief> beliefs, HumanState humanState);

	public Object GetBeliefValue () {
		return beliefValue;
	}
}

