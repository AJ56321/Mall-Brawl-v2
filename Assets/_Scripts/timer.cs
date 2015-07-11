using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {

	public UILabel NguiTimeLabel;
	public float myTimer = 180.0f;
	public int Triggerflag = 1;
	
	void Update () {	
		
		
		if(myTimer > 1.0) {
			myTimer -= Time.deltaTime;
			int minutes = Mathf.FloorToInt(myTimer / 60F);
			int seconds = Mathf.FloorToInt(myTimer - minutes * 60);
			string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
			NguiTimeLabel.text= niceTime;
			PlayerPrefs.SetInt("Time", Mathf.FloorToInt(myTimer));
		}	
		if(myTimer < 1.0) {
			
			if (Triggerflag == 1){
				Triggerflag = 0;
				//trigger death animation
				//play death noise
				//wait a couple sentence
				Application.LoadLevel("LoseMenu");

			}
			
			
		}
		
	}
}