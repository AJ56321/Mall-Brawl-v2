using UnityEngine;
using System.Collections;

public class DestroyAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var prev_audio = GameObject.FindWithTag ("Music Manager");
		Destroy (prev_audio);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
