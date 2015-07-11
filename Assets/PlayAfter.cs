using UnityEngine;
using System.Collections;

public class PlayAfter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Wait ();
		var new_audio = GameObject.FindWithTag ("Win Jingle");
		new_audio.GetComponent<AudioSource>().Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (10f);
	}
}
