// Shooter
// Enemy behavior that shoots toward the player if the object can "see" the player
// works in conjunction with the Launcher script attached to the object (or child of the object)

using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour 
{
	public float attackRange = 30.0f;
	public float shootAngleDistance = 10.0f;
	
	public Transform target;
	
	void Start () 
	{
		// assume target is player if not specified
		if (target == null && GameObject.FindWithTag("Player"))
			target = GameObject.FindWithTag("Player").transform;
	}
	
	
	void Update () 
	{
		
		if (target == null)
			return;
		
		if (!CanSeeTarget ())
			return;
		
		// Rotate towards target	
		var targetPoint = target.position;
		var targetRotation = Quaternion.LookRotation (targetPoint - transform.position, Vector3.up);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
	
		// If we are almost rotated towards target - fire one clip of ammo
		var forward = transform.TransformDirection(Vector3.forward);
		var targetDir = target.position - transform.position;
		if (Vector3.Angle(forward, targetDir) < shootAngleDistance)
		{
			// tell the Launcher to fire
			BroadcastMessage("Fire");
		}
	}
	
	bool CanSeeTarget()
	{
		if (Vector3.Distance(transform.position, target.position) > attackRange)
			return false;
		
		//Line cast shoots an invisible line in a direction and returns what it hits, if anything. Very useful, but very expensive.
		//Try to keep line casts and Raycasts to a minimum, especially in update. Physics.Raycast is generally used more than Linecast
		RaycastHit hit;
		if (Physics.Linecast (transform.position, target.position, out hit))
			return hit.transform == target;
	
		return false;
	}

}
