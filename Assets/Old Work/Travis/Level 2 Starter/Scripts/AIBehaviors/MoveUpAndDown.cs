// MoveUpAndDown
// Moves the gameObject up and down along the y-axis

using UnityEngine;
using System.Collections;

public class MoveUpAndDown : MonoBehaviour 
{
	public float speed  = 1.0f;
	public float distance = 10.0f;
	
	private float originalY;
	
	void Start()
	{
		originalY = transform.position.y;	
	}
	
	
	void Update () 
	{
		//Can't just assign into transform.position.y, need to make a temp variable for this
		Vector3 pos = transform.position;
		pos.y = originalY + Mathf.Sin(Time.time * speed) * distance;	
		transform.position = pos;
	}
}
