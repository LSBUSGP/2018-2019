using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public float runSpeed;
	Rigidbody myRB;
	public GameObject Run;
	public GameObject Idle;
	public GameObject Jump;
	bool facingRight; 
	bool jump;

	void Start () {

		myRB = GetComponent<Rigidbody>();
		Run.SetActive (false);
		facingRight = true;
	}


	void Update () {

	}
	void FixedUpdate ()
	{

		float move = Input.GetAxis ("Horizontal");
	
		myRB.velocity = new Vector3 (move * runSpeed, myRB.velocity.y, 0);

	if (move > 0 && !facingRight) {
		Flip ();
	} else {
		if (move < 0 && facingRight)
			Flip ();
	}
		if (jump == false) {
			
			if (move != 0) {
				Run.SetActive (true);
				Idle.SetActive (false);
				Jump.SetActive (false);
			} else {
				Run.SetActive (false);
				Idle.SetActive (true);
				Jump.SetActive (false);
			}
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			
			jump = true;
		}
		if (jump == true){
			Run.SetActive (false);
			Idle.SetActive (false);
			Jump.SetActive (true);
			StartCoroutine (JumpWait ());
		}
	}

	void Flip() {
		facingRight = !facingRight; 
		Vector3 theScale = transform.localScale;
		theScale.z *= -1;
		transform.localScale = theScale;
	}
	IEnumerator JumpWait(){
		if (jump == true) {
			yield return new WaitForSeconds (1.5f);
			jump = false;
		}
	}
}﻿