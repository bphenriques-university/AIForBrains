using UnityEngine;

public class GameOverManager : MonoBehaviour
{
	public float restartDelay = 15f;         // Time to wait before restarting the level
	public static int humansAlive = 0;
	
	Animator anim;                          // Reference to the animator component.
	float restartTimer;                     // Timer to count up to restarting the level
	
	
	void Awake ()
	{
		anim = GetComponent <Animator> ();
	}
	
	
	void Update ()
	{
		if(humansAlive <= 0)
		{
			anim.SetTrigger ("GameOver");
			
			restartTimer += Time.deltaTime;
			
			if(restartTimer >= restartDelay)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}