using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour 
{
	[SerializeField]
	private GameObject enemy;

	[SerializeField]
	private GameObject[] powerups;

	private GameManager gameManager;

	void Start()
	{
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
		StartCoroutine (enemySpawnRoutine());
		StartCoroutine (powerupSpawnRoutine());
	}

	public void startSpawnCoroutines()
	{
		StartCoroutine (enemySpawnRoutine());
		StartCoroutine (powerupSpawnRoutine());
	}
	
	IEnumerator enemySpawnRoutine()
	{
		while (gameManager.gameOver == false) 
		{
			Instantiate (enemy, new Vector3(Random.Range(-8f,8f), 7, 0), Quaternion.identity);
			yield return new WaitForSeconds(3.0f);
		}
	}

	IEnumerator powerupSpawnRoutine()
	{
		while (gameManager.gameOver == false) 
		{
			int randomPowerup = Random.Range (0,3);
			Instantiate (powerups[randomPowerup], new Vector3(Random.Range(-7f,7f), 7, 0), Quaternion.identity);
			yield return new WaitForSeconds (7.0f);
		}
	}
}
