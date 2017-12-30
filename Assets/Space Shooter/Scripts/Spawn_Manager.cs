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
	}
	
	IEnumerator enemySpawnRoutine()
	{
		while (true) 
		{
			Instantiate (enemy, new Vector3(Random.Range(-8f,8f), 5, 0), Quaternion.identity);
			yield return new WaitForSeconds(5.0f);
		}
	}
}
