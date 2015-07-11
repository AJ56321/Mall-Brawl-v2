// CoinPickup
// When player collides with the pickup, increase coin total by CoinAmount
// Requires the Player object to be tagged as "Player"
// if Animation is specified, it will play the animation on the object (like a treasure chest opening)
// otherwise, it will destroy the object (like the object was picked up)

using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour 
{
	public int CoinAmount;
	public AudioClip SoundEffect;
	public string animationToPlay;
	public bool treasureAvailable = true;
		
	private CoinDisplay myTracker;
	
	void Start () 
	{
		// Find the CoinDisplay object
		myTracker = GameObject.Find("CoinDisplay").GetComponent("CoinDisplay") as CoinDisplay;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(treasureAvailable && (other.tag == "Player"))
		{
			//If the player is the one to collide with the object, pick it up
			if(SoundEffect)
			{
				//If the script has an audio clip specified, play it
				AudioSource.PlayClipAtPoint(SoundEffect, transform.position);
			}
			
			// if CoinDisplay available, then add coins just picked up
			if (myTracker) {
				myTracker.AddCoins(CoinAmount);
				treasureAvailable = false;
			}
			
			// play animation if specified
			if (animationToPlay.Length>0)
			{
				gameObject.GetComponent<Animation>().Play(animationToPlay);
			} else
			{
				// destroy the pickup since it has served it's purpose
				Destroy(gameObject);
			}
		}
	}
}
