using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	private float speed = 3.0f;


	void Start () 
	{
		
	}

	void Update () 
	{
		movePowerup ();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Player player = other.GetComponent<Player> ();

			if (player != null) 
			{
				player.tripleShotPowerupOn ();
			}
				
			Destroy (this.gameObject);
		}
	}

	private void movePowerup()
	{
		transform.Translate (Vector3.down * speed * Time.deltaTime);
	}
}
