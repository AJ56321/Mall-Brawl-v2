using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	private EnemyStrengthDisplay enemies;
	public int maxEnemies;
	//public float spawnTime = 5f;		// The amount of time between each spawn.
	//public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject[] enemy;		// Array of enemy prefabs.
	private int killedEnemies = 0;
	public int score = 0;
	public int killValue = 30;


	/*void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	*/
	/*
	void Update ()
	{
		if(GameObject.FindGameObjectsWithTag ("Enemy").Length < maxEnemies){
			// Instantiate a random enemy.
			//int enemyIndex = Random.Range(0, enemies.Length);
			Instantiate(enemy, transform.position, transform.rotation);
		}

	}
*/

	private int count = 0;
	//public int maxEnemies;

	//public GameObject enemy;

	public GameObject spawn1;
	public GameObject spawn2;
	public GameObject spawn3;

	void Update(){
		//if (killedEnemies < enemies.enemiesToKill) {
						if (GameObject.FindGameObjectsWithTag ("Enemy").Length < maxEnemies && count == 0) {
								int enemyIndex = Random.Range(0, enemy.Length);
								Instantiate (enemy[enemyIndex], spawn1.transform.position, spawn1.transform.rotation);
								count ++;
								killedEnemies++;
								score += killValue;
						}

						if (GameObject.FindGameObjectsWithTag ("Enemy").Length < maxEnemies && count == 1) {
								int enemyIndex = Random.Range(0, enemy.Length);
								Instantiate (enemy[enemyIndex], spawn2.transform.position, spawn2.transform.rotation);
								count ++;
								killedEnemies++;
								score += killValue;
						}

						if (GameObject.FindGameObjectsWithTag ("Enemy").Length < maxEnemies && count == 2) {
								int enemyIndex = Random.Range(0, enemy.Length);
								Instantiate (enemy[enemyIndex], spawn3.transform.position, spawn3.transform.rotation);
								count = 0;
								killedEnemies++;
								score += killValue;
						}
		//}

	}
}
/*
using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.
	
	
	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	
	
	void Spawn ()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
		
		// Play the spawning effect from all of the particle systems.
		foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		{
			p.Play();
		}
	}
}*/