using UnityEngine;
using System.Collections;
using SmoothMoves;	// using SmoothMoves

// Ryan Feldman's Notes

// 1: Walk
// 2: Attack
// 3: Dead
// 4: Idle

public class HeroAnimation : MonoBehaviour {
	
	public BoneAnimation Hero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	// Play Animation according to the ClipCount
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				Hero.Play(1);
			}
			if (Input.GetKeyDown (KeyCode.Alpha2)) {
				Hero.Play(2);
			}
			if (Input.GetKeyDown (KeyCode.Alpha3)) {
				Hero.Play(3);
			}
			if (Input.GetKeyDown (KeyCode.Alpha4)) {
				Hero.Play(4);
			}
			if (Input.GetKeyDown (KeyCode.Alpha5)) {
				Hero.Play(5);
			}
			if (Input.GetKeyDown (KeyCode.Alpha0)) {
				Hero.Play(0);
		}
	}
}
