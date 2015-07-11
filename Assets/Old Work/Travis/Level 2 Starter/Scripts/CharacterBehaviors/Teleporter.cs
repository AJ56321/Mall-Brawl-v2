// Teleporter
// Teleport the colliding gameObject to a specified target position in the same scene if triggered

using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour 
{
	public Transform target;
	
	void OnTriggerEnter (Collider other) 
	{
		if(target != null)
		{
			other.gameObject.transform.position = target.position;
		}
	}
}
