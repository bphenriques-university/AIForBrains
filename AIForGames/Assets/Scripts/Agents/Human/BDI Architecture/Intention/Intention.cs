using UnityEngine;
using System.Collections;



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


public abstract class Intention : MonoBehaviour
{
	public HumanState humanState;

	void Start(){
		humanState = this.transform.root.GetComponent<HumanState> ();
	}

	public abstract bool Succeeded ();

	public abstract bool IsImpossible();


}