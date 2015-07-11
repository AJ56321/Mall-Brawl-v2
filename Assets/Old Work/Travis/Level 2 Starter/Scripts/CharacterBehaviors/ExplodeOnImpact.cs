// ExplodeOnImpact
// Make gameObject (such as a projectile) explode when it hits something

using UnityEngine;
using System.Collections;

public class ExplodeOnImpact : MonoBehaviour 
{
	public Transform explosionPrefab;
	
	public bool dontExplodeOnTerrain = false;
	
	public float delayBeforeExplosion = 0.2f;
	
	public float damageAmount  = 10.0f;
	public float size = 3.0f;
	
	//file:///Applications/Unity/Unity.app/Contents/Documentation/Documentation/ScriptReference/Collider.OnCollisionEnter.html
	void OnCollisionEnter(Collision collision) 
	{
		
		// determine if should exit early if hit the terrain
		if(dontExplodeOnTerrain)
		{
			TerrainCollider isTerrain = collision.gameObject.GetComponent("TerrainCollider") as TerrainCollider;
			if(isTerrain != null)
			{
				 return;
			}			
		}
		
		// if hit self then exit early
		if(collision.gameObject == gameObject)
		{
			return;	
		}
		
		//OverlapSphere generates a sphere and returns all colliders in this hypothetical shere. Never call in Update, too expensive.
		// we do this because we may be colliding with more than one objects at the same and therefore we should do damage to all of them
		Collider[] colliders  = Physics.OverlapSphere( transform.position, size );
		
		// loop through all colliding objects and send ApplyDamage message
		foreach( var hit in colliders ) 
		{ 
	 		hit.gameObject.SendMessage("ApplyDamage",damageAmount, SendMessageOptions.DontRequireReceiver);
		}
			
			
		// Rotate the object so that the y-axis faces along the normal of the surface
		var contact = collision.contacts[0];
		var rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		var pos = contact.point;
		Instantiate(explosionPrefab, pos, rot);
		
		// Destroy the projectile
		Destroy (gameObject, delayBeforeExplosion);
		
	}
}
