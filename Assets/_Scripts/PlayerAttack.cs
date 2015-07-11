using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public float batonDamage = 10f;
	public float taseDamage = 20f;
	public float pepDamage = 30f;

	/*void OnTriggerEnter2D(Collider2D other){
		if(   (other.gameObject.tag == "Enemy")&&(Input.GetKeyDown(KeyCode.F))   )
		{
			//Getting the enemy's health script
			EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
			//APPLYING DAMAGE TO ENEMY
			enemyHealth.TakeDamage(batonDamage);
		}
	}
	*/
}
