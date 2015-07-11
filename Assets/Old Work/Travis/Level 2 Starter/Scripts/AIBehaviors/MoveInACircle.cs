// MoveInACircle
// Basic Enemy Behavior that moves the gameObject in a circle

using UnityEngine;
using System.Collections;

public class MoveInACircle : MonoBehaviour 
{
	public float speed  = 1.0f;
	public float radius = 10.0f;
	
	private float originalX;
	private float originalZ;
	
	void Start()
	{
		originalX = transform.position.x;
		originalZ = transform.position.z;
	}
	
	
	void Update () 
	{
		Vector3 pos = transform.position;
		pos.x = originalX + Mathf.Sin(Time.time * speed) * radius;
		pos.z = originalZ + Mathf.Cos(Time.time * speed) * radius;
		transform.position = pos;
	}
}
