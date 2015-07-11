using UnityEngine;
using System.Collections;

public class FinalScore : MonoBehaviour {
	public UILabel display;
	public int finalScore;
	public int finalTime;
	public int timeBonus;
	public int multiply;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		multiply = PlayerPrefs.GetInt ("Multiplier");
		finalScore = PlayerPrefs.GetInt("Player Score");
		finalTime = PlayerPrefs.GetInt ("Time");
		finalScore += finalTime * 10 *multiply;
		display.text = finalScore.ToString();
	}
}
