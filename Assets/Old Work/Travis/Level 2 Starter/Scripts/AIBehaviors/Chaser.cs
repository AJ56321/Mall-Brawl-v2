// Chaser
// Enemy behavior that moves the gameObject toward a specified target

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Chaser : MonoBehaviour 
{
	public Transform target;
	public float speed = 1.0f;
	public float gravity = 20.0f;
	public float attackRange = 30.0f;
	
	//Store things like these that we use every frame rather than calling GetComponent constantly. 
	//Super performance enhancement that really makes a difference - especially on mobile
	CharacterController controller;
		
	void Start () 
	{
		// if no target specified, assume the Player
		if (target == null && GameObject.FindWithTag("Player"))
			target = GameObject.FindWithTag("Player").transform;
		
		controller = GetComponent<CharacterController>();
	}
	
	void Update () 
	{

		if (target == null)
			return;
		
		if (!CanSeeTarget ())
			return;

		var targetPoint = target.position;
		var targetRotation = Quaternion.LookRotation (targetPoint - transform.position, Vector3.up);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);

		// calculate the direction to move in toward the target
		Vector3 moveDirection = target.transform.position - transform.position;
		moveDirection *= speed;
		
		// Apply gravity
		moveDirection.y -= gravity * Time.deltaTime;
			
		// Move the controller
		controller.Move(moveDirection * Time.deltaTime);

	}
	
	void SetTarget(Transform newTarget)
	{
		target = newTarget;
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
