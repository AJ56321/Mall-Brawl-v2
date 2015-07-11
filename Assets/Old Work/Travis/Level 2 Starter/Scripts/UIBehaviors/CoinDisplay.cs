// CoinDisplay
// Attach this to the coin display GUI
// The CoinPickup script will reference this script to display pickups

using UnityEngine;
using System.Collections;

public class CoinDisplay : MonoBehaviour 
{
	public int TotalCoins = 0;
	public string coinTypeLabel = "Coins";
	public bool DisplayCoins = true;
	public UILabel coinsLabel;
	
	public void AddCoins (int coins)
	{
		//Called by objects with the CoinPickup script
		TotalCoins += coins;
	}

	void Update(){
		if (TotalCoins == 5) {
			Destroy(GameObject.FindWithTag("Door"));
				}
		}
	

	void OnGUI()
	{
		//Displays the total number of coins
		if(DisplayCoins && coinsLabel)
		{
			coinsLabel.text = coinTypeLabel+": "+TotalCoins.ToString();
		}
	}
}
