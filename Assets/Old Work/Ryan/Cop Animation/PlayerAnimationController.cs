using UnityEngine;
using System.Collections;
using SmoothMoves;

//[0] Idle, [1] Walk, [2] Attack, [3] Dead, [4] Jump, [5] Taser

public class PlayerAnimationController : MonoBehaviour {

	public BoneAnimation player;
	public CharacterController2D characterControllerScript;

	public bool attackCheck = false;
	public bool jumpCheck = false;
	public bool deadCheck = false;

	public bool isIdle = true; //Default at true for the start of the game
	public bool isAttacking = false;
	public bool isJumping = false;
	public bool isMovingSideways = false;
	public bool isDead = false;

	//For Taser
	public Transform fireSpot;
	public GameObject bullet;

	IEnumerator WaitAndShoot(float time){
		yield return new WaitForSeconds(time);
		if(player.IsPlaying(5)){
			Instantiate(bullet,fireSpot.position,fireSpot.rotation);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		attackCheck = true;

		if(isDead == false){
			// If the player is not attacking (baton or taser) 
			if ((player.IsPlaying (2) == false)&&(player.IsPlaying(5) == false)) {
				isAttacking = false;
				attackCheck = false;
			}

			if (player.IsPlaying (4) == false) {
				//jumpCheck = false;
			}


			if (   (isMovingSideways) && (!isJumping) && (!isAttacking) ) {
				player.Play(1); //Make the player walk
			}



			if (Input.GetKeyDown(KeyCode.F)){
				isAttacking = true;
				if(!attackCheck){
					player.Play(2);
				}
			}
			if (Input.GetKeyDown(KeyCode.D)){
				isAttacking = true;
				if(!attackCheck){
					player.Play(5);
					StartCoroutine(WaitAndShoot(.17f));

				}
			}
			if (Input.GetKeyDown(KeyCode.UpArrow)){
				isJumping = true;
				if(!jumpCheck){
					jumpCheck = true;
					player.Play(4);
				}
			}

			if((!isAttacking)&&(!isJumping)&&(!isMovingSideways)&&(isDead == false)){
				player.Play(0); //If nothing else is going on, play idle
			}
		}
		else if (   (isDead == true)&&(!deadCheck)   ){
			deadCheck = true;
			player.Play(3);
			characterControllerScript.enabled = false;
		}

	}
}
