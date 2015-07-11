using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int score = 0;
	public float startingHealth = 40;		// Amount of health the enemy starts the game with
	public int scoreValue = 10;				// The amount added to the player's score when the enemy dies
	public int taserDamage = 15;
	public AdvancedAI script;
	

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Bullet") {
			Destroy (other.gameObject);
			GetComponent<AudioSource>().Play();
			TakeDamage(taserDamage);
		}
	}

	public void TakeDamage (float amount) {

		// Reduce the current health by the amount of damage taken
		startingHealth -= amount;
		score += scoreValue;

		// If the current health is less than or equal to zero...
		if (startingHealth <= 0) {
			// ... the enemy is dead
			Death();
		}
	
	}

	void Death () {
		// The enemy is dead
		script.dead = true;

		// Tel the animator that the enemy is dead. (Ryan, you may have use for this)
		// anim.SetTrigger ("Dead")
	}

}
