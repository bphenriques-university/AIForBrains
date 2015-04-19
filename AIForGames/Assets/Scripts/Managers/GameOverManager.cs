using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
	public float restartDelay = 15f;         // Time to wait before restarting the level
	public static int humansAlive = 0;
	public static int zombiesAlive = 0;	

	Animator anim;                          // Reference to the animator component.
	float restartTimer;                     // Timer to count up to restarting the level


	public Text humansAliveText;
	public Text zombiesAliveText;
	
	void Awake ()
	{
		anim = GetComponent <Animator> ();
	}
	
	
	void Update ()
	{

		humansAliveText.text = "Humans: " + humansAlive;
		zombiesAliveText.text = "Zombies: " + zombiesAlive;

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