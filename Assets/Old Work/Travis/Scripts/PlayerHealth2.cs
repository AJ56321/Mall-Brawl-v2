using UnityEngine;
using System.Collections;
using SmoothMoves;

public class PlayerHealth2 : MonoBehaviour {

	public float hp = 100f;
	public float damage = 20f;

	
	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag=="Enemy"){
			hp -= damage;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hp<=0){
			Destroy(gameObject);
		}
	}
}