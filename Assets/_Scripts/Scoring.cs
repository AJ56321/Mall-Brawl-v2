using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {

	public Spawner kills;
	public PlutoniumPickup plutoScore;
	public int totalScore;
	public UILabel display;
	private int score1 = 0;
	private int score2 = 0;

	void Update () {
		score1 = kills.score;
		score2 = plutoScore.score;
		totalScore = score1 + score2;
		display.text = totalScore.ToString();
		PlayerPrefs.SetInt("Player Score", totalScore);
	}
}
