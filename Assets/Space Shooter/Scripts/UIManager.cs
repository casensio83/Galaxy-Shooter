using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Does not communicate with other classes 
//because reference to enemy can be destroyed and the game would crash
// So this UIManager only receives but does not send anything back
public class UIManager : MonoBehaviour 
{

	public Sprite[] lives;
	public Image livesImageDisplay;
	public Text scoreText;
	public int score;

	void Start()
	{
		
	}

	public void updateLives(int currentLives)
	{
		Debug.Log ("Current lives ->" + currentLives);
		livesImageDisplay.sprite = lives [currentLives];
	}

	public void updateScore()
	{
		score += 10;

		Debug.Log ("scoreText ->" + scoreText);

		if (scoreText != null) 
		{
			scoreText.text = "Score: " + score;
		}
	}

}
