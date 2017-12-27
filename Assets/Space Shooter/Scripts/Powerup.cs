using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	private float speed = 3.0f;
	public int powerupdID; // 0 = triple shot, 2 = shield


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

				if (powerupdID == 2) 
				{
					// enable shield
					player.enableShield();
				}
			}
				
			Destroy (this.gameObject);
		}
	}

	private void movePowerup()
	{
		transform.Translate (Vector3.down * speed * Time.deltaTime);
	}
}
