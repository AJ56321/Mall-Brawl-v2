using UnityEngine;
using System.Collections;

public class LoadMusic : MonoBehaviour {
	private static LoadMusic instance = null;
	public static LoadMusic Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} 

		else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}