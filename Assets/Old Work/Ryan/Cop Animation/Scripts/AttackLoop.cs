using UnityEngine;
using System.Collections;
using SmoothMoves;	// using SmoothMoves

// Ryan Feldman's Notes

// 1: Walk
// 2: Attack
// 3: Dead
// 4: Idle

public class AttackLoop: MonoBehaviour {

	public bool attackLoop;
	public BoneAnimation Hero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	// Play Animation according to the ClipCount
		if ((attackLoop == true)&&(Hero.isPlaying == false)) {
			Hero.Play(2);
		}
	}
}
