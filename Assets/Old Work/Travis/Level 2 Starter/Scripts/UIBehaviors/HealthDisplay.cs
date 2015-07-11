// HealthDisplay
// Attach this to the health display GUI
// This updates based on the healthPoints held in the players Health script

using UnityEngine;
using System.Collections;

public class HealthDisplay : MonoBehaviour 
{

	public PlayerHealth healthToShow;
	public UILabel healthLabel;
	public string healthTypeLabel = "Health";
	public UISlider slider;


	void Start () 
	{
		if (healthToShow == null && GameObject.FindWithTag("Player"))
			healthToShow = GameObject.FindWithTag("Player").GetComponent("PlayerHealth") as PlayerHealth;
	}
	
	
	void OnGUI()
	{
		if(healthToShow != null)
		{
			healthLabel.text = healthTypeLabel+": "+healthToShow.currentHealth.ToString();
			slider.value = healthToShow.currentHealth/100f;
		}
	}

	void Update(){
		if (slider.value <= 0){
			Application.LoadLevel("LoseMenu");
		}
	}
}
