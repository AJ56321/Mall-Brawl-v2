using UnityEngine;
using System.Collections;

public class EnemyStrengthDisplay : MonoBehaviour {

	public float enemiesToKill;
	private float number = 1;
	public UISlider slider;
	public float barVal = 1.0f;
	public int multiply= 0;

	void Awake(){
		barVal = (1.0f / enemiesToKill);
		number = GameObject.FindGameObjectsWithTag ("Enemy").Length;
	}

	void Update(){
	
		if (GameObject.FindGameObjectsWithTag("Enemy").Length == number-1){
			slider.value -= barVal;
			number -= 1;
			enemiesToKill--;
		}
		number = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		if(enemiesToKill <=0){
			multiply = 1;

			Application.LoadLevel("WinMenu");
		}
		PlayerPrefs.SetInt("Multiplier", multiply);
	}}
