using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAttempt : MonoBehaviour {

	public Transform player;
	public float walkingDistance = 10f;

	public float smoothTime = 10f;

	private Vector3 smoothVelocity = Vector3.zero;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (player);
		float distance = Vector3.Distance (transform.position, player.position);
		if (distance < walkingDistance)
		{
			transform.position = Vector3.SmoothDamp (transform.position, player.position, ref smoothVelocity, smoothTime);

	}
}
}
