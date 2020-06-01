using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Characters {



	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	protected override void Update ()
	{
		GetInput ();
		move ();
	}

	private void GetInput()
	{
		direction = Vector3.zero;

		if (Input.GetKey (KeyCode.W))
		{
			direction += Vector3.forward;
		}
		if (Input.GetKey (KeyCode.S))
		{
			direction += Vector3.back;
		}
		if (Input.GetKey (KeyCode.A))
		{
			direction += Vector3.left;
		}
		if (Input.GetKey (KeyCode.D))
		{
			direction += Vector3.right;
		}
	}
}
