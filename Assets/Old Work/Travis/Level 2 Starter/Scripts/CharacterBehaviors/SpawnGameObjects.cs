// SpawnGameObjects
// Script that can be used to spawn gameObjects (such as enemy) on a recurring basis

using UnityEngine;
using System.Collections;

public class SpawnGameObjects : MonoBehaviour 
{
	public Transform theThingToSpawn;
	
	public float secondsBetweenSpawning = 3.0f;
	
	public Transform targetToSetForSpawnedObjects;
	
	private float clock = 0.0f;
	
	void Update () 
	{
	
		clock += Time.deltaTime;
		if(clock >= secondsBetweenSpawning)
		{
			var clone = (GameObject) Instantiate(theThingToSpawn, transform.position, transform.rotation);
			if(targetToSetForSpawnedObjects != null)
			{
				clone.SendMessage("SetTarget", targetToSetForSpawnedObjects, SendMessageOptions.DontRequireReceiver);
			}
			clock = 0.0f;
		}
	}
}
