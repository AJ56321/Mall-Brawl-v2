using UnityEngine;
using System.Collections;

public class EnemyBat : MonoBehaviour {


	public int batonDamage = 10;
	PlayerHealth playerHealth;
	private bool attacking = false;
	//private float health = playerHealth.health;

	IEnumerator attack (){
		//count = 0;
		attacking = true;
		yield return new WaitForSeconds (.5f);
		attacking = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if((other.gameObject.tag == "Player" && attacking == false))
		{
			playerHealth = other.gameObject.GetComponent<PlayerHealth>();
			playerHealth.TakeDamage(batonDamage);
			StartCoroutine(attack());
		}
		
	}
}
