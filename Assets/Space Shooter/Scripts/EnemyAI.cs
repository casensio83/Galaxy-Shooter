using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    private float speed = 4.0f;
    private const float BOUNDARY_DOWN = -6.0f;
    private const float POSITION_Z = 0;
    private const float MIN_RANGE = -8;
    private const float MAX_RANGE = 8;
    private const float INITIAL_ENEMY_Y_POSITION = 7;

	public GameObject enemyExplosion;

	void Start () 
    {
		
	}
	
	void Update () 
    {
		moveEnemy();

        if(transform.position.y <= BOUNDARY_DOWN) {
            float randomXPosition = Random.Range(MIN_RANGE, MAX_RANGE);

            transform.position = new Vector3(randomXPosition, INITIAL_ENEMY_Y_POSITION, POSITION_Z);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            if(other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }

            Destroy(other.gameObject);
			Instantiate (enemyExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.removeLive();
            }

			Instantiate (enemyExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void moveEnemy()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
