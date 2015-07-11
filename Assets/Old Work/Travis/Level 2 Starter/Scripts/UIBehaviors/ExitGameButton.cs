// ExitGameButton
// Exits the game on MouseDown

using UnityEngine;
using System.Collections;

public class ExitGameButton : MonoBehaviour {

	void OnClick()
	{
		Application.Quit();
	}
}
