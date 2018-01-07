using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour 
{
	private Animator animator;

	void Start () 
	{
		animator = GetComponent<Animator> ();
	}

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			animator.SetBool ("Turn_Left", true);
			animator.SetBool ("Turn_Right", false);
		}

		if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.LeftArrow)) 
		{
			animator.SetBool ("Turn_Left", false);
		}

		if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			animator.SetBool ("Turn_Right", true);
			animator.SetBool ("Turn_Left", false);
		}

		if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.RightArrow)) 
		{
			animator.SetBool ("Turn_Right", false);
		}
	}
}
