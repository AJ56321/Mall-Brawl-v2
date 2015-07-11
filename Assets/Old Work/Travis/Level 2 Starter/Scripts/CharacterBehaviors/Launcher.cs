// Launcher
// Laucnh a projectile when the player hits the fire1 button

using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour 
{
	public GameObject projectile;
	public float fireRate = 0.5f;
	public float speed = 10f;
	public bool fireWhenPlayerClicks = false;
	private float nextFire = 0.0f;
	
	void Update () 
	{
		if (fireWhenPlayerClicks && Input.GetButton ("Fire1"))
		{
			Fire();
		}
	}
	
	void Fire()
	{
	
		if( Time.time > nextFire) 
		{
			// setup cool down
			nextFire = Time.time + fireRate;

			// Create the projectile and apply the desired velocy down the z-axis
			GameObject clone = (GameObject)Instantiate (projectile, transform.position, transform.rotation);
			clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection( new  Vector3(0,0,speed));
		}
	}
}
