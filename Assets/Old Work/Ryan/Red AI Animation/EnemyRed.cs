using UnityEngine;
using System.Collections;

public class EnemyRed : MonoBehaviour {

	public float speed = 2.0f;

	void Update()
	{
			GetComponent<Rigidbody2D>().velocity = new Vector2 (transform.localScale.x * speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	public void Flip()
	{
		// Multiply the x component of localScale by -1.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Wall")
		{
			Flip();
		}
	}

	void Chase()
	{
	
	}

}
