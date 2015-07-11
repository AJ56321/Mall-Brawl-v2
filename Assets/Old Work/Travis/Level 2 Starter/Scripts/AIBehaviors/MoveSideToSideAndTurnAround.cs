// MoveSideToSideAndTurnAround
// Has the enemy patrol back and forth

using UnityEngine;
using System.Collections;

public class MoveSideToSideAndTurnAround : MonoBehaviour 
{
	public float speed  = 1.0f;
	public float distance = 10.0f;
	
	public MoveSideToSide.whichWay way = MoveSideToSide.whichWay.AlongX;
	
	private float originalX;
	private float originalZ;
	
	private Vector3 lastPos;
	
	private float lastT;
	
	private bool turning = false;
	
	void Start()
	{
		originalX = transform.position.x;
		originalZ = transform.position.z;
	}
	
	void Update () 
	{
		Vector3 pos = transform.position;
		if(way == MoveSideToSide.whichWay.AlongX) 
		{
			pos.x = originalX + Mathf.Sin(Time.time * speed) * distance;
			
			if(Mathf.Abs(lastT) > 0.9 && !turning)
			{
				StartCoroutine(TurnAround());
			}
		} 
		else 
		{
			pos.z = originalZ + Mathf.Cos(Time.time * speed) * distance;
		}
		lastT = Mathf.Sin(Time.time * speed);
		
		transform.position = pos;
	}
	
	//Coroutines are called after all the updates are called.
	//Coroutine functions need to return an IEnumarator
	//You cab still use Time.deltaTime in coroutines normally
	IEnumerator TurnAround()
	{
		float rotationChange = 0.0f;
		turning = true;
		while(rotationChange < 180.0)
		{
			rotationChange += 180.0f * Time.deltaTime;
			transform.Rotate(0.0f, 180.0f * Time.deltaTime, 0.0f);
			yield return false;
		}
		turning = false;
	}
}
