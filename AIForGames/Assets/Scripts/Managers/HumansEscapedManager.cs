using UnityEngine;

public class HumansEscapedManager : MonoBehaviour
{
	public float restartDelay = 15f;         // Time to wait before restarting the level
	
	
	Animator anim;                          // Reference to the animator component.
	float restartTimer;                     // Timer to count up to restarting the level
	AudioSource audioSource;                      // Reference to the AudioSource component.

	bool gameWon = false;
	
	
	void Awake ()
	{
		// Set up the reference.
		anim = GetComponent <Animator> ();
		audioSource = GetComponent <AudioSource> ();
	}
	
	
	void Update ()
	{
		GameObject[] humans = GameObject.FindGameObjectsWithTag ("Human");
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		if (humans.Length + player.Length <= 0) {
			if (!gameWon) {
				anim.SetTrigger ("HumansEscaped");
				audioSource.Play();
				gameWon = true;
			}

			restartTimer += Time.deltaTime;
			
			if(restartTimer >= restartDelay)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}