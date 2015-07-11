// TriggerLevelLoad
// Load a new level if the player collides with this trigger
// Can specify an audio clip to play
// NOTE: the audioClip should be a 2D sound since we cannot insure the location of the AudioListener in relation to the AudioSource across scenes

using UnityEngine;
using System.Collections;

public class TriggerLevelLoad : MonoBehaviour 
{

	public string nameOfLevelToLoad  = "";
	public AudioClip playSound;
	public float delayToTransition = 0.1f;
	private bool triggered = false;
	private float transitionTime;
	private GameObject soundGameObject;

	void OnTriggerEnter (Collider other)
	{
	
		if(!triggered && (other.gameObject.tag == "Player" ))
		{
			if (playSound)
			{
				// determine if gameObject exists to play LevelLoadAudioSource.  If not, create it
				soundGameObject = GameObject.Find("LevelLoadAudioSource");
				if (soundGameObject==null) {
					soundGameObject = new GameObject("LevelLoadAudioSource");
					soundGameObject.AddComponent<AudioSource>();
				}
				// position the gameObject to be by this gameObject
				soundGameObject.transform.position = gameObject.transform.position;
				
				// set the AudioClip and tell it to play
				soundGameObject.GetComponent<AudioSource>().clip = playSound;
				soundGameObject.GetComponent<AudioSource>().Play();
				
				// set to not destory on level load, so the sound does not get truncated when the new level loads.
				DontDestroyOnLoad(soundGameObject);
			}
			
			triggered = true;
			transitionTime = Time.time + delayToTransition;
			
		}
	
	}
	
	void Update() {
		if (triggered && Time.time>transitionTime)
		{
			// load the new level
			Application.LoadLevel(nameOfLevelToLoad);
		}
	}
}
