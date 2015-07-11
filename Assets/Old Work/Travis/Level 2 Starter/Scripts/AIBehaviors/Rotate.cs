// Rotate
// Rototes the gameObject around the specified axis

using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour 
{
	public enum whichWayToRotate {AroundX, AroundY, AroundZ}
	public whichWayToRotate way = whichWayToRotate.AroundX;
	public float speed  = 10f;
	
	void Update () 
	{
	
		switch(way){
			case whichWayToRotate.AroundX:
				transform.Rotate(Vector3.right * Time.deltaTime * speed);
				break;
			case whichWayToRotate.AroundY:
				transform.Rotate(Vector3.up * Time.deltaTime * speed);
				break;
			case whichWayToRotate.AroundZ:
				transform.Rotate(Vector3.forward * Time.deltaTime * speed);
				break;
			
		
		}
	
	}
}
