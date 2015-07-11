// DoDamage
// Apply to any gameObject that deals damage to other gameObjects

using UnityEngine;
using System.Collections;

public class DoDamage : MonoBehaviour 
{

	public float damageDelay  = 1.0f;
	public float damageAmount = 10.0f;
	public bool onlyDamageOnce = false;
	
	public bool selfDestructOnImpact = false;
	
	private bool alreadyDidDamage = false;
	
	private float nextDamage = 0.0f;
	
	public float size = 1.0f;
	public Vector3 offset;
	
	public GameObject replacementOnDestruct;
	
	public bool isEnemy = true;
	
	public AudioClip attackSound;
	
	CharacterController controller;
	
	void Start()
	{
		controller = GetComponent<CharacterController>();
	}
	
	void Update()
	{
		if(controller != null)
		{	
			// determine what gameObjects this object is colliding with
			Collider[] colliders  = Physics.OverlapSphere( transform.position + offset, size );
			
			// loop through all colliding objects
			foreach( var hit in colliders )
			{ 
				if(hit.gameObject.name != "Terrain")
				{
					if(hit.gameObject != gameObject)
					{
						//If the object doing damage is the enemy, a Chaser for example, only focus on damaging the player
						if(isEnemy && hit.tag == "Player")
						{
							inflictDamage(hit.gameObject);
						} else if(!isEnemy && hit.tag != "Player") // not enemy, so damage things other than the player
						{
							inflictDamage(hit.gameObject);
						}		
					}
				}
			}
		}
	}
	
	public void inflictDamage(GameObject damageTarget)
	{
		// exit if already did damage and only damage once
		if(alreadyDidDamage && onlyDamageOnce)
		{
			return;
		}
		
		// if time to do damage again (after damage cooldown)
		if( Time.time > nextDamage)
		{
			if (attackSound) {
				AudioSource.PlayClipAtPoint(attackSound,gameObject.transform.position);
			}
			
			// send message to damageTarget to ApplyDamage
			damageTarget.SendMessage("ApplyDamage",damageAmount, SendMessageOptions.DontRequireReceiver);
			
			// setup damage cooldown
			nextDamage = Time.time + damageDelay;
			alreadyDidDamage = true;
			
			// if selfDestructOnImpact then handle 
			if(selfDestructOnImpact)
			{
				if(replacementOnDestruct != null)
				{
					Instantiate(replacementOnDestruct, transform.position, transform.rotation);	
				}
				Destroy(gameObject);
			}
		}
	}
	
	//Use this function to draw things in the editor
	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position + offset, size);
	}
}
