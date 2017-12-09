using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float speed = 10.0f;

	void Start () 
    {
		
	}
	
	void Update () 
    {
        moveLaserUp();
        removeLaserWhenItsOutOfBoundary();
	}

    private void moveLaserUp() {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void removeLaserWhenItsOutOfBoundary() 
    {
        float positionY = transform.position.y;

        if (positionY >= 5.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
