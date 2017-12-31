using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour 
{
	[SerializeField]
	private GameObject enemy;

	[SerializeField]
	private GameObject[] powerups;

	void Start () 
	{
		StartCoroutine (enemySpawnRoutine());
		StartCoroutine (powerupSpawnRoutine());
	}
	
	IEnumerator enemySpawnRoutine()
	{
		while (true) 
		{
			Instantiate (enemy, new Vector3(Random.Range(-8f,8f), 7, 0), Quaternion.identity);
			yield return new WaitForSeconds(3.0f);
		}
	}

	IEnumerator powerupSpawnRoutine()
	{
		while (true) 
		{
			int randomPowerup = Random.Range (0,3);
			Instantiate (powerups[randomPowerup], new Vector3(Random.Range(-7f,7f), 7, 0), Quaternion.identity);
			yield return new WaitForSeconds (7.0f);
		}
	}
}
