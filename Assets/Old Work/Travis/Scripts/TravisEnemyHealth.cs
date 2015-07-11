using UnityEngine;
using System.Collections;

public class TravisEnemyHealth : MonoBehaviour {
	public float hp = 100f;
	public float damage = 20f;
	//GameObject bat = GameObject.FindGameObjectWithTag("playerHit");

	//void Start(){

	//}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Player") {
			//GameObject bat = GameObject.FindGameObjectWithTag("playerHit");
			//if(other.gameObject.tag == "playerHit"){
					hp -= damage;
			//}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hp<=0){
			Destroy(gameObject);
		}
	}
}
