using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public float speed = 20f;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindWithTag ("Player");
		if (player.transform.localScale.x < 0) {
			speed = -speed;
		}
		Destroy (gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2 (speed * Time.deltaTime, 0));
	}

}
