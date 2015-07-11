using UnityEngine;
using System.Collections;

public class PlutoniumPickup : MonoBehaviour {
	public int score = 0;
	public int plutoniumValue = 100;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Plutonium")
		{
			Destroy(other.gameObject);
			score += plutoniumValue;
			GetComponent<AudioSource>().Play();
		}
	}
}
