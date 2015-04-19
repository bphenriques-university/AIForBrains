using UnityEngine;

public class HumanMovement : MonoBehaviour
{

	HumanHealth humanHealth;

	public float runSpeed = 6f;            // The speed that the player will move at.
	public float walkSpeed = 2f;            // The speed that the player will move at.

	bool isGrabbed = false;
	NavMeshAgent nav;
	Animator anim;
	
	
	
	void Awake ()
	{
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		humanHealth = GetComponent<HumanHealth> ();
	}

	void Update ()
	{
		anim.SetBool ("IsWalking", isMoving());
	}
	

	public void Walk() {
		nav.speed = walkSpeed;
		nav.Resume ();
	}

	public void Run() {
		nav.speed = runSpeed;
		nav.Resume ();
	}

	public void Stop() {
		nav.Stop();
	}

	public void ChangeDestination(Vector3 pos){
		nav.SetDestination (pos);
	}

	public bool isMoving() {
		return Vector3.Distance(nav.destination, transform.position) > 1.0;
	}

}