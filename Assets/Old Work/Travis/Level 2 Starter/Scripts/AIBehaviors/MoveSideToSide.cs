// MoveSideToSide
// Basic Enemy Behavior that moves the gameObject from side to side

using UnityEngine;
using System.Collections;

public class MoveSideToSide : MonoBehaviour 
{
	public float speed  = 1.0f;
	public float distance = 10.0f;
	
	public enum whichWay {AlongX, AlongZ}
	public whichWay way  = whichWay.AlongX;
	
	private float originalX;
	private float originalZ;
	
	private Vector3 originalRotation;
	
	void Start()
	{
		originalX = transform.position.x;
		originalZ = transform.position.z;
	}
	
	
	void Update () 
	{
		Vector3 pos = transform.position;
		if(way == whichWay.AlongX)
		{
			pos.x = originalX + Mathf.Sin(Time.time * speed) * distance;
		} 
		else 
		{
			pos.z = originalZ + Mathf.Cos(Time.time * speed) * distance;
		}
		transform.position = pos;
		
	}
}
