using UnityEngine;
using System.Collections;
using SmoothMoves;

using UnityEngine;
using System.Collections;

public class AdvancedAI : MonoBehaviour {
	
	public BoneAnimation enemy;
	private Transform player;//set target from inspector instead of looking in Update
	private Transform target;
	public float speed = 8.0f;
	public float attackDistance = 40f;
	public float watchDistance = 100f;
	public float chaseDistance = 70f;
	private bool isAttacking = false;
	//public GameObject hitter;
	public float damageDelay  = 1.0f;
	private bool flipping = false;
	public bool deadCheck = false;
	public bool hieghtCheck;
	public float hieghtLimit = 20f;
	public bool dead = false;
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
		if (!dead) {
						player = GameObject.FindWithTag ("Player").transform;
						target = player;
		
						if (Mathf.Abs (transform.position.y - target.transform.position.y) <= hieghtLimit) {
								hieghtCheck = true;
						} else if (Mathf.Abs (transform.position.y - target.transform.position.y) > hieghtLimit) {
								hieghtCheck = false;
						}

						if ((transform.localScale.x > 0) && (transform.position.x >= target.position.x) && (Vector2.Distance (transform.position, target.position) <= attackDistance)) {
								//transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
								StartCoroutine (flipper ());
						}
						if ((transform.localScale.x < 0) && (transform.position.x <= target.position.x) && (Vector2.Distance (transform.position, target.position) <= attackDistance)) {
								//transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
								StartCoroutine (flipper ());
						}
			
						if ((Vector2.Distance (transform.position, target.position) <= attackDistance) && (hieghtCheck)) {
								isAttacking = true;
								if (enemy.IsPlaying ("attack") == false) {
										isAttacking = false;
										enemy.Play (2); //Attack
								}
						}
						if ((Vector2.Distance (transform.position, target.position) > attackDistance) && ((Vector2.Distance (transform.position, target.position) > watchDistance) || !hieghtCheck)) {
								isAttacking = false;
								transform.Translate (new Vector2 (speed * Time.deltaTime, 0));
								enemy.Play (0);
						}
						if ((Vector2.Distance (transform.position, target.position) > attackDistance) && (Vector2.Distance (transform.position, target.position) < watchDistance) && hieghtCheck) {
								isAttacking = false;
								if (Vector2.Distance (transform.position, target.position) <= chaseDistance) {
										if ((target.position.x < transform.position.x) && (transform.localScale.x > 0) && hieghtCheck) {
												transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
												speed *= -1;
										}
										if ((target.position.x > transform.position.x) && (transform.localScale.x < 0) && hieghtCheck) {
												transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
												speed *= -1;
										}
										enemy.Play (0);
										transform.Translate (new Vector2 (speed * Time.deltaTime, 0));
								} else if (Vector2.Distance (transform.position, target.position) > chaseDistance) {
										enemy.Play (1);
								}
						}
				} 
		else if (dead) 
		{
			if(deadCheck == false)
			{
				deadCheck = true;
				enemy.Play(3);
			}
				if(enemy.IsPlaying("dead") == false)
				Destroy(gameObject);
		}
	}
}