using UnityEngine;
using System.Collections;
using SmoothMoves;

using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour {

	public BoneAnimation enemy;
	private Transform player;//set target from inspector instead of looking in Update
	private Transform target;
	public float speed = 8.0f;
	public float attackDistance = 40f;
	private bool isAttacking = false;
	//public GameObject hitter;
	public float damageDelay  = 1.0f;
	private bool flipping = false;
	
	void Start () {
		player = GameObject.FindWithTag ("Player").transform;
	}

	void OnTriggerEnter2D(Collider2D other){
		if ((other.gameObject.tag == "Wall" || other.gameObject.tag == "Enemy") && (this.isAttacking == false)){
			if(flipping==false){
				StartCoroutine(flipper());
			}
		}

	}

	IEnumerator flipper (){
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		speed *= -1;
		flipping = true;
		yield return new WaitForSeconds (0.1f);
		flipping = false;
	}

	void Update(){
		player = GameObject.FindWithTag ("Player").transform;
		target = player;
		//Sets y direction to the enemies current
		gameObject.transform.position.y.Equals (target.transform.position.y);
		//move towards the player
		/*
		if ((Vector2.Distance(transform.position,target.position)>attackDistance)&&(isAttacking == false)){//move if distance from target is greater than 1
			transform.Translate(new Vector2(speed* Time.deltaTime,0) );
			enemy.Play(0); //Walk
		}*/

		/*
		if((transform.position.x>=target.position.x) && (target.localScale.x<0) && (transform.localScale.x<0) && (Vector2.Distance(transform.position,target.position)<=attackDistance)) {
			isAttacking = true;
			if(enemy.IsPlaying("attack") == false){
				isAttacking = false;
				enemy.Play(2); //Attack
			}
		}
		if(transform.position.x<=target.position.x && (transform.localScale.x>0) && (target.localScale.x>0) && (Vector2.Distance(transform.position,target.position)<=attackDistance)){
			isAttacking = true;
			if(enemy.IsPlaying("attack") == false){
				isAttacking = false;
				enemy.Play(2); //Attack
			}
		}*/
		if ((transform.localScale.x>0) && (transform.position.x>=target.position.x) && (Vector2.Distance(transform.position,target.position)<=attackDistance)){
			//transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
			StartCoroutine(flipper ());
		}
		if ((transform.localScale.x<0) && (transform.position.x<=target.position.x) && (Vector2.Distance(transform.position,target.position)<=attackDistance)){
			//transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
			StartCoroutine(flipper ());
		}

		if (Vector2.Distance(transform.position,target.position)<=attackDistance){
				isAttacking = true;
				if(enemy.IsPlaying("attack") == false){
					isAttacking = false;
					enemy.Play(2); //Attack
			}
		}
		if (Vector2.Distance(transform.position,target.position)>attackDistance){
			isAttacking = false;
			transform.Translate(new Vector2(speed* Time.deltaTime,0) );
			enemy.Play(0);
		}
	}
}