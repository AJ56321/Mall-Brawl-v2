using UnityEngine;
using System.Collections;
using SmoothMoves;

public class PlayerHealth : MonoBehaviour
{
	public BoneAnimation player;
	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;
	public AudioClip ouch;
	//public AudioClip ouch;

	
	CharacterController2D playerMovement;                       // Reference to the player's movement.
	bool isDead;                                                // Whether the player is dead.
	
	void Awake ()
	{
		// Setting up the references.
		playerMovement = GetComponent <CharacterController2D> ();

		
		// Set the initial health of the player.
		currentHealth = startingHealth;
	}

	IEnumerator dying(){
		player.Play (3);
		playerMovement.enabled = false;
		yield return new WaitForSeconds (500);
		Application.LoadLevel("LoseMenu");
	}
	
	public void TakeDamage (int amount)
	{
		// Reduce the current health by the damage amount.
		currentHealth -= amount;
		GetComponent<AudioSource>().PlayOneShot(ouch, 0.7F);

		//audio.PlayOneShot (ouch, 0.7F);
		
		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 0 && !isDead)
		{
			// ... it should die.
			Death ();
		}
	}
	
	
	void Death ()
	{
		// Set the death flag so this function won't be called again.
		isDead = true;
		StartCoroutine (dying ());
		// Turn off the movement and shooting scripts.



	}       
}
