using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public bool gameOver = true;
	public GameObject player;
	private UIManager uiManager;

	private void Start()
	{
		uiManager = GameObject.Find ("Canvas").GetComponent<UIManager> ();
	}

	void Update()
	{
		if (gameOver == true && Input.GetKeyDown(KeyCode.Space)) 
		{
			Instantiate (player, Vector3.zero, Quaternion.identity);
			gameOver = false;
			uiManager.hideTitleScreen();
		}
	}
}
