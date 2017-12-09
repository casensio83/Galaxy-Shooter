using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private const float POSITION_Z = 0;
    private const int LEFT_CLICK = 0;

    // Screen boundaries
    private const float BOUNDARY_RIGHT = 8.22f;
    private const float BOUNDARY_LEFT = -8.3f;
    private const float BOUNDARY_UP = 0;
    private const float BOUNDARY_DOWN = -4.2f;

    // Laser positions
    private const float LEFT_LASER_X = -0.5f;
    private const float RIGHT_LASER_X = 0.5f;
    private const float CENTER_LASER_Y = 0.88f;
    private const float POSITION_ZERO = 0;

	// Game objects
	public GameObject singleLaserShot;
	public GameObject tripleLaserShot;

    private float speed = 5.0f;
    private float fireRate = 0.25f;
    private float nextFire = 0.0f;
    public bool isTripleShotEnabled = false;


    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

    }

    void Update()
    {
        userInputHandler();
        setPlayerBoundaries();
        shootWhenClickOnSpaceBarOrMouseLeftClick();
    }

    private void shootWhenClickOnSpaceBarOrMouseLeftClick()
    {
        // also limit fire with Time.time
		if (canFire())
        {
            if(isTripleShotEnabled) 
            {
				tripleShoot();
            }
            else
            {
				singleShoot();
            }
			nextFire = Time.time + fireRate;
        }
    }

	private bool canFire()
	{
		return (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButton (0)) && Time.time > nextFire;
	}


	private void tripleShoot()
	{
		Instantiate(tripleLaserShot, transform.position, Quaternion.identity);
	}

    private void singleShoot() 
    {
		Instantiate(singleLaserShot, transform.position + new Vector3(0, CENTER_LASER_Y, POSITION_Z), Quaternion.identity);
    }

    private void userInputHandler() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * this.speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * this.speed * verticalInput * Time.deltaTime);
    }

    private void setPlayerBoundaries() 
    {
        float positionX = transform.position.x;
        float positionY = transform.position.y;

        setUpDownBoundaries(positionX, positionY);
        setLateralBoundaries(positionX, positionY);
    }

    private void setUpDownBoundaries(float positionX, float positionY)
    {
        if (positionY > BOUNDARY_UP)
        {
            transform.position = new Vector3(positionX, BOUNDARY_UP, POSITION_Z);
        }
        else if (positionY < BOUNDARY_DOWN)
        {
            transform.position = new Vector3(positionX, BOUNDARY_DOWN, POSITION_Z);
        }
    }

    private void setLateralBoundaries(float positionX, float positionY) 
    {
        if (positionX > BOUNDARY_RIGHT)
        {
            transform.position = new Vector3(BOUNDARY_RIGHT, positionY, POSITION_Z);
        }
        else if (positionX < BOUNDARY_LEFT)
        {
            transform.position = new Vector3(BOUNDARY_LEFT, positionY, POSITION_Z);
        }
    }

	public void tripleShotPowerupOn()
	{
		isTripleShotEnabled = true;
		StartCoroutine (tripleShotPowerupRoutine());
	}

	public IEnumerator tripleShotPowerupRoutine()
	{
		yield return new WaitForSeconds (5.0f);
		isTripleShotEnabled = false;
	}
}
