using UnityEngine;

public class HumansEscapedManager : MonoBehaviour
{
	public float restartDelay = 5f;         // Time to wait before restarting the level
	
	
	Animator anim;                          // Reference to the animator component.
	float restartTimer;                     // Timer to count up to restarting the level
	AudioSource audio;                      // Reference to the AudioSource component.

	bool gameWon = false;
	
	
	void Awake ()
	{
		// Set up the reference.
		anim = GetComponent <Animator> ();
		audio = GetComponent <AudioSource> ();
	}
	
	
	void Update ()
	{
		GameObject[] humans = GameObject.FindGameObjectsWithTag ("Human");
		if (humans.Length <= 0) {
			if (!gameWon) {
				anim.SetTrigger ("HumansEscaped");
				audio.Play();
				gameWon = true;
			}


			// .. increment a timer to count up to restarting.
			restartTimer += Time.deltaTime;
			
			// .. if it reaches the restart delay...
			if(restartTimer >= restartDelay)
			{
				// .. then reload the currently loaded level.
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}