// ShowCursor
// Set to show or hide the mouse cursor (pointer) when the game starts

using UnityEngine;
using System.Collections;

public class ShowCursor : MonoBehaviour 
{
	public bool DisplayCursor = false;
	
	void Start()
	{
		Cursor.visible = DisplayCursor;
	}
}
