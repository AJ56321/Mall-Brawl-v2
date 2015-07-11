using UnityEngine;
using System.Collections;

public class BatonAttack : MonoBehaviour {
	public float batonDamage = 10f;
	public GameObject hitter;
	public float damageDelay  = 5.0f;
	private bool attacking = false;
	private int count = 0;

	EnemyHealth enemyHealth;                    // Reference to this enemy's health.
	PlayerAttack playerAttack;

	//bool hitPressed = false;
	
	void Awake ()
	{

		hitter.GetComponent<Collider2D>().enabled = false;
		// Setting up the references.
		//enemyHealth = GetComponent<EnemyHealth>();
		
	}

	IEnumerator attack (){
		count = 0;
		attacking = true;
		hitter.GetComponent<Collider2D>().enabled = true;
		yield return new WaitForSeconds (damageDelay);
		hitter.GetComponent<Collider2D>().enabled = false;
		attacking = false;
		}

	void Update (){
		if (Input.GetKey(KeyCode.F) && attacking == false){
			StartCoroutine(attack());
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if((other.gameObject.tag == "Enemy" && count == 0))
		{
			enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
			//APPLYING DAMAGE TO ENEMY
			enemyHealth.TakeDamage(batonDamage);
			count++;

			GetComponent<AudioSource>().Play();

		}

	}
	void OnTriggerEnter2D(Collider2D other){
		if((other.gameObject.tag == "Enemy" && count == 0))
		{
			enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
			//APPLYING DAMAGE TO ENEMY
			enemyHealth.TakeDamage(batonDamage);
			count++;
			
			GetComponent<AudioSource>().Play();
			
		}
		
	}
}
