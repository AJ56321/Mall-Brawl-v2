// LiveDisplay
// Attach this to the lives display GUI
// The Health script will reference this script to display loss of life

using UnityEngine;
using System.Collections;

public class LiveDisplay : MonoBehaviour 
{
	public int livesToStart = 3;
	public int lives = 3;
	public string levelToLoadWhenLivesGone = "";
	public UILabel livesLabel;
	public string livesTypeLabel = "Lives";
	
	private Vector3 startPoint;
	
	void Start()
	{
		lives = livesToStart;	
		
		startPoint = GameObject.FindWithTag("Player").transform.position;
	}
	
	void Update () 
	{	
		if(lives <= 0)
		{		
			Application.LoadLevel(levelToLoadWhenLivesGone);
		}
	}
	
	void LoseALife(){
		lives--;
		var player = GameObject.FindWithTag("Player");
		var controller = player.GetComponent<CharacterController>();
		controller.Move(startPoint - player.transform.position);
	}
	
	void OnGUI()
	{
		livesLabel.text = livesTypeLabel+": "+lives.ToString();
	}
}
