using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour 
{
	[SerializeField]
	private float speed = 3.0f;

	[SerializeField]
	private int powerupdID; // 0 = triple shot, 1 = speed, 2 = shield

	[SerializeField]
	private AudioClip audioClip;


	void Start () 
	{
		
	}

	void Update () 
	{
		movePowerup ();

		if (transform.position.y < -7) 
		{
			Destroy (this.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Player player = other.GetComponent<Player> ();

			if (player != null) 
			{
				if (powerupdID == 0)
				{
					player.tripleShotPowerupOn(); // enable triple shot
				}

				else if (powerupdID == 1)
				{
					player.enableSpeedBoost(); // enable speed boost
				}

				else if (powerupdID == 2) 
				{
					player.enableShield(); // enable shield
				}
			}
				
			AudioSource.PlayClipAtPoint (audioClip, Camera.main.transform.position, 1f);
			Destroy (this.gameObject);
		}
	}

	private void movePowerup()
	{
		transform.Translate (Vector3.down * speed * Time.deltaTime);
	}
}
