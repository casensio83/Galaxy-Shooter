using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour 
{

	void Start () 
	{
		// destroy the explosion instance after 4 seconds
		Destroy(this.gameObject, 4f); 
	}
}
