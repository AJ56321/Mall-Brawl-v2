// PlayFootSteps
// Play footsteps audio on the character as it moves on the ground

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayFootSteps : MonoBehaviour
{
	public AudioClip footStepSound;

	private float timer = 0.0f;
	private float waitTimer = 0.35f;

	private CharacterController controller;
	
	void Start()
	{
		controller = GetComponent<CharacterController>();
	}
	
	void Update ()
	{
		timer -= Time.deltaTime;
		if(timer < 0.0 && controller.velocity != Vector3.zero && controller.isGrounded)
		{
			AudioSource.PlayClipAtPoint(footStepSound, transform.position);
			timer = waitTimer;
		}
	}
}